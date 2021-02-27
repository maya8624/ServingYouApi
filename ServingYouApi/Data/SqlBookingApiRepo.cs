using Microsoft.EntityFrameworkCore;
using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public class SqlBookingApiRepo : IBookingApiRepo
    {
        private readonly ServingyouApiContext context;

        public SqlBookingApiRepo(ServingyouApiContext context)
        {
            this.context = context;
        }

        public async Task PostBookingAsync(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }

            await context.Bookings.AddAsync(booking);        
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await context.Bookings.ToListAsync();           
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            var booking = await context.Bookings.SingleOrDefaultAsync(b => b.Id == id);
            return booking;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
