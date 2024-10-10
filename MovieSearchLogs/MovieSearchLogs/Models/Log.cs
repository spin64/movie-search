using System.ComponentModel.DataAnnotations;

namespace MovieSearchLogs.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string movieTitle { get; set; }
        public int numOfResults { get; set; }
        public DateTime queryDate { get; set; }
    }
}
