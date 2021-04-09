using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;

namespace MobiTech.Data
{
    public class SysUsers: IdentityUser
    {
        [Column(TypeName= "nvarchar(150)")]
    //    public string Id { get; set; }

        public string FullName { get; set; }
        
        //  public string Password { get; set; }
        //  public string UserName { get; set; }
        // public string PhoneNumber { get; set; }
    }
}
