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
    public class APIConnectsController : ControllerBase
    {
        private readonly MyDataModel1DbContext _context;

        public APIConnectsController(MyDataModel1DbContext context)
        {
            _context = context;
        }

        // GET: api/APIConnects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIConnect>>> GetAPIConnectDb()
        {
          if (_context.APIConnectDb == null)
          {
              return NotFound();
          }
            return await _context.APIConnectDb.ToListAsync();
        }

        // GET: api/APIConnects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIConnect>> GetAPIConnect(int id)
        {
          if (_context.APIConnectDb == null)
          {
              return NotFound();
          }
            var aPIConnect = await _context.APIConnectDb.FindAsync(id);

            if (aPIConnect == null)
            {
                return NotFound();
            }

            return aPIConnect;
        }

        // Get ID Max
        [HttpGet]
        [Route("Maxid")]
        public async Task<ActionResult<APIConnect>> GetMaxId()
        {
            var maxIdModel = await _context.APIConnectDb.OrderByDescending(m => m.ConnId).FirstOrDefaultAsync();

            if (maxIdModel == null)
            {
                return NotFound();
            }

            return maxIdModel;
        }

        // PUT: api/APIConnects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIConnect(int id, APIConnect aPIConnect)
        {
            if (id != aPIConnect.ConnId)
            {
                return BadRequest();
            }

            _context.Entry(aPIConnect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIConnectExists(id))
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

        // POST: api/APIConnects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIConnect>> PostAPIConnect(APIConnect aPIConnect)
        {
          if (_context.APIConnectDb == null)
          {
              return Problem("Entity set 'MyDataModel1DbContext.APIConnectDb'  is null.");
          }
            _context.APIConnectDb.Add(aPIConnect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIConnect", new { id = aPIConnect.ConnId }, aPIConnect);
        }

        // DELETE: api/APIConnects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIConnect(int id)
        {
            if (_context.APIConnectDb == null)
            {
                return NotFound();
            }
            var aPIConnect = await _context.APIConnectDb.FindAsync(id);
            if (aPIConnect == null)
            {
                return NotFound();
            }

            _context.APIConnectDb.Remove(aPIConnect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIConnectExists(int id)
        {
            return (_context.APIConnectDb?.Any(e => e.ConnId == id)).GetValueOrDefault();
        }
    }
}
