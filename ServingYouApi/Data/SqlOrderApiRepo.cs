using Microsoft.EntityFrameworkCore;
using ServingyouApi.Dtos;
using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public class SqlOrderApiRepo : IOrderApiRepo
    {
        private readonly ServingyouApiContext context;

        public SqlOrderApiRepo(ServingyouApiContext context)
        {
            this.context = context;
        }

        public async Task PostOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            await context.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await context.Orders.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddOrderMenuAsync(OrderMenu orderMenu)
        {
            if (orderMenu == null)
            {
                throw new ArgumentNullException(nameof(orderMenu));
            }

            await context.OrderMenu.AddAsync(orderMenu);
        }
                

        public async Task<Menu> GetMenuAsync(int id)
        {
            return await context.Menu.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
            return await context.SaveChangesAsync() >= 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

