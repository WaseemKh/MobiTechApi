using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobiTech.Data;
using MobiTech.Data.Models.Model;
using MobiTech.DataView;

namespace MobiTech.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly MobiDbContext _db;

        public SaleController(MobiDbContext context)
        {
            _db = context;
        }

        // GET: api/Sale
        [HttpGet]
        public async Task<IEnumerable<SaleVw>> GetSales()
        {
            var LkpMethod = _db.Sales.Include(x => x.LkpMethod);
            var data = await _db.Sales?.Select(x=>
            new  SaleVw
            { 
                Id=x.Id,
            IMEI=x.IMEI,
           
            Date =    string.Format("{0:MM-dd-yyyy}", x.DateSale),
            Price=x.Price,
            Name=x.LkpMethod.Name,
                Email = x.Email ?? "لم يتم العثور على ايميل",
                Customer = x.Customer,
            Mobile=x.Mobile


            }).ToListAsync();
            return data;
        }
        [HttpGet("getSaleStatus")]
        public async Task<IEnumerable<object>> getSaleStatus()
        {
            var data = _db.Sales.GroupBy(x => x.LkpMethod.Name).Select(n => new
            {
                Name = n.Key,
                Value = n.Count()
            }).OrderByDescending(y => y.Name).ToList();

            return data;
        }

        [HttpGet("getSalecount")]
        public async Task<ActionResult<IEnumerable<object>>> getSalecount()
        {
         
            var Series = _db.Sales.Where(x=>x.DateSale!=null).GroupBy(y => new { y.DateSale.Value.Month, y.DateSale.Value.Year }).Select(s => new
            {
                Year=s.Key.Year,
                
                   Name = s.Key.Month,
                Value = s.Count(),

            }).ToList();
            var analystic = Series.GroupBy(x => x.Year).Select(x => new
            {
              Name=  x.Key,
                Series = Series.Where(z=>z.Year==x.Key)?.ToArray(),
            }).ToList();
                return analystic;
        }

        // GET: api/Sale/CustomReport/5/Date

        [HttpGet("CustomReport/{id}/{imei}/{DateF?}/{DateT?}")]
        public async Task<IEnumerable<SaleVw>> CustomReport(int Id,long imei, DateTime? DateF, DateTime? DateT)
        {
          

            var Data = await _db.Sales.Where(x => (x.LkpMethodId == Id || Id == 0) && (x.IMEI==imei||imei==0) && (!DateF.HasValue || x.DateSale >= DateF) && (!DateT.HasValue || x.DateSale <= DateT.Value.AddDays(1))).
                Select(x=>new SaleVw
                { 
                    Id=x.Id,
            Customer=x.Customer,
            Mobile=x.Mobile,
            IMEI=x.IMEI,
            Cost= _db.Stors.Where(y=>y.IMEI==x.IMEI).Select(x=>x.Price).FirstOrDefault(),
            Price=x.Price,
            Date = string.Format("{0:MM-dd-yyyy}", x.DateSale),
            Name=x.LkpMethod.Name

                }).OrderByDescending(x=>x.Price).ToListAsync();


            return Data;
        }

        // GET: api/Sale/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _db.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sale/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, [FromBody] Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _db.Entry(sale).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sale
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale([FromBody] Sale sale)
        {
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();
            var Imei = sale.IMEI;
            var MobiSold = _db.Stors.SingleOrDefault(x => x.IMEI == Imei);
            if (MobiSold.Qty == 1)
            {
                var Id = _db.lokups.Where(x => x.Name == "مباع" || x.Name == "Sold").Select(x => x.Id).FirstOrDefault();
                MobiSold.LkpStatusId = Id;
                _db.Stors.Update(MobiSold);
                await _db.SaveChangesAsync();
            }
            else
            {
                MobiSold.Qty = MobiSold.Qty - 1;
                _db.Stors.Update(MobiSold);
                await _db.SaveChangesAsync();

            }
            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);


        }

        // DELETE: api/Sale/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(int id)
        {
            var sale = await _db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
           
            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();
            var Imei = sale.IMEI;
            var MobiSold = _db.Stors.SingleOrDefault(x => x.IMEI == Imei);
            var Id = _db.lokups.Where(x => x.Name == "متوفر" || x.Name == "Available").Select(x => x.Id).FirstOrDefault();
            MobiSold.LkpStatusId = Id;
            _db.Stors.Update(MobiSold);

            await _db.SaveChangesAsync();
            return sale;
        }

        private bool SaleExists(int id)
        {
            return _db.Sales.Any(e => e.Id == id);
        }
    }
}
