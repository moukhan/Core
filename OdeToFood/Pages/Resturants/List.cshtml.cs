using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Resturants
{
    //Controller Action
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Resturant> Resturants { get; set; }
        private readonly IConfiguration config;
        private readonly IResturantData resturantData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        //Model that is passed into the view
        public void OnGet()
        {
           this.Resturants = resturantData.GetResturantsByName(SearchTerm);
        }

        public ListModel(IConfiguration config,
                         IResturantData resturantData)
        {
            this.resturantData = resturantData;
            
        }
    }
}