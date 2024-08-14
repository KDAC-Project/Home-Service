using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServices.Model
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, Phone, MaxLength(15)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public string Password { get; set; }


        public ICollection<Booking> Bookings  { get; set;}
    }
}
