using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Customer
    {
        [Key]
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
    }
}
