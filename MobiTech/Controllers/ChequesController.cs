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
    // [Authorize(Roles = "Manager,Empolyee")]
    [Route("api/[controller]")]
   // [ApiController]
    public class ChequesController : ControllerBase
    {
        private readonly MobiDbContext _db;

        public ChequesController(MobiDbContext context)
        {
            _db = context;
        }

        // GET: api/Cheques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChequeVw>>> Getcheques()
        {
            ////var ChStatus = _context.cheques.Include(x => x.ChStatus);
            //var SalCustomer = _context.cheques.Include(x => x.SalCustomer);



            var compareDate = DateTime.Now;
            var StatusIdF = _db.lokups.Where(x => x.Name == "غير مستحق" || x.Name == "undue").Select(x => x.Id).FirstOrDefault();
            var StatusIdT = _db.lokups.Where(x => x.Name == "مستحق" || x.Name == "payable").Select(x => x.Id).FirstOrDefault();
            var ChequeDate = _db.cheques?.Where(x => x.Date <= compareDate && x.ChStatusId == StatusIdF).ToList();
            ChequeDate.ForEach(x => x.ChStatusId = StatusIdT);
            await _db.SaveChangesAsync();




            var data = await _db.cheques?.Select(x => new ChequeVw
            {
                Id = x.Id,
                Customers = x.Customer.Customer,
                IMEI=x.Customer.IMEI,
                Owner = x.Owner,
                ChequeNo = x.ChequeNo,
                Bank = x.Bank,
                Date = x.Date,
                CheqDate = string.Format("{0:MM-dd-yyyy}", x.Date),
                Amount = x.Amount,
                Status = x.ChStatus.Name



            }).OrderBy(x => x.Status == "مستحق" ? 0 : 1).ThenByDescending(x=>x.Date).ToListAsync();
            return  data;
        }



        //Get:api/Cheques/getStatus
        [HttpGet("getStatus")]
        public async Task<IEnumerable<LokupsVw>> getStatus()
        {
            var id = _db.lkpTypes.Where(x => x.Name == "ChequeCase").Select(x => x.Id).FirstOrDefault();
            var TypeList = await _db.lokups.Where(x => x.TypeId == id).Select(x =>
                new LokupsVw
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    Name = x.Name,
                }).ToListAsync();

            return TypeList;
        }

        [HttpGet("getChequeStatus")]
        public async Task<IEnumerable<object>> getSaleStatus()
        {
            var data = _db.cheques.Where(x=>x.ChStatus.Name=="غير مستحق"||x.ChStatus.Name=="مرتجع"||x.ChStatus.Name=="تم الصرف").GroupBy(x => x.ChStatus.Name).Select(n => new
            {
                Name = n.Key,
                Value = n.Count()
            }).OrderByDescending(y => y.Name).ToList();

            return data;
        }

        //Get:api/Cheques/getCustomer
        [HttpGet("getCustomer")]
        public async Task<IEnumerable<SaleVw>> getCustomer()
        {
            var id = _db.lokups.Where(x => x.Name == "شيكات" ||x.Name=="Cheque").Select(x => x.Id).FirstOrDefault();
            var TypeList = await _db.Sales.Where(x => x.LkpMethodId == id).Select(x =>
                new SaleVw
                {
                    Id = x.Id,
                    
                   Customer=x.Customer +" |  "+ x.IMEI +"   |   " + x.Mobile,
                }).OrderBy(x => x.Customer).ToListAsync();

            return TypeList;
        }

        //Get:api/Cheques/getTotal
        [HttpGet("getTotal/{id}/{amount}")]
        public async Task<String> getTotal(int id,int amount)
        {
            var ValidTotal=" ";
            var MobileCost = _db.Sales.Where(x => x.Id == id).Select(x => x.Price).FirstOrDefault();

            var TotalPayments =  _db.cheques.Where(x => x.CustomerId == id).Select(x => x.Amount).Sum();
            if(TotalPayments + amount > MobileCost)
            {
                ValidTotal = "اصبحت قيمة الدفعات اكبر من سعر الهاتف المدخل *";
                return ValidTotal;
            }
            else
            {
                ValidTotal = null;
            }
            return ValidTotal;
        }
        




     


        // GET: api/Cheques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cheque>> GetCheque(int id)
        {
            var cheque = await _db.cheques.FindAsync(id);

            if (cheque == null)
            {
                return NotFound();
            }

            return cheque;
        }

        // PUT: api/Cheques/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheque(int id, [FromBody] Cheque cheque)
        {
            if (id != cheque.Id)
            {
                return BadRequest();
            }
            cheque.Date = cheque.Date.AddHours(3);
            _db.Entry(cheque).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeExists(id))
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

        // POST: api/Cheques
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cheque>> PostCheque([FromBody] Cheque cheque)
        {
            cheque.Date = cheque.Date.AddHours(3);

            _db.cheques.Add(cheque);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetCheque", new { id = cheque.Id }, cheque);
        }

        // DELETE: api/Cheques/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cheque>> DeleteCheque(int id)
        {
            var cheque = await _db.cheques.FindAsync(id);
            if (cheque == null)
            {
                return NotFound();
            }

            _db.cheques.Remove(cheque);
            await _db.SaveChangesAsync();

            return cheque;
        }

        private bool ChequeExists(int id)
        {
            return _db.cheques.Any(e => e.Id == id);
        }
    }
}
