using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [StringLength(25)]
        public string StatusDesc { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
