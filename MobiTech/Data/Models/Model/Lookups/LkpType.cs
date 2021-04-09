using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace MobiTech.Data.Models.Model

    
{
   public class LkpType:AuditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //public ICollection<Lokups> Lokups { get; set; }
         public ICollection<Lokups> Types { get; set; }


    }
}
