using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Models
{
    public class Booking
    {
        public int Id { get; set; }

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
        public int NumberinParty { get; set; }

        [Required]
        public int Method { get; set; }
                
        public DateTime DateCreated { get; set; }
                
        public DateTime DateUpdated { get; set; }

        [Required]        
        public int TableNo { get; set; }

        public int EmployeeId { get; set; }
    }
}
