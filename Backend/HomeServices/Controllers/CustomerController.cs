using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase

    {
        HomeServiceContext context = null;

        public CustomerController(HomeServiceContext _context)
        {
            context = _context;
        }

        // GET: api/<UserController>2222
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return context.Customers.ToList() ;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            Customer customer = context.Customers.Find(id);
            CustomerDto dto = new CustomerDto();
            dto.Name = customer.Name;
            dto.Email = customer.Email;
            dto.Phone = customer.Phone;
            dto.Address = customer.Address;
            dto.Password = customer.Password;
            return dto;
        }



         [HttpPost]
        public void Post([FromBody] CustomerDto dto)
        {
            Customer c = new Customer();
            c.Name = dto.Name;
            c.Email = dto.Email;
            c.Phone = dto.Phone;
            c.Address = dto.Address;
            c.Password = dto.Password;
            context.Customers.Add(c);
            context.SaveChanges();


        }

        //PUT api/<UserController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] CustomerDto customer)
        {
            context.Customers.Find(id);
            Customer custoEdit = context.Customers.Find(id);

            custoEdit.Name = customer.Name;
            custoEdit.Email = customer.Email;
            custoEdit.Password = customer.Password;
            custoEdit.Phone = customer.Phone;
            custoEdit.Address = customer.Address;
            context.SaveChanges();
            return "Updated Successfully";
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer custoDelete = context.Customers.Find(id);
            context.Customers.Remove(custoDelete);
            context.SaveChanges();
        }
    }
}
