using System.ComponentModel.DataAnnotations;

namespace HomeServices.Dto
{
    public class LoginDto
    {
        [Required]

        public string Email { get; set; }

        [Required]

        public string Password {  get; set; }
    }
}
