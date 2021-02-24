using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }     
    }
}
