using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}
