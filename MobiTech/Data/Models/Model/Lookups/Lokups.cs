using Domain.Model;
using MobiTech.Data.Models.Model;
using MobiTech.Data.Models.Model.InterNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace MobiTech.Data.Models.Model
{
    public class Lokups : AuditModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
         public LkpType Type { get; set; }
        public int TypeId { get; set; }




        //for store relation

        [NotMapped] public ICollection<Store> LkpColors { get; set; }
        [NotMapped] public ICollection<Store> LkpTypes { get; set; }
        [NotMapped] public ICollection<Store> LkpStatuss { get; set; }
        [NotMapped] public ICollection<Store> LkpStorages { get; set; }
        [NotMapped] public ICollection<Store> LkpActives { get; set; }
        [NotMapped] public ICollection<Store> Rams { get; set; }
        [NotMapped] public ICollection<Sale> Methode { get; set; }
        //[NotMapped] [IgnoreDataMember]
        //for Cheque
        public ICollection<Cheque> CheqStatus { get; set; }


        //for InterNet Connection
      public ICollection<InterNetNetWork> Countries { get; set; }

    }
}
