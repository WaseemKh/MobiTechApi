using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class SysUsersVw
    {
        public string FullName { get; set; }
        public string PasswordHash { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string UserName { get; internal set; }
        public string Id { get; internal set; }
        //public string UserName { get; set; }
        //public string UserName { get; set; }
    }
}
