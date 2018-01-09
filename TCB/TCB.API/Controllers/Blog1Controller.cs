using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCB.API.Models;
using Microsoft.AspNetCore.Cors;

namespace TCB.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Blog1")]
    public class Blog1Controller : Controller
    {
        private readonly TestAppDBContext _context;

        public Blog1Controller(TestAppDBContext context)
        {
            _context = context;
        }

        // GET: api/Blog1
        [HttpGet]
        public IEnumerable<Blog1> GetBlog1()
        {
            return _context.Blog1;
        }

        // GET: api/Blog1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog1([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog1 = await _context.Blog1.SingleOrDefaultAsync(m => m.BlogId == id);

            if (blog1 == null)
            {
                return NotFound();
            }

            return Ok(blog1);
        }

        // PUT: api/Blog1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog1([FromRoute] int id, [FromBody] Blog1 blog1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog1.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blog1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Blog1Exists(id))
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

        // POST: api/Blog1
        [HttpPost]
        public async Task<IActionResult> PostBlog1([FromBody] Blog1 blog1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Blog1.Add(blog1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Blog1Exists(blog1.BlogId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBlog1", new { id = blog1.BlogId }, blog1);
        }

        // DELETE: api/Blog1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog1([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog1 = await _context.Blog1.SingleOrDefaultAsync(m => m.BlogId == id);
            if (blog1 == null)
            {
                return NotFound();
            }

            _context.Blog1.Remove(blog1);
            await _context.SaveChangesAsync();

            return Ok(blog1);
        }

        private bool Blog1Exists(int id)
        {
            return _context.Blog1.Any(e => e.BlogId == id);
        }
    }
}