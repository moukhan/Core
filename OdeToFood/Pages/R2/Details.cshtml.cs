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
    public class DetailsModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDBContext _context;

        public DetailsModel(OdeToFood.Data.OdeToFoodDBContext context)
        {
            _context = context;
        }

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
    }
}
