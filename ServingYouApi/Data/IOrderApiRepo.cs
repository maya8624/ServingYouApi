using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public interface IOrderApiRepo
    {
        Task PostOrderAsync(Order order);
        
        Task<Order> GetOrderAsync(int id);

        Task<IEnumerable<Order>> GetAllAsync();

        Task AddOrderMenuAsync(OrderMenu orderMenu);
        
        Task<bool> SaveChangesAsync();

        Task<Menu> GetMenuAsync(int id);        
    }
}
