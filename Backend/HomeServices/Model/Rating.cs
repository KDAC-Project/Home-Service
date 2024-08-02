using HomeService.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeService.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }


        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public string Worker WorkerPayement  { get; set; }

         [Range(1,5)]
        public string RatingValue { get; set; }
    }

public class ProjectDBContext : DbContext
{
    public ProjectDBContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Rating> Ratings { get; set; }

}


