using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTracker.Api.Data;
using TravelTracker.Api.Models;

namespace TravelTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly DataContext _context;

        public VisitsController(DataContext context)
        {
            _context = context;
        }
        
        // GET: api/Visits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            var visits = await _context.Visits.ToListAsync();
            return Ok(visits);
        }
        
        // GET: api/Visits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);

            if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }
        
        // POST: api/Visits
        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit([FromBody] Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
        }
        
        // PUT: api/Visits/2
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVisit(int id, [FromBody] Visit visit)
        {
            if (id != visit.Id)
            {
                return BadRequest();
            }

            _context.Entry(visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Visits.Any(v => v.Id == id))
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
        
        // DELETE: api/Visits/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
