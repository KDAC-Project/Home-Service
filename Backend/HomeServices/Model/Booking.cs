using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace HomeServices.Model
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public int WorkerID { get; set; }
        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }

        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public Status Status { get; set; }

        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public Payment Payment { get; set; }

    }
}
