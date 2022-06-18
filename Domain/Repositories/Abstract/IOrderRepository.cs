using System;
using System.Linq;
using VIATECH.Domain.Entities;

namespace VIATECH.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetOrders();
        void SaveOrder(Order entity);
    }
}
