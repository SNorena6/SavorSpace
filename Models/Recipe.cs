using System.ComponentModel.DataAnnotations;

namespace SavorSpace.Models;

public class Recipe
{
    public int RecipeId { get; set; }

    [Required(ErrorMessage = "Recipe name is required.")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(150, ErrorMessage = "Title can't be longer than 150 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingredients are required.")]
    [StringLength(2000, ErrorMessage = "Ingredients can't exceed 2000 characters.")]
    public string Ingredients { get; set; } = string.Empty;

    [Required(ErrorMessage = "Instructions are required.")]
    [StringLength(3000, ErrorMessage = "Instructions can't exceed 3000 characters.")]
    public string Instructions { get; set; } = string.Empty;

    [Url(ErrorMessage = "Please enter a valid URL.")]
    public string? ImageUrl { get; set; } // Optional

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
     public List<Comment> Comments {get; set;} = default!;
}
