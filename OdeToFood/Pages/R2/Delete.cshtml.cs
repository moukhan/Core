using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.R2
{
    public class DeleteModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDBContext _context;

        public DeleteModel(OdeToFood.Data.OdeToFoodDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resturant Resturant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturants.FirstOrDefaultAsync(m => m.Id == id);

            if (Resturant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturants.FindAsync(id);

            if (Resturant != null)
            {
                _context.Resturants.Remove(Resturant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
