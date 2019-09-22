using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DeleteModel : PageModel
    {
        private IResturantData ResturantData;
        public Resturant resturant { get; set; }
        public DeleteModel(IResturantData resturantData)
        {
            ResturantData = resturantData;
        }
        
        public IActionResult OnGet(int resturantId)
        {
            resturant = ResturantData.GetResturantById(resturantId);
            if(resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost(int resturantId)
        {
            resturant = ResturantData.GetResturantById(resturantId);
            if (resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            ResturantData.Delete(resturantId);
            ResturantData.Commit();
            TempData["Message"] = $"{resturant.Name} has been deleted";
            return RedirectToPage("./List");
        }

    }
}