using Microsoft.AspNetCore.Mvc;
using TravelTracker.Api.Data;
using TravelTracker.Api.Models;

namespace TravelTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        // GET: api/Visits
        [HttpGet]
        public ActionResult<IEnumerable<Visit>> GetVisits()
        {
            return Ok(VisitStore.Visits);
        }
        
        // GET: api/Visits/5
        [HttpGet("{id}")]
        public ActionResult<Visit> GetVisit(int id)
        {
            var visit = VisitStore.Visits.FirstOrDefault(v => v.Id == id);

            if (visit == null)
            {
                return NotFound();
            }
            return Ok(visit);
        }
        
        // POST: api/Visits
        [HttpPost]
        public ActionResult<Visit> PostVisit([FromBody] Visit visit)
        {
            var newId = VisitStore.Visits.Max(v => v.Id) + 1;
            visit.Id = newId;

            VisitStore.Visits.Add(visit);

            return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
        }
        
        // PUT: api/Visits/2
        [HttpPut("{id}")]
        public IActionResult PutVisit(int id, [FromBody] Visit visit)
        {
            var existingVisit = VisitStore.Visits.FirstOrDefault(v => v.Id == id);
            if (existingVisit == null)
            {
                return NotFound();
            }
            
            existingVisit.Country = visit.Country;
            existingVisit.City = visit.City;
            existingVisit.YearVisited = visit.YearVisited;
            
            return NoContent();
        }
        
        // DELETE: api/Visits/2
        [HttpDelete("{id}")]
        public IActionResult DeleteVisit(int id)
        {
            var visit = VisitStore.Visits.FirstOrDefault(v => v.Id == id);
            if (visit == null)
            {
                return NotFound();
            }
            
            VisitStore.Visits.Remove(visit);
            
            return NoContent();
        }
    }
}
