using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public PaymentsController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public ActionResult<IEnumerable<PaymentDto>> GetPayments()
        {
            var payments = _context.Payments
                .Select(p => new PaymentDto
                {
                    PaymentID = p.PaymentID,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate
                })
                .ToList();

            return Ok(payments);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public ActionResult<PaymentDto> GetPayment(int id)
        {
            var payment = _context.Payments.Find(id);

            if (payment == null)
            {
                return NotFound();
            }

            var paymentDto = new PaymentDto
            {
                PaymentID = payment.PaymentID,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate
            };

            return Ok(paymentDto);
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public IActionResult PutPayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentID)
            {
                return BadRequest();
            }

            var payment = _context.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            payment.Amount = paymentDto.Amount;
            payment.PaymentDate = paymentDto.PaymentDate;

            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Payments
        [HttpPost]
        public ActionResult<Payment> PostPayment(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                Amount = paymentDto.Amount,
                PaymentDate = paymentDto.PaymentDate
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentID }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            _context.SaveChanges();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
