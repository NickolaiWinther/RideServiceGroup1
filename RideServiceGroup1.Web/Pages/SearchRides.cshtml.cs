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
    public class SearchRidesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SearchCat { get; set; }
        [BindProperty(SupportsGet = true)]
        public Status Status { get; set; }

        public List<Ride> Rides { get; set; }
        public List<RideCategory> Categories { get; set; }

        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            RideRepository rideRepository = new RideRepository();
            Rides = rideRepository.GetAll();
            Categories = categoryRepository.GetAll();
            
            if (SearchName != string.Empty && SearchName != null)
                Rides.RemoveAll(r => !r.Name.ToLower().Contains(SearchName.ToLower()));
            
            if (SearchCat != 0)
                Rides.RemoveAll(r => r.Category.Id != SearchCat);
            
            if (Status != Status.Undefined)
                Rides.RemoveAll(r => r.Status != Status);
        }
    }
}