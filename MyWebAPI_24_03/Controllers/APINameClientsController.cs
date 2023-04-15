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
    public class APINameClientsController : ControllerBase
    {
        private readonly MyDataModel1DbContext _context;

        public APINameClientsController(MyDataModel1DbContext context)
        {
            _context = context;
        }

        // GET: api/APINameClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APINameClient>>> GetAPINameClientDb()
        {
          if (_context.APINameClientDb == null)
          {
              return NotFound();
          }
            return await _context.APINameClientDb.ToListAsync();
        }

        // GET: api/APINameClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APINameClient>> GetAPINameClient(int id)
        {
          if (_context.APINameClientDb == null)
          {
              return NotFound();
          }
            var aPINameClient = await _context.APINameClientDb.FindAsync(id);

            if (aPINameClient == null)
            {
                return NotFound();
            }

            return aPINameClient;
        }
        //Get ID Max
        [HttpGet]
        [Route("Maxid")]
        public async Task<ActionResult<APINameClient>> GetMaxId()
        {
            var maxIdModel = await _context.APINameClientDb.OrderByDescending(m => m.NameId).FirstOrDefaultAsync();

            if (maxIdModel == null)
            {
                return NotFound();
            }

            return maxIdModel;
        }
        // PUT: api/APINameClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPINameClient(int id, APINameClient aPINameClient)
        {
            if (id != aPINameClient.NameId)
            {
                return BadRequest();
            }

            _context.Entry(aPINameClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APINameClientExists(id))
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

        // POST: api/APINameClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APINameClient>> PostAPINameClient(APINameClient aPINameClient)
        {
          if (_context.APINameClientDb == null)
          {
              return Problem("Entity set 'MyDataModel1DbContext.APINameClientDb'  is null.");
          }
            _context.APINameClientDb.Add(aPINameClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPINameClient", new { id = aPINameClient.NameId }, aPINameClient);
        }

        // DELETE: api/APINameClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPINameClient(int id)
        {
            if (_context.APINameClientDb == null)
            {
                return NotFound();
            }
            var aPINameClient = await _context.APINameClientDb.FindAsync(id);
            if (aPINameClient == null)
            {
                return NotFound();
            }

            _context.APINameClientDb.Remove(aPINameClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APINameClientExists(int id)
        {
            return (_context.APINameClientDb?.Any(e => e.NameId == id)).GetValueOrDefault();
        }
    }
}
