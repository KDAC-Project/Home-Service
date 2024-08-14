using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public ServiceCategoriesController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCategories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetServiceCategories()
        {
            var categories = _context.Categories
                .Select(c => new CategoryDto
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                })
                .ToList();

            return Ok(categories);
        }

        // GET: api/ServiceCategories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetServiceCategory(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDto
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
            };

            return Ok(categoryDto);
        }

        // PUT: api/ServiceCategories/5
        [HttpPut("{id}")]
        public IActionResult PutServiceCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.CategoryID)
            {
                return BadRequest();
            }

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

          //  category.CategoryID = categoryDto.CategoryID;
            category.CategoryName = categoryDto.CategoryName;
            

            _context.Entry(category).State = EntityState.Modified;

            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/ServiceCategories
        [HttpPost]
        public ActionResult<Category> PostServiceCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                // Initialize properties from DTO
             //   CategoryID = categoryDto.CategoryID,
                CategoryName = categoryDto.CategoryName,

                
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetServiceCategory), new { id = category.CategoryID }, category);
        }

        // DELETE: api/ServiceCategories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServiceCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }

        private bool ServiceCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
