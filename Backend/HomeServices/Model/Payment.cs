using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

    }
}
