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
    public class DetailsModel : PageModel
    {
        public Ride Ride { get; set; }
        public void OnGet()
        {
            var id = Int32.Parse((string)RouteData.Values["id"]);
            RideRepository rideRepository = new RideRepository();
            Ride = rideRepository.GetById(id);
        }
    }
}