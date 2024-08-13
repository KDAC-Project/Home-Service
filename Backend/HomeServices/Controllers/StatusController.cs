using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public StatusController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public ActionResult<IEnumerable<StatusDto>> GetStatus()
        {
            var statuses = _context.Status
                .Select(s => new StatusDto
                {
                    StatusID = s.StatusID,
                    StatusDesc = s.StatusDesc
                })
                .ToList();

            return Ok(statuses);
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public ActionResult<StatusDto> GetStatus(int id)
        {
            var status = _context.Status.Find(id);

            if (status == null)
            {
                return NotFound();
            }

            var statusDto = new StatusDto
            {
                StatusID = status.StatusID,
                StatusDesc = status.StatusDesc
            };

            return Ok(statusDto);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public IActionResult PutStatus(int id, StatusDto statusDto)
        {
            if (id != statusDto.StatusID)
            {
                return BadRequest();
            }

            var status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }

            status.StatusDesc = statusDto.StatusDesc;

            _context.Entry(status).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Status
        [HttpPost]
        public ActionResult<Status> PostStatus(StatusDto statusDto)
        {
            var status = new Status
            {
                StatusDesc = statusDto.StatusDesc
            };

            _context.Status.Add(status);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStatus), new { id = status.StatusID }, status);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            var status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            _context.SaveChanges();

            return NoContent();
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusID == id);
        }
    }
}
