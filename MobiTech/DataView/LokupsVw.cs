using MobiTech.Data;
using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class LokupsVw
    {
        public int Id { get; set; }
        public String Name { get; set; }
     //   public LkpType Type { get; set; }
       
            public int TypeId { get; set; }
        public string Group { get; internal set; }
    }
}
