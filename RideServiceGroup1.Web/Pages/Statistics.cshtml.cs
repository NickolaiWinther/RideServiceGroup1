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
    public class StatisticsModel : PageModel
    {
        public List<Ride> Rides { get; set; }
        public int MyProperty { get; set; }

        public Ride MostBrokenRide
        {
            get
            {
                var maxZ = Rides.Max(x => x.NumbersOfShutdowns());
                return Rides.Where(x => x.NumbersOfShutdowns() == maxZ).First();
            }
        }

        public void OnGet()
        {
            RideRepository rideRepository = new RideRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            Rides = rideRepository.GetAll();
            
        }
    }
}