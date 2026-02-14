using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public class Movie
    {
        [Key]
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
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
