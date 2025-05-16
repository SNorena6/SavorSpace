using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SavorSpace.Models;

namespace SavorSpace.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipes { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Recipes.AsQueryable();

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                var searchUpper = CurrentSearch.ToUpper();
                query = query.Where(r => r.Name.ToUpper().Contains(searchUpper));
            }

            query = CurrentSort switch
            {
                "name_desc" => query.OrderByDescending(r => r.Name),
                "date_asc" => query.OrderBy(r => r.CreatedAt),
                "date_desc" => query.OrderByDescending(r => r.CreatedAt),
                _ => query.OrderBy(r => r.Name),
            };

            var totalCount = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            Recipes = await query
                .Skip((PageNum - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
