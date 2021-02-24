using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Dtos
{
    public class BookingReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }      
        
        public string LastName { get; set; }
        
        public string Mobile { get; set; }
        
        public DateTime DateBooked { get; set; }
    }
}
