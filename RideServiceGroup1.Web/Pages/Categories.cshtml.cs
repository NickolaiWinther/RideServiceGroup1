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

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Søg")]
        public string SearchInput { get; set; }

        public string ErrorMsg { get; set; }
        public List<RideCategory> Categories { get; set; } = new List<RideCategory>();

        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            //Categories = categoryRepository.GetAll();
            if (SearchInput != null)
            {
                Categories = categoryRepository.GetAllWithName(SearchInput);
                //foreach (RideCategory rideCategory in Categories.ToList())
                //{
                //    if (!rideCategory.Name.ToLower().Contains(SearchInput.ToLower()))
                //    {
                //        Categories.Remove(rideCategory);
                //    }
                //}
            }
            else
            {
                Categories = categoryRepository.GetAll();
            }
            
        }
        public void OnPost()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Categories = categoryRepository.GetAll();

            bool categoryExists = false;
            foreach (RideCategory category in Categories)
            {
                if (CategoryName.ToLower() == category.Name.ToLower())
                {
                    categoryExists = true;
                    break;
                }
            }

            if (categoryExists)
            {
                ErrorMsg = "Kategorien findes allerede";
            }
            else
            {
            RideCategory rideCategory = new RideCategory()
            {
                Name = CategoryName,
                Description = CategoryDescription
            };
            categoryRepository.Insert(rideCategory);
            Categories = categoryRepository.GetAll();
            }
        }

        public string GetUrl(int id)
        {
            return $"index?SearchCat={id}";
        }
    }
}