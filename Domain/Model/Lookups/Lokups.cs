using Model.Store;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Model.Lookups
{
   public class Lokups:AuditModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public LkpType Type { get; set; }
        public int TypeId { get; set; }
        
       
        [IgnoreDataMember] public ICollection<Store> LkpColors { get; set; }
        [IgnoreDataMember] public ICollection<Store> LkpTypes { get; set; }
        [IgnoreDataMember] public ICollection<Store> LkpStatus { get; set; }
        [IgnoreDataMember] public ICollection<Store> LkpStorages { get; set; }
        [IgnoreDataMember] public ICollection<Store> Rams { get; set; }
        [IgnoreDataMember] public ICollection<Store> LkpActives { get; set; }

    }
}
