using MobiTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class LkpTypeVw
    {
        public int TypeId { get; set; }
        public string Name { get; set; }


        //public ICollection<Lokups> Lokups { get; set; }
        //[IgnoreDataMember] public ICollection<Lokups> Types { get; set; }

    }
}
