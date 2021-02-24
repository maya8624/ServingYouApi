using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public interface IBookingApiRepo
    {
        Task PostBookingAsync(Booking booking);
                
        Task<Booking> GetBookingAsync(int id);
        
        Task<IEnumerable<Booking>> GetAllAsync();
        
        Task<bool> SaveChangesAsync();
    }
}
