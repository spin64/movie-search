using System.ComponentModel.DataAnnotations;

namespace MovieSearchLogs.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int ImdbId { get; set; }
        public string movieTitle { get; set; }
        public DateTime queryDate { get; set; }
    }
}
