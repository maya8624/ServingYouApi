using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Models
{
    public class OrderMenu
    {
        public int Id { get; set; }

        public int OrderId { get; set; }        

        public int MenuId { get; set; }        

        public int Quantity { get; set; }
        
        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
