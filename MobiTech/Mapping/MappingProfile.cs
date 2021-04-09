using AutoMapper;
using MobiTech.Data;
using MobiTech.Data.Models.Model;
using MobiTech.Data.Models.Model.InterNet;
using MobiTech.DataView;
using MobiTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //=============Lookup======
            CreateMap<Lokups, LokupsVw>();


            //=============Sale======
            CreateMap<Sale, SaleVw>();


            //=============Cheque======
            CreateMap<Cheque, ChequeVw>();

            //=============SysUsers======
            CreateMap<SignModel, SignModelVw>();
            CreateMap<SysUsers, SysUsersVw>();


            //=============InterNetNetwork======
            CreateMap<InterNetNetWork, InterNetNetworkVw>();
            
        }
    }
}
