using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccessData;
using Domain.Entities;

namespace PetsLife_Store.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public TestAPIsController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/TestAPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAPI>>> GetAPI()
        {
            return await _context.API.ToListAsync();
        }

        // GET: api/TestAPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAPI>> GetTestAPI(int id)
        {
            var testAPI = await _context.API.FindAsync(id);

            if (testAPI == null)
            {
                return NotFound();
            }

            return testAPI;
        }

        // PUT: api/TestAPIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAPI(int id, TestAPI testAPI)
        {
            if (id != testAPI.Id)
            {
                return BadRequest();
            }

            _context.Entry(testAPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAPIExists(id))
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

        // POST: api/TestAPIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestAPI>> PostTestAPI(TestAPI testAPI)
        {
            _context.API.Add(testAPI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestAPI", new { id = testAPI.Id }, testAPI);
        }

        // DELETE: api/TestAPIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAPI(int id)
        {
            var testAPI = await _context.API.FindAsync(id);
            if (testAPI == null)
            {
                return NotFound();
            }

            _context.API.Remove(testAPI);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAPIExists(int id)
        {
            return _context.API.Any(e => e.Id == id);
        }
    }
}
