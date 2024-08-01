using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Models
{
    public class Wpayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WpaymentID { get; set; }

        [Required]
        public int WorkerID { get; set; }
        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal WpaymentAmount { get; set; }

        [Required]
        public DateTime WpaymentDate { get; set; }
    }

}
