using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;

        HomeServiceContext context = null;

        public LoginController(IConfiguration config, HomeServiceContext _context)
        {
            _config = config;
            context = _context;
        }


        [HttpPost("Login")]

        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid Login Request");
            } 

            Customer customer = context.Customers.Where(c => c.Email == loginDto.Email && c.Password == loginDto.Password).FirstOrDefault();

            if (customer == null || customer.Password != loginDto.Password)
            {
                return Unauthorized("Invalid Email or password");

            }

           // var user = _db.users.where(u => u.email == loginrequest.username && u.password == loginrequest.password).include(u => u.getrole).firstordefault();

            //var customer = _db.Customers.where(u => u.email == loginrequest.username && u.password == loginrequest.password)


                if (customer != null)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var sectoken = new JwtSecurityToken(_config["jwt:issuer"],
                  _config["jwt:issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(sectoken);

                return Ok(new { name = customer.Name, token });
            }
            else
            {
                return Ok(new { error = "invalid username or password" });
            }
        }

        /* // GET: api/<LoginController>
         [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET api/<LoginController>/5
         [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }

         // POST api/<LoginController>
         [HttpPost]
         public void Post([FromBody] string value)
         {
         }

         // PUT api/<LoginController>/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE api/<LoginController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
    }
