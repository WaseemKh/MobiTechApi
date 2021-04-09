using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
  public  class AuditModel
    {

       
            public int? InsertUser { get; set; }
            public DateTime? InsertDate { get; set; }
            public int? UpdateUser { get; set; }
            public DateTime? UpdateDate { get; set; }
        
    
   }
}
