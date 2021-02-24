using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]        
        public DateTime OrderDate { get; set; }

        [Required]        
        public OrderStatus OrderStatus { get; set; }

        [Required]        
        public OrderMethods OrderMethod { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        public int EmployeeId { get; set; }

        public int MemberId { get; set; }
    }
}
