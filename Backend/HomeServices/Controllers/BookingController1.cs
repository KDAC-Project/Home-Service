//using HomeServices.Dto;
//using HomeServices.Model;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace HomeServices.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BookingController1 : ControllerBase
//    {
//        private HomeServiceContext _context= null ;
//        public BookingController1(HomeServiceContext context)
//        {
//            _context = context;
//        }

//        // GET: api/<BookingController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<BookingController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<BookingController>
//        [HttpPost]
//        public string Post([FromBody] BookingDto bookingDto)
//        {
//            Booking booking = new Booking();
//            booking.Customer = _context.Customers.Find(bookingDto.CustomerID);
//            booking.Worker = _context.Workers.Find(WorkerDto.WorkerID);
//            booking.Service = _context.Services.Find(ServiceDto.ServiceID);
//            booking.Status = _context.Services.Find(StatusDto.StatusID);
//            booking.Payment = _context.Customers.Find(bookingDto.PaymentID);
//            _context.Bookings.Add(booking);
//            _context.SaveChanges();
//            return "Booking Added";
//        }

//        // PUT api/<BookingController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<BookingController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
