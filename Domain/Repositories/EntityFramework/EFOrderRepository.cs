using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VIATECH.Domain.Entities;
using VIATECH.Domain.Repositories.Abstract;

namespace VIATECH.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> GetOrders()
        {
            return context.Orders;
        }

        /*public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }*/

        public void SaveOrder(Order entity)
        {
            if (entity.id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /*public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }*/
    }
}
