using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MobiTech.Data;
using MobiTech.Data.Models.Model;
using MobiTech.DataView;

namespace MobiTech.Controllers
{

    //[Authorize(Roles = "Manager,Empolyee")]

    [Route("api/[controller]")]
    //[ApiController]
    public class StoresController : ControllerBase
    {
        private readonly MobiDbContext _db;

        public StoresController(MobiDbContext context)
        {
            _db = context;
        }

        // GET: api/Stores
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Store>>> GetStors()
        //{
        //    return await _context.Stors.ToListAsync();
        //}

        // GET: api/Stores
        [HttpGet]
        public async Task<IEnumerable<StoreVw>> GetStors()
        {
            var LkpType = _db.Stors.Include(x => x.LkpType);
            var LkpStorage = _db.Stors.Include(x => x.LkpStorage);
            var LkpRam = _db.Stors.Include(x => x.LkpRam);
            var LkpColor = _db.Stors.Include(x => x.LkpColor);
            var LkpActive = _db.Stors.Include(x => x.LkpActive);
            var LkpStatus = _db.Stors.Include(x => x.LkpStatus);
            var data = await _db.Stors?.Select(x =>
             new StoreVw
             {
                 Id = x.Id,
                 IMEI = x.IMEI,
                 Name = x.Name,
                 Type = x.LkpType.Name,
                 //Storage = x.LkpStorage.Name,
                 Date = string.Format("{0:MM-dd-yyyy}", x.InsertDate),
                 //Ram = x.LkpRam.Name,
                 //Color = x.LkpColor.Name,
                 Active = x.LkpActive.Name,
                 Status = x.LkpStatus.Name,
                 Price = x.Price,
                 PayPrice=x.PayPrice,
                 Qty=x.Qty



             }).ToListAsync();
            return data;
        }





        // GET: api/Stores
        [HttpGet("GetStorsForSale")]
        public async Task<IEnumerable<StoreVw>> GetStorsForSale()
        {
          
            var LkpStorage = _db.Stors.Include(x => x.LkpStorage);
            var LkpRam = _db.Stors.Include(x => x.LkpRam);
            var LkpColor = _db.Stors.Include(x => x.LkpColor);
            var LkpActive = _db.Stors.Include(x => x.LkpActive);
            var Id = _db.lokups.Where(x => x.Name == "متوفر" || x.Name == "Available").Select(x => x.Id).FirstOrDefault();
            var data = await _db.Stors?.Where(x=>x.LkpStatusId == Id).Select(x =>
             new StoreVw
             {
                 Id = x.Id,
                 IMEI = x.IMEI,
                 Name = x.Name,
                 
                 Storage = x.LkpStorage.Name,
               
                 Ram = x.LkpRam.Name,
                 Color = x.LkpColor.Name,
                 Active = x.LkpActive.Name,
                
                 PayPrice = x.PayPrice,
                 Qty=x.Qty


             }).ToListAsync();
            return data;
        }



        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _db.Stors.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        //Get:api/stores/TypeList
        [HttpGet("TypeList")]
        public async Task<IEnumerable<LokupsVw>> TypeList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Type").Select(x => x.Id).FirstOrDefault();
            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }


        //Get:api/stores/TypeList
        [HttpGet("ActiveList")]
        public async Task<IEnumerable<LokupsVw>> ActiveList()

        {
            var id = _db.lkpTypes.Where(x => x.Name == "Active").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }

        //Get:api/stores/StatusList
        [HttpGet("StatusList")]
        public async Task<IEnumerable<LokupsVw>> StatusList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Status").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }

        [HttpGet("ColorList")]
        public async Task<IEnumerable<LokupsVw>> ColorList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Color").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }

        [HttpGet("StorageList")]
        public async Task<IEnumerable<LokupsVw>> StorageList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Storage").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }


        [HttpGet("RamList")]
        public async Task<IEnumerable<LokupsVw>> RamList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Ram").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }
        [HttpGet("MethodList")]
        public async Task<IEnumerable<LokupsVw>> MethodList()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "Method").Select(x => x.Id).FirstOrDefault();
            var TypeId = _db.lokups.Where(x => x.Name == "موبايل" || x.Name == "Mobile").Select(x => x.Id).FirstOrDefault();

            var TypeList = await _db.lokups.Where(x => x.TypeId == id || x.TypeId==TypeId).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }
        [HttpGet("getCountSold")]
        public async Task<ActionResult<object>> getCountSold()
        {
            var Id = _db.lokups.Where(x => x.Name == "مباع" || x.Name == "Sold" ).Select(x => x.Id).FirstOrDefault();
            var TypeId = _db.lokups.Where(x => x.Name == "موبايل" || x.Name == "Mobile" ).Select(x => x.Id).FirstOrDefault();
            var data = _db.Stors.Where(x => x.LkpStatusId == Id && x.LkpTypeId==TypeId).Select(x => new { x.LkpStatusId }).Count();
            return data;

        }
        [HttpGet("getCountAvailabel")]
        public async Task<ActionResult<object>> getCountAvailabel()
        {
          
            var TypeId = _db.lokups.Where(x => x.Name == "موبايل" || x.Name == "Mobile" ).Select(x => x.Id).FirstOrDefault();
            var Id = _db.lokups.Where(x=>x.Name == "متوفر" || x.Name == "Availabel").Select(x => x.Id).FirstOrDefault();
            var data =  _db.Stors.Where(x=>x.LkpStatusId==Id && x.LkpTypeId == TypeId).Select(x => new { x.LkpStatusId }).Count();
            return data;

        }
       
        // PUT: api/Stores/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, [FromBody] Store store)
        {
            if (id != store.Id ||  _db.Stors.Where(x=>x.Id != store.Id).Any(x=>x.IMEI== store.IMEI))
            {
                return BadRequest();
            }

            _db.Entry(store).State = EntityState.Modified;

            try
            {
                var StatusId= _db.Stors.Where(x => x.Id == store.Id).Select(x => x.LkpStatusId).FirstOrDefault();
                store.LkpStatusId = StatusId;
                store.InsertDate=store.InsertDate?.AddHours(3);
                _db.Stors.Update(store);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore([FromBody] Store store)
        {
            if (UniqExists(store.IMEI))
            {
                return BadRequest();

            }
            else
            {
                var Available = _db.lokups.Where(x => x.Name == "متوفر" || x.Name == "Available").Select(x => x.Id).FirstOrDefault();
                store.LkpStatusId = Available;
                store.InsertDate = store.InsertDate?.AddHours(3);

                _db.Stors.Add(store);

                await _db.SaveChangesAsync();

                return CreatedAtAction("GetStore", new { id = store.Id }, store);
            }
            
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Store>> DeleteStore(int id)
        {
            var store = await _db.Stors.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _db.Stors.Remove(store);
            await _db.SaveChangesAsync();

            return store;
        }

        private bool StoreExists(int id)
        {
            return _db.Stors.Any(e => e.Id == id);
        }

        private bool UniqExists(long id)
        {
            return _db.Stors.Any(e => e.IMEI == id);
        }
    }
}
