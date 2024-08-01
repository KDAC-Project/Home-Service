using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Models
{
    public class Status
    {
        [Key]
        public int StatusID {  get; set; }
        
        [StringLength(25)]
        public string StatusDesc { get; set; }

        public ICollection<Booking>Bookings{ get; set; }

        
        }

    
}
