using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SavorSpace.Models;

namespace SavorSpace.Pages.Recipes
{
    public class AddCommentModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddCommentModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comment NewComment { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }

        public Recipe? Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Recipe = await _context.Recipes.FindAsync(RecipeId);
            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload recipe to display name if form validation fails
                Recipe = await _context.Recipes.FindAsync(RecipeId);
                return Page();
            }

            // Attach the recipe id to the new comment
            NewComment.RecipeId = RecipeId;

            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = RecipeId });
        }
    }
}
