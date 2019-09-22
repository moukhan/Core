using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class ResturantCountViewComponent : ViewComponent
    {

        private readonly IResturantData ResturantData;
        public ResturantCountViewComponent(IResturantData resturantData)
        {
            ResturantData = resturantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = ResturantData.GetResturantCount();
            return View(count);
        }
        
    }
}
