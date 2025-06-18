using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public record Book
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer.")]
        public int Id { get; init; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; init; } = string.Empty;
    }
}
