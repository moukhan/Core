using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Resturant Resturant { get; set; }
        public IHtmlHelper HtmlHelper;
        public IEnumerable<SelectListItem> Cuisines {get;set;}
        private readonly IResturantData resturantData;

        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.HtmlHelper = htmlHelper;
            
        }

        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = this.HtmlHelper.GetEnumSelectList<CuisineType>();
            if (resturantId.HasValue)
            {
                Resturant = resturantData.GetResturantById(resturantId.Value);
            }
            else
            {
                Resturant = new Resturant();
            }
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = this.HtmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Resturant.Id > 0)
            {
                TempData["OperationCode"] = 1; 
                TempData["Message"] = "Resturant " + Resturant.Name + " has been updated successfully !!";
                Resturant = resturantData.Update(Resturant);
            }
            else
            {
                TempData["OperationCode"] = 2;
                TempData["Message"] = "Resturant " + Resturant.Name + " has been added successfully !!";
                Resturant = resturantData.Add(Resturant);
            }
            
            resturantData.Commit();
            return RedirectToPage("./Detail", new {resturantId=Resturant.Id});
        }
    }
}