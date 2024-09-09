using HomeServices.Dto;
using HomeServices.Exceptions;
using HomeServices.Filters;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeServices.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [GlobalExceptionHandler]
    public class AdminController : ControllerBase
    {
        private readonly HomeServiceContext _context;
        private readonly IConfiguration _config;

        public AdminController(HomeServiceContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Admin
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = _context.AdminTable.ToList();
            return Ok(admins);
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _context.AdminTable.Find(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // POST: api/Admin
        [HttpPost]
        public IActionResult CreateAdmin([FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
            {
                return BadRequest("Invalid admin data");
            }

            var admin = new Admin
            {
                AdminName = adminDto.AdminName,
                AdminEmail = adminDto.AdminEmail,
               // AdminPassword = adminDto.AdminPassword, // Note: Handle password hashing in production
                Role = adminDto.Role
            };

            _context.AdminTable.Add(admin);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAdminById), new { id = admin.AdminID }, admin);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminDto adminDto)
        {
            if (adminDto == null || id != adminDto.AdminID)
            {
                return BadRequest();
            }

            var admin = _context.AdminTable.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            admin.AdminName = adminDto.AdminName;
            admin.AdminEmail = adminDto.AdminEmail;
          //  admin.AdminPassword = adminDto.AdminPassword; // Note: Handle password hashing in production
            admin.Role = adminDto.Role;

            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var admin = _context.AdminTable.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.AdminTable.Remove(admin);
            _context.SaveChanges();

            throw new CustomExceptions("Send"); 

            return NoContent();
        }

        // POST: api/Admin/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid Login Request");
            }

            var admin = _context.AdminTable
                .Where(a => a.AdminEmail == loginDto.Email && a.AdminPassword == loginDto.Password) // Note: Handle password hashing in production
                .FirstOrDefault();

            if (admin == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                new[]
                {
                    new Claim(ClaimTypes.Name, admin.AdminName),
                    new Claim(ClaimTypes.Role, admin.Role)
                },
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { name = admin.AdminName, token = tokenString });
        }
    }
}
