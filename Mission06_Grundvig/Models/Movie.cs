using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [Required]
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public Rating? Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
