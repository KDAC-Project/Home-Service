using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public RatingsController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Ratings
        [HttpGet]
        public ActionResult<IEnumerable<RatingDto>> GetRatings()
        {
            var ratings = _context.Ratings
                .Select(r => new RatingDto
                {
                    RatingID = r.RatingID,
                    WorkerID = r.WorkerID,
                    RatingValue = r.RatingValue
                })
                .ToList();

            return Ok(ratings);
        }

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public ActionResult<RatingDto> GetRating(int id)
        {
            var rating = _context.Ratings.Find(id);

            if (rating == null)
            {
                return NotFound();
            }

            var ratingDto = new RatingDto
            {
                RatingID = rating.RatingID,
                WorkerID = rating.WorkerID,
                RatingValue = rating.RatingValue
            };

            return Ok(ratingDto);
        }

        // PUT: api/Ratings/5
        [HttpPut("{id}")]
        public IActionResult PutRating(int id, RatingDto ratingDto)
        {
            if (id != ratingDto.RatingID)
            {
                return BadRequest();
            }

            var rating = _context.Ratings.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            rating.WorkerID = ratingDto.WorkerID;
            rating.RatingValue = ratingDto.RatingValue;

            _context.Entry(rating).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Ratings
        [HttpPost]
        public ActionResult<Rating> PostRating(RatingDto ratingDto)
        {
            var rating = new Rating
            {
                WorkerID = ratingDto.WorkerID,
                RatingValue = ratingDto.RatingValue
            };

            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRating), new { id = rating.RatingID }, rating);
        }

        // DELETE: api/Ratings/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int id)
        {
            var rating = _context.Ratings.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.Ratings.Remove(rating);
            _context.SaveChanges();

            return NoContent();
        }

        private bool RatingExists(int id)
        {
            return _context.Ratings.Any(e => e.RatingID == id);
        }
    }
}
