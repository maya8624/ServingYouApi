using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Dtos
{
    public class MemberCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]        
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]        
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]        
        public string Email { get; set; }
    }
}
