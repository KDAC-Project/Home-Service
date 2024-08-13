using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace HomeServices.Model
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int WorkerID { get; set; }
        public int ServiceID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public int StatusID { get; set; }
        public int PaymentID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }

        [ForeignKey("ServiceID")]
        public Service Service { get; set; }

        [ForeignKey("StatusID")]
        public Status Status { get; set; }

        [ForeignKey("PaymentID")]
        public Payment Payment { get; set; }

    }
}
