using System.ComponentModel.DataAnnotations;

namespace HomeServices.Model
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [MaxLength(25)]
        public string StatusDesc { get; set; }

    }
}
