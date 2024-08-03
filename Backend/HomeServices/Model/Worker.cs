using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Skill { get; set; }

        [Column("Password", TypeName = "varchar")]
        [StringLength(25)]
        public string Password { get; set; }

        public int? ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<WorkerPayment> Workerpayments { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
