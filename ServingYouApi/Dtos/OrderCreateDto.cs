using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public OrderMethods OrderMethod { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }   

        public int MemberId { get; set; }

        public string Email { get; set; }

        public IEnumerable<OrderMenu> OrderMenus { get; set; }
    }
}
