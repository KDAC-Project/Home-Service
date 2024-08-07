using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public WorkerController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public ActionResult<IEnumerable<WorkerDto>> GetWorkers()
        {
            var workers = _context.Workers
                .Select(w => new WorkerDto
                {
                    WorkerID = w.WorkerID,
                    Name = w.Name,
                    Email = w.Email,
                    Phone = w.Phone,
                    Skill = w.Skill
                })
                .ToList();

            return Ok(workers);
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public ActionResult<WorkerDto> GetWorker(int id)
        {
            var worker = _context.Workers.Find(id);

            if (worker == null)
            {
                return NotFound();
            }

            var workerDto = new WorkerDto
            {
                WorkerID = worker.WorkerID,
                Name = worker.Name,
                Email = worker.Email,
                Phone = worker.Phone,
                Skill = worker.Skill
            };

            return Ok(workerDto);
        }

        // PUT: api/Workers/5
        [HttpPut("{id}")]
        public IActionResult PutWorker(int id, WorkerDto workerDto)
        {
            if (id != workerDto.WorkerID)
            {
                return BadRequest();
            }

            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            worker.Name = workerDto.Name;
            worker.Email = workerDto.Email;
            worker.Phone = workerDto.Phone;
            worker.Skill = workerDto.Skill;

            _context.Entry(worker).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Workers
        [HttpPost]
        public ActionResult<WorkerDto> PostWorker(WorkerDto workerDto)
        {
            var worker = new Worker
            {
                Name = workerDto.Name,
                Email = workerDto.Email,
                Phone = workerDto.Phone,
                Skill = workerDto.Skill,
                Password = workerDto.Password,
            };

            _context.Workers.Add(worker);
            _context.SaveChanges();

            var createdWorkerDto = new WorkerDto
            {
                WorkerID = worker.WorkerID,
                Name = worker.Name,
                Email = worker.Email,
                Phone = worker.Phone,
                Skill = worker.Skill
            };

            return CreatedAtAction(nameof(GetWorker), new { id = worker.WorkerID }, createdWorkerDto);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWorker(int id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            _context.SaveChanges();

            return NoContent();
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.WorkerID == id);
        }
    }
}
