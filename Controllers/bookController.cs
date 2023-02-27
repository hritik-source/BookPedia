using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using secondapi.Models;

namespace secondapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookController : ControllerBase
    {
        private readonly Ace42023Context _context;

        public bookController(Ace42023Context context)
        {
            _context = context;
        }

        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookhritik>>> GetBookhritiks()
        {
          if (_context.Bookhritiks == null)
          {
              return NotFound();
          }
            return await _context.Bookhritiks.ToListAsync();
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookhritik>> GetBookhritik(int id)
        {
          if (_context.Bookhritiks == null)
          {
              return NotFound();
          }
            var bookhritik = await _context.Bookhritiks.FindAsync(id);

            if (bookhritik == null)
            {
                return NotFound();
            }

            return bookhritik;
        }

        // PUT: api/Emp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookhritik(int id, Bookhritik bookhritik)
        {
            if (id != bookhritik.Bookid)
            {
                return BadRequest();
            }

            _context.Entry(bookhritik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookhritikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(bookhritik);
        }

        // POST: api/Emp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookhritik>> PostBookhritik(Bookhritik bookhritik)
        {
          if (_context.Bookhritiks == null)
          {
              return Problem("Entity set 'Ace42023Context.Bookhritiks'  is null.");
          }
            _context.Bookhritiks.Add(bookhritik);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookhritikExists(bookhritik.Bookid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookhritik", new { id = bookhritik.Bookid }, bookhritik);
        }

        // DELETE: api/Emp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookhritik(int id)
        {
            if (_context.Bookhritiks == null)
            {
                return NotFound();
            }
            var bookhritik = await _context.Bookhritiks.FindAsync(id);
            if (bookhritik == null)
            {
                return NotFound();
            }

            _context.Bookhritiks.Remove(bookhritik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookhritikExists(int id)
        {
            return (_context.Bookhritiks?.Any(e => e.Bookid == id)).GetValueOrDefault();
        }
    }
}
