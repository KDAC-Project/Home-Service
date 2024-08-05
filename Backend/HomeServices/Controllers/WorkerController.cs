using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using HomeServices.Model;
using HomeServices.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [EnableCors("policy")]
    // public class UsersController : ControllerBase
    public class WorkerController : ControllerBase
    {
        private HomeServiceContext _Context = null;

        public WorkerController(HomeServiceContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return _Context.Workers.ToList();
        }

        [HttpGet("{id}")]
        public WorkerDTO Get(int id)
        {
            Worker worker = _Context.Workers.Find(id);
            WorkerDTO workerDTO = new WorkerDTO();
            workerDTO.WorkerID = worker.WorkerID;
            workerDTO.Name = worker.Name;
            workerDTO.Email = worker.Email;
            workerDTO.Phone = worker.Phone;
            workerDTO.Skill = worker.Skill;
            return workerDTO;
        }

        [HttpPost]
        public string Post([FromBody] WorkerDTO workerDTO)
        {
            Worker w = new Worker();
            // w.WorkerID = workerDTO.WorkerID;
             w.Name = workerDTO.Name;
             w.Email = workerDTO.Email;
             w.Phone = workerDTO.Phone;
             w.Skill = workerDTO.Skill;
             w.Password = workerDTO.Password;
            _Context.Workers.Add(w);

            _Context.SaveChanges();
            return "Worker Added Successfully";

            //WorkerDTO dTO = new WorkerDTO();
            //foreach (var worker in _Context.Workers)
            //{
            //    if (worker.Email.Equals(loginWorker.Email) && worker.Password.Equals(loginWorker.Password))
            //    {
            //        Console.WriteLine(worker);
            //        dTO.Email = worker.Email;
            //        dTO.Name = worker.Name;
            //        dTO.Phone = worker.Phone;
            //        dTO.Skill = worker.Skill;
            //    }
            //}
            
        }
        

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Worker workerUpdated)
        {
            Worker workerToUpdate = _Context.Workers.Find(id);
            workerToUpdate.Name = workerUpdated.Name;
            workerToUpdate.Email = workerUpdated.Email;
            workerToUpdate.Phone = workerUpdated.Phone;
            workerToUpdate.Skill = workerUpdated.Skill; 

            _Context.SaveChanges();
            return "Updated Successfully";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Worker workerToBeDeleted = _Context.Workers.Find(id);
            _Context.Workers.Remove(workerToBeDeleted);
            _Context.SaveChanges();
            return "Deleted Successfully";
        }

    }
}
