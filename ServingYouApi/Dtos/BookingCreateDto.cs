using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Dtos
{
    public class BookingCreateDto
    {
        [Required]
        [StringLength(30)]        
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]        
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Mobile { get; set; }

        [Required]                
        public DateTime DateBooked { get; set; }

        [Required]
        [StringLength(5)]        
        public string TimeBooked { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]        
        [Range(1, 20)]
        public int NumberinParty { get; set; }

        [Required]
        public int Method { get; set; }

        [Required]        
        public int TableNo { get; set; }
    }
}
