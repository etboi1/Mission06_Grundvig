using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Grundvig.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 3000, ErrorMessage = "Year must be after 1888.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        [Required]
        public Rating? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public string CopiedToPlex { get; set; }
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
