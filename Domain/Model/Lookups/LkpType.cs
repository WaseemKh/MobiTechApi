using Model.Store;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Model.Lookups
{
   public class LkpType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Editable { get; set; }


        [IgnoreDataMember] public ICollection<Lokups> Lokups { get; set; }


    }
}
