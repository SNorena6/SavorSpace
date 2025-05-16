using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SavorSpace.Models;
using System.Threading.Tasks;

namespace SavorSpace.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Recipe? Recipe { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .Include(r => r.Comments)
                .FirstOrDefaultAsync(r => r.RecipeId == id.Value);

            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
