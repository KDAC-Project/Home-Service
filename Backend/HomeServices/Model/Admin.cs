using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Admin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminID { get; set; }

        [Required, MaxLength(100)]
        public string AdminName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string AdminEmail { get; set; }

        [Required]
        public string AdminPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
