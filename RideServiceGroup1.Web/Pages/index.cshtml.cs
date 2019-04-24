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
    public class IndexModel : PageModel
    {
        public List<Ride> Rides { get; set; }
        public void OnGet()
        {
            RideRepository rideRepo = new RideRepository();
            Rides = rideRepo.GetAll();
        }
    }
}