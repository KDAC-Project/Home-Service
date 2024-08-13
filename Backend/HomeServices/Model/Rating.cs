using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        public int WorkerID { get; set; }

        [Range(1, 5)]
        public int RatingValue { get; set; }

        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }

    }
}
