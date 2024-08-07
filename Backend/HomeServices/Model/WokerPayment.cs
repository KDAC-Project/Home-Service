using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class WokerPayment
    {
        [Key]
        public int WpaymentID { get; set; }

        public int WorkerID { get; set; }

        [Required]
        public double WpaymentAmount { get; set; }

        [Required]
        public DateTime WpaymentDate { get; set; }

        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }

    }
}
