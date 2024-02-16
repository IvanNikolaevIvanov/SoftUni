using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        [Required]
        [StringLength(50, 
            MinimumLength = 10,
            ErrorMessage = "Must be between 10 and 50 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50,
            MinimumLength = 5,
            ErrorMessage = $"Must be between 5 and 50 characters")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(5000,
            MinimumLength = 5,
            ErrorMessage = "Must be between 5 and 5000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Url { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
