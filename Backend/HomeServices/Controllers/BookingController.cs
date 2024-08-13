using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public BookingController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> GetBookings()
        {
            var bookings = _context.Bookings
                .Select(b => new BookingDto
                {
                    BookingID = b.BookingID,
                    CustomerID = b.CustomerID,
                    WorkerID = b.WorkerID,
                    ServiceID = b.ServiceID,
                    BookingDate = b.BookingDate,
                    StatusID = b.StatusID,
                    PaymentID = b.PaymentID
                })
                .ToList();

            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public ActionResult<BookingDto> GetBooking(int id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingDto = new BookingDto
            {
                BookingID = booking.BookingID,
                CustomerID = booking.CustomerID,
                WorkerID = booking.WorkerID,
                ServiceID = booking.ServiceID,
                BookingDate = booking.BookingDate,
                StatusID = booking.StatusID,
                PaymentID = booking.PaymentID
            };

            return Ok(bookingDto);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public IActionResult PutBooking(int id, BookingDto bookingDto)
        {
            if (id != bookingDto.BookingID)
            {
                return BadRequest();
            }

            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.CustomerID = bookingDto.CustomerID;
            booking.WorkerID = bookingDto.WorkerID;
            booking.ServiceID = bookingDto.ServiceID;
            booking.BookingDate = bookingDto.BookingDate;
            booking.StatusID = bookingDto.StatusID;
            booking.PaymentID = bookingDto.PaymentID;

            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public ActionResult<Booking> PostBooking(BookingDto bookingDto)
        {
            var booking = new Booking
            {
                CustomerID = bookingDto.CustomerID,
                WorkerID = bookingDto.WorkerID,
                ServiceID = bookingDto.ServiceID,
                BookingDate = bookingDto.BookingDate,
                StatusID = bookingDto.StatusID,
                PaymentID = bookingDto.PaymentID
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingID }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
