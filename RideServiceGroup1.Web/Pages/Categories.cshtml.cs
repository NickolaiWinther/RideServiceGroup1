using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [BindProperty]
        [Display(Name = "Navn")]
        public string CategoryName { get; set; }
        [BindProperty]
        [Display(Name = "Beskrivelse")]
        public string CategoryDescription { get; set; }
        public List<RideCategory> Categories { get; set; } = new List<RideCategory>();
        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Categories = categoryRepository.GetAll();
        }
        public void OnPost()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            RideCategory rideCategory = new RideCategory()
            {
                Name = CategoryName,
                Description = CategoryDescription
            };
            categoryRepository.Insert(rideCategory);
            Categories = categoryRepository.GetAll();

        }
    }
}