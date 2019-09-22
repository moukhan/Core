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
    public class DetailModel : PageModel
    {
        public Resturant Resturant { get; set; }
        private readonly IResturantData resturantData;
        [TempData]
        public string Message { get; set; }

        [TempData]
        public int OperationCode { get; set; }


        
        public DetailModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.GetResturantById(resturantId);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }
    }
}