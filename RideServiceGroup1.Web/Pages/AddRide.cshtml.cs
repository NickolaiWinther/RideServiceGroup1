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
        [BindProperty]
        public Ride Ride { get; set; } = new Ride();
        
        public AddRideModel()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Categories = categoryRepository.GetAll();
        }
        public List<RideCategory> Categories { get; set; }

        public RideCategory SelectedCategory { get; set; }

        public string RideAction { get; set; } = "Tilføj forlystelse";
        public string EditCategory { get; set; } = "";

        public string PageHandler { get; set; } = "";


        public void OnPost()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            RideRepository rideRepository = new RideRepository();
            rideRepository.Insert(Ride);
            
            Response.Redirect("/");
        }

        public void OnGet()
        {
            
        }
        public void OnGetEdit(int id)
        {
            RideRepository rideRepository = new RideRepository();
            Ride = rideRepository.GetById(id);
            RideAction = "Redigér forlystelse";
            PageHandler = "Edit";
        }
        public void OnPostEdit()
        {
            RideRepository rideRepository = new RideRepository();
            rideRepository.Update(Ride);
        }
    }
}