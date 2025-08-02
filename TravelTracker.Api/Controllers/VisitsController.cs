using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTracker.Application;
using TravelTracker.Infrastructure;
using TravelTracker.Domain;

namespace TravelTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitRepository _visitRepository;

        public VisitsController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        
        // GET: api/Visits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            var visits = await _visitRepository.GetAllAsync();
            return Ok(visits);
        }
        
        // GET: api/Visits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            var visit = await _visitRepository.GetByIdAsync(id);
            if (visit == null) return NotFound();
            return Ok(visit);
        }
        
        // POST: api/Visits
        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit(Visit visit)
        {
            var createdVisit = await _visitRepository.AddAsync(visit);
            return CreatedAtAction(nameof(GetVisit), new { id = createdVisit.Id }, createdVisit);
        }
        
        // PUT: api/Visits/2
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVisit(int id, Visit visit)
        {
            if (id != visit.Id) return BadRequest();
            await _visitRepository.UpdateAsync(visit);
            return NoContent();
        }
        
        // DELETE: api/Visits/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            var visit = await _visitRepository.GetByIdAsync(id);
            if (visit == null) return NotFound();
            
            await _visitRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
