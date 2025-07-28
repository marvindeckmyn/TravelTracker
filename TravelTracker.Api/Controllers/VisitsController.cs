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
        public IEnumerable<Visit> Get()
        {
            return VisitStore.Visits;
        }
        
        // GET: api/Visits/5
        [HttpGet("{id}")]
        public ActionResult<Visit> Get(int id)
        {
            var visit = VisitStore.Visits.FirstOrDefault(v => v.Id == id);

            if (visit == null)
            {
                return NotFound();
            }
            
            return Ok(visit);
        }
    }
}
