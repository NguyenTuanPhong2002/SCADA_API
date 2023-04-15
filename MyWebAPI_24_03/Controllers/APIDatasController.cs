using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI_24_03.Data;
using MyWebAPI_24_03.Model1;

namespace MyWebAPI_24_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIDatasController : ControllerBase
    {
        private readonly MyDataModel1DbContext _context;

        public APIDatasController(MyDataModel1DbContext context)
        {
            _context = context;
        }

        // GET: api/APIDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIData>>> GetAPIDataDb()
        {
          if (_context.APIDataDb == null)
          {
              return NotFound();
          }
            return await _context.APIDataDb.ToListAsync();
        }

        // GET: api/APIDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIData>> GetAPIData(int id)
        {
          if (_context.APIDataDb == null)
          {
              return NotFound();
          }
            var aPIData = await _context.APIDataDb.FindAsync(id);

            if (aPIData == null)
            {
                return NotFound();
            }

            return aPIData;
        }
        // Get ID Max
        [HttpGet]
        [Route("Maxid")]
        public async Task<ActionResult<APIData>> GetMaxId()
        {
            var maxIdModel = await _context.APIDataDb.OrderByDescending(m => m.DataId).FirstOrDefaultAsync();

            if (maxIdModel == null)
            {
                return NotFound();
            }

            return maxIdModel;
        }
        // PUT: api/APIDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIData(int id, APIData aPIData)
        {
            if (id != aPIData.DataId)
            {
                return BadRequest();
            }

            _context.Entry(aPIData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIDataExists(id))
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

        // POST: api/APIDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIData>> PostAPIData(APIData aPIData)
        {
          if (_context.APIDataDb == null)
          {
              return Problem("Entity set 'MyDataModel1DbContext.APIDataDb'  is null.");
          }
            _context.APIDataDb.Add(aPIData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIData", new { id = aPIData.DataId }, aPIData);
        }

        // DELETE: api/APIDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIData(int id)
        {
            if (_context.APIDataDb == null)
            {
                return NotFound();
            }
            var aPIData = await _context.APIDataDb.FindAsync(id);
            if (aPIData == null)
            {
                return NotFound();
            }

            _context.APIDataDb.Remove(aPIData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIDataExists(int id)
        {
            return (_context.APIDataDb?.Any(e => e.DataId == id)).GetValueOrDefault();
        }
    }
}
