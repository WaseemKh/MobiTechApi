using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Models
{
    public class SignModel
    {
 

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName { get; set; }
        public string Role { get; set; }

    }
}
