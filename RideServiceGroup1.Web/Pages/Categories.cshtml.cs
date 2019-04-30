using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup1.DAL;
using RideServiceGroup1.Entities;

namespace RideServiceGroup1.Web.Pages
{
    public class CategoriesModel : PageModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<RideCategory> Categories { get; set; }
        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Categories = categoryRepository.GetAll();
        }
    }
}