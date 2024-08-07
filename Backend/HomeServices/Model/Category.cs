using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; }

    }
}
