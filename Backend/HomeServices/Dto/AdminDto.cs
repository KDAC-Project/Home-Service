using System.ComponentModel.DataAnnotations;

namespace HomeServices.Dto
{
    public class AdminDto
    {
        public int AdminID { get; set; }

        [Required, MaxLength(100)]
        public string AdminName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string AdminEmail { get; set; }

       

        [Required]
        public string Role { get; set; }
    }
}
