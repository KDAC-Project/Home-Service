using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Models
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

        public int? ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Wpayment> Wpayments { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    

}
}
