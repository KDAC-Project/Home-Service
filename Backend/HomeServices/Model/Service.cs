using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
