using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobiTech.Data;
using MobiTech.Data.Models.Model;
using MobiTech.DataView;

namespace MobiTech.Controllers
{
    //[Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
   // [ApiController]
    public class LokupsController : ControllerBase
    {
        private readonly MobiDbContext _db;
        private IMapper _mapper;
        public LokupsController(MobiDbContext context ,IMapper _mapper)
        {
            _db = context;
        }

        // GET: api/Lokups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lokups>>> Getlokups()
        {
            return await _db.lokups.ToListAsync();
        }



        // GET: Lokup and lokuptype
        [HttpGet("GetLookup")]
        public async Task<ActionResult<IEnumerable<LokupsVw>>> GetLookup()
        {
            var Type = _db.lokups.Include(x => x.Type);
            var data = await _db.lokups?.Select(x=>
            new LokupsVw
            { 
            Id =x.Id,
            Name =x.Name,
            Group=x.Type.Name,
            
            }).OrderBy(x=>x.Group).ToListAsync();

            //var result = _mapper.Map<List<Lokups>>(data);

            return data;
        }
        // GET: AllType
        [HttpGet("GetAllType")]
        public async Task<ActionResult<IEnumerable<LkpTypeVw>>> GetAllType()
        {
            var data = await _db.lkpTypes?.Select(x =>
            new LkpTypeVw
            {
                TypeId = x.Id,
                Name = x.Name,
            }).ToListAsync();

            //var result = _mapper.Map<List<Lokups>>(data);

            return data;
        }



        // GET: api/Lokups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lokups>> GetLokups(int id)
        {
            var lokups = await _db.lokups.FindAsync(id);

            if (lokups == null)
            {
                return NotFound();
            }

            return lokups;
        }

        // PUT: api/Lokups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokups(int id, [FromBody] Lokups lokups)
        {
            if (id != lokups.Id)
            {
                return BadRequest();
            }

            _db.Entry(lokups).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokupsExists(id))
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

        // POST: api/Lokups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Lokups>> PostLokups([FromBody] Lokups lokups)
        {
            _db.lokups.Add(lokups);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetLokups", new { id = lokups.Id }, lokups);
        }

        // DELETE: api/Lokups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lokups>> DeleteLokups(int id)
        {
            var lokups = await _db.lokups.FindAsync(id);
            if (lokups == null)
            {
                return NotFound();
            }

            _db.lokups.Remove(lokups);
            await _db.SaveChangesAsync();

            return lokups;
        }

        private bool LokupsExists(int id)
        {
            return _db.lokups.Any(e => e.Id == id);
        }
    }
}
