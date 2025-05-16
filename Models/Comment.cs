using System.ComponentModel.DataAnnotations;

namespace SavorSpace.Models;

public class Comment
{
    public int CommentId { get; set; } // Primary Key

    [Required]
    [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
    public int Score { get; set; }

    [StringLength(1000, ErrorMessage = "Comment text can't exceed 1000 characters.")]
    public string CommentText { get; set; } = string.Empty;

    // Foreign key to the related Recipe
    [Required]
    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; } = default!; // Navigation property
}
