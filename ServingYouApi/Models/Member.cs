using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]         
        public string FirstName { get; set; }

        [Required]        
        public string LastName { get; set; }

        [Required]        
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }
                
        public DateTime DateRegistered { get; set; }

        public DateTime DateUpdated { get; set; }         
    }
}
