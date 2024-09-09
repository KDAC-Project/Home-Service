using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public ServicesController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> GetServices()
        {
            var services = _context.Services
                .Select(s => new ServiceDto
                {
                    ServiceID = s.ServiceID,
                    Description = s.Description,
                    CategoryID = s.CategoryID
                })
                .ToList();

            return Ok(services);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public ActionResult<ServiceDto> GetService(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            var serviceDto = new ServiceDto
            {
                ServiceID = service.ServiceID,
                Description = service.Description,
                CategoryID = service.CategoryID
            };

            return Ok(serviceDto);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public IActionResult PutService(int id, ServiceDto serviceDto)
        {
            if (id != serviceDto.ServiceID)
            {
                return BadRequest();
            }

            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            service.Description = serviceDto.Description;
            service.CategoryID = serviceDto.CategoryID;

            _context.Entry(service).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Services
        [HttpPost]
        public ActionResult<Service> PostService(ServiceDto serviceDto)
        {
            var service = new Service
            {
                Description = serviceDto.Description,
                CategoryID = serviceDto.CategoryID
            };

            _context.Services.Add(service);
            _context.SaveChanges();

            return CreatedAtAction("GetService", new { id = service.ServiceID }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
