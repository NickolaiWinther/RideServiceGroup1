using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup1.Entities;
using RideServiceGroup1.DAL;

namespace RideServiceGroup1.Web.Pages
{
    public class AddRideModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<RideCategory> Category { get; set; }

        public RideCategory SelectedCategory { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryId { get; set; }

        public void OnPost()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            RideRepository rideRepository = new RideRepository();
            
            if (Name != string.Empty && Name != null)
            {
                Ride ride = new Ride()
                {
                    Name = Name,
                    Description = Description,
                    Category = categoryRepository.GetById(SelectedCategoryId),
                };
                rideRepository.Insert(ride);
            }
            Response.Redirect("/");
        }

        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Category = categoryRepository.GetAll();
        }
    }
}