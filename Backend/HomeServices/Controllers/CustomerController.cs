//using HomeServices.Dto;
//using HomeServices.Model;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HomeServices.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {

//      //private readonly HomeServiceContext _context;
//         HomeServiceContext _context;
//        public CustomerController(HomeServiceContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Customers
//        [HttpGet]
//        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
//        {
//            var customers = _context.Customers
//                .Select(c => new CustomerDto
//                {
//                    CustomerID = c.CustomerID,
//                    Name = c.Name,
//                    Email = c.Email,
//                    Phone = c.Phone,
//                    Address = c.Address
//                })
//                .ToList();

//            return Ok(customers);
//        }

//        // GET: api/Customers/5
//        [HttpGet("{id}")]
//        public ActionResult<CustomerDto> GetCustomer(int id)
//        {
//            var customer = _context.Customers.Find(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            var customerDto = new CustomerDto
//            {
//                CustomerID = customer.CustomerID,
//                Name = customer.Name,
//                Email = customer.Email,
//                Phone = customer.Phone,
//                Address = customer.Address
//            };

//            return Ok(customerDto);
//        }

//        // PUT: api/Customers/5
//        [HttpPut("{id}")]
//        public IActionResult PutCustomer(int id, CustomerDto customerDto)
//        {
//            if (id != customerDto.CustomerID)
//            {
//                return BadRequest();
//            }

//            var customer = _context.Customers.Find(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            customer.Name = customerDto.Name;
//            customer.Email = customerDto.Email;
//            customer.Phone = customerDto.Phone;
//            customer.Address = customerDto.Address;

//            _context.Entry(customer).State = EntityState.Modified;

//            _context.SaveChanges();

//            return NoContent();
//        }

//        // POST: api/Customers
//        [HttpPost]
//        public ActionResult<Customer> PostCustomer(CustomerDto customerDto)
//        {
//            var customer = new Customer
//            {
//                Name = customerDto.Name,
//                Email = customerDto.Email,
//                Phone = customerDto.Phone,
//                Address = customerDto.Address,
//                Password = "hashedPassword" // Replace with actual hashing logic
//            };

//            _context.Customers.Add(customer);
//            _context.SaveChanges();

//            var createdCustomerDto = new CustomerDto
//            {
//                CustomerID = customer.CustomerID,
//                Name = customer.Name,
//                Email = customer.Email,
//                Phone = customer.Phone,
//                Address = customer.Address
//            };

//            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, createdCustomerDto);
//        }

//        // DELETE: api/Customers/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteCustomer(int id)
//        {
//            var customer = _context.Customers.Find(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customer);
//            _context.SaveChanges();

//            return NoContent();
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.Customers.Any(e => e.CustomerID == id);
//        }
//    }
//}



using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly HomeServiceContext _context;
        private readonly IConfiguration _config;

        public CustomerController(HomeServiceContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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
                return NotFound(new { message = "Customer not found" });
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
                return BadRequest(new { message = "Customer ID mismatch" });
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found" });
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
        public ActionResult<CustomerDto> PostCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest(new { message = "Invalid customer data" });
            }

            // Hash the password before storing it (Replace with actual hashing logic)
            var hashedPassword = HashPassword("password"); // Placeholder

            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
                Password = hashedPassword
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var createdCustomerDto = new CustomerDto
            {
                CustomerID = customer.CustomerID,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, createdCustomerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Customers/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest(new { message = "Invalid Login Request" });
            }

            var customer = _context.Customers
                .Where(c => c.Email == loginDto.Email && c.Password == loginDto.Password)
                .FirstOrDefault();

            if (customer == null)
            {
                return Unauthorized(new { message = "Invalid Email or Password" });
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Name = customer.Name,
                Token = tokenString
            });
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
