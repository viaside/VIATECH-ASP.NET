using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIATECH.Domain;
using VIATECH.Domain.Entities;
using VIATECH.Service;

namespace VIATECH.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Orders.SaveOrder(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
