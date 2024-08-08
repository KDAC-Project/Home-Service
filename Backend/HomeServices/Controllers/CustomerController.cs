using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      //private readonly HomeServiceContext _context;
         HomeServiceContext _context;
        public CustomerController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address
                })
                .ToList();

            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = new CustomerDto
            {
                CustomerID = customer.CustomerID,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };

            return Ok(customerDto);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.CustomerID)
            {
                return BadRequest();
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.Phone = customerDto.Phone;
            customer.Address = customerDto.Address;

            _context.Entry(customer).State = EntityState.Modified;

            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> PostCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
                Password =customerDto.Password// Replace with actual hashing logic
            };
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            //var createdCustomerDto = new CustomerDto
            //{
            //    CustomerID = customer.CustomerID,
            //    Name = customer.Name,
            //    Email = customer.Email,
            //    Phone = customer.Phone,
            //    Address = customer.Address
            //};
            return Ok("success");
            //return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, createdCustomerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("Login")]

        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid Login Request");
            }

            var customer = _context.Customers.FirstOrDefault(c => c.Email == loginDto.Email);

            if (customer == null || customer.Password != loginDto.Password)
            {
                return Unauthorized("Invalid Email or password");

            }
            //return CreatedAtAction(nameof(GetCustomer), customer);
            return Ok("Login Successful");

        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
