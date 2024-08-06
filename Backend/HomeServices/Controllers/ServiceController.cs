using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        HomeServiceContext context = null;

        public ServiceController(HomeServiceContext _context)
        {
            context = _context;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return context.Services.ToList();
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public Service Get(int id)
        {

            return context.Services.Find(id);

        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post([FromBody] ServiceDto servicedto)
        {
            Service s = new Service();
            s.ServiceID = servicedto.ServiceID;
            s.Description = servicedto.Description;
            context.Services.Add(s);  
            context.SaveChanges();
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] ServiceDto serviceDto)
        {
            context.Services.Find(id);
            Service serviceEdit = context.Services.Find(id);
            serviceEdit.Description = serviceDto.Description;
            context.SaveChanges();
            return "Updated Successfully";

        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service serviceDelete = context.Services.Find(id);
            context.Services.Remove(serviceDelete);
            context.SaveChanges();
        }
    }
}
