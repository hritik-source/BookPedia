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

    public class LoginException:ApplicationException
    {
        public LoginException(string message):base( message)
        {
            
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class BookuserhritikController : ControllerBase
    {
        private readonly Ace42023Context _context;

        public BookuserhritikController(Ace42023Context context)
        {
            _context = context;
        }

        // GET: api/Bookuserhritik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookuserhritik>>> GetBookuserhritiks()
        {
          if (_context.Bookuserhritiks == null)
          {
              return NotFound();
          }
            return await _context.Bookuserhritiks.ToListAsync();
        }


        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Bookuserhritik>> Login(Bookuserhritik bu)
        {
            var name = bu.Uname;
            var pass = bu.Password;
            
            var result = await _context.Bookuserhritiks.SingleOrDefaultAsync((e) => e.Uname == name && e.Password == pass);
            if (result == null)
                return BadRequest(new Exception("Invalid Username or Password"));
            return Ok(result);

        }


        // GET: api/Bookuserhritik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookuserhritik>> GetBookuserhritik(int id)
        {
          if (_context.Bookuserhritiks == null)
          {
              return NotFound();
          }
            var bookuserhritik = await _context.Bookuserhritiks.FindAsync(id);

            if (bookuserhritik == null)
            {
                return NotFound();
            }

            return bookuserhritik;
        }

        // PUT: api/Bookuserhritik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookuserhritik(int id, Bookuserhritik bookuserhritik)
        {
            if (id != bookuserhritik.Uid)
            {
                return BadRequest();
            }

            _context.Entry(bookuserhritik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookuserhritikExists(id))
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

        // POST: api/Bookuserhritik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Bookuserhritik>> PostBookuserhritik(Bookuserhritik bookuserhritik)
        {
            try{
                    if (_context.Bookuserhritiks == null)
                    {
                        return Problem("Entity set 'Ace42023Context.Bookuserhritiks'  is null.");
                    }
                    foreach(var item in _context.Bookuserhritiks)
                    {
                        if(bookuserhritik.Uname==item.Uname)
                           throw new LoginException("Enter A Unique Username, Already Taken");
                    }
                        _context.Bookuserhritiks.Add(bookuserhritik);
                        await _context.SaveChangesAsync();
                }
            catch(Exception e)
            {
                return Conflict(e.Message);
            }

            return CreatedAtAction("GetBookuserhritik", new { id = bookuserhritik.Uid }, bookuserhritik);
        }

        // DELETE: api/Bookuserhritik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookuserhritik(int id)
        {
            if (_context.Bookuserhritiks == null)
            {
                return NotFound();
            }
            var bookuserhritik = await _context.Bookuserhritiks.FindAsync(id);
            if (bookuserhritik == null)
            {
                return NotFound();
            }

            _context.Bookuserhritiks.Remove(bookuserhritik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookuserhritikExists(int id)
        {
            return (_context.Bookuserhritiks?.Any(e => e.Uid == id)).GetValueOrDefault();
        }
    }
}
