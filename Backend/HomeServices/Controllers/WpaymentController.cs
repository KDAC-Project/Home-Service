using HomeServices.Dto;
using HomeServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WpaymentController : ControllerBase
    {
        private readonly HomeServiceContext _context;

        public WpaymentController(HomeServiceContext context)
        {
            _context = context;
        }

        // GET: api/Wpayment
        [HttpGet]

        public ActionResult<IEnumerable<WpaymentDto>> GetWpayment()
        {
            var payments = _context.WorkerPayments
                .Select(wp => new WpaymentDto
                {
                    WpaymentID = wp.WpaymentID,
                    WorkerID = wp.WorkerID,
                    WpaymentAmount = wp.WpaymentAmount,
                    WpaymentDate = wp.WpaymentDate
                })
                .ToList();

            return Ok(payments);
        }

        // GET: api/Wpayment/5
        [HttpGet("{id}")]
        public ActionResult<WpaymentDto> GetWpayment(int id)
        {
            var wpayment = _context.WorkerPayments.Find(id);

            if (wpayment == null)
            {
                return NotFound();
            }

            var wpaymentDto = new WpaymentDto
            {
                WpaymentID = wpayment.WpaymentID,
                WorkerID = wpayment.WorkerID,
                WpaymentAmount = wpayment.WpaymentAmount,
                WpaymentDate = wpayment.WpaymentDate
            };

            return Ok(wpaymentDto);
        }

        // PUT: api/Wpayment/5
        [HttpPut("{id}")]
        public IActionResult PutWpayment(int id, WpaymentDto wpaymentDto)
        {
            if (id != wpaymentDto.WpaymentID)
            {
                return BadRequest();
            }

            var wpayment = _context.WorkerPayments.Find(id);
            if (wpayment == null)
            {
                return NotFound();
            }

            wpayment.WorkerID = wpaymentDto.WorkerID;
            wpayment.WpaymentAmount = wpaymentDto.WpaymentAmount;
            wpayment.WpaymentDate = wpaymentDto.WpaymentDate;

            _context.Entry(wpayment).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Wpayment
        [HttpPost]
        public ActionResult<WpaymentDto> PostWpayment(WpaymentDto wpaymentDto)
        {
            var wpayment = new WokerPayment
            {
                WorkerID = wpaymentDto.WorkerID,
                WpaymentAmount = wpaymentDto.WpaymentAmount,
                WpaymentDate = wpaymentDto.WpaymentDate
            };

            _context.WorkerPayments.Add(wpayment);
            _context.SaveChanges();

            var createdWpaymentDto = new WpaymentDto
            {
                WpaymentID = wpayment.WpaymentID,
                WorkerID = wpayment.WorkerID,
                WpaymentAmount = wpayment.WpaymentAmount,
                WpaymentDate = wpayment.WpaymentDate
            };

            return CreatedAtAction(nameof(GetWpayment), new { id = wpayment.WpaymentID }, createdWpaymentDto);
        }

        // DELETE: api/Wpayment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWpayment(int id)
        {
            var wpayment = _context.WorkerPayments.Find(id);
            if (wpayment == null)
            {
                return NotFound();
            }

            _context.WorkerPayments.Remove(wpayment);
            _context.SaveChanges();

            return NoContent();
        }

        private bool WpaymentExists(int id)
        {
            return _context.WorkerPayments.Any(e => e.WpaymentID == id);
        }
    }
}
