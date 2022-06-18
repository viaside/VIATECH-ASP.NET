using System;
using System.Linq;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VIATECH.Models;
using Microsoft.EntityFrameworkCore;
using VIATECH.Service;
using VIATECH.Domain;
using VIATECH.Domain.Repositories.Abstract;
using VIATECH.Domain.Repositories.EntityFramework;

namespace VIATECH
{
    class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration) => Configuration = configuration;


        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Config.ConnectionString = "Server=localhost;Port=5432;Database=VIAtech;User Id=postgres;Password=zxc;";
            builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();
            builder.Services.AddTransient<DataManager>();

            //подключаем контекст Ѕƒ
            builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(Config.ConnectionString));
            

            //настраиваем identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политику авторизации дл€ Admin area
            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //добавл€ем сервисы дл€ контроллеров
            builder.Services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.Configuration.Bind("Project", new Config());

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAreaControllerRoute(
                   name: "default",
                   areaName: "admin",
                   pattern: "Admin/{controller=Home}/{action=Index}");

            app.MapAreaControllerRoute(
                   name: "default",
                   areaName: "admin",
                   pattern: "Admin/{controller=order}/{action=Index}");

            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}