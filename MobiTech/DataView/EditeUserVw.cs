using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class EditeUserVw
    {
        public EditeUserVw(){
            Claims = new List<string>();
            Roles = new List<string>();
            }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string CurrantPassword { get; set; }
        
        public string Email { get; set; }

        public string FullName { get; set; }
        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}
