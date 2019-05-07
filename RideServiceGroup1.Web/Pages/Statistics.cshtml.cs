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
        public StatisticsModel()
        {
            Rides = RideRepository.GetAll();
            Reports = ReportRepository.GetAll();
        }
        public List<Ride> Rides { get; set; }
        public List<Report> Reports { get; set; }
        public int MyProperty { get; set; }
        public ReportRepository ReportRepository { get; set; } = new ReportRepository();
        public RideRepository RideRepository { get; set; } = new RideRepository();

        public Ride MostBrokenRide
        {
            get
            {
                Ride mostBrokenRide = Rides[0];
                foreach (Ride ride in Rides)
                    if (ride.NumbersOfShutdowns() > mostBrokenRide.NumbersOfShutdowns())
                        mostBrokenRide = ride;
                 
                return mostBrokenRide;
            }
        }

        public Ride LeastBrokenRide
        {
            get
            {
                Ride leastBrokenRide = Rides[0];
                foreach (Ride ride in Rides)
                {
                    if (ride.NumbersOfShutdowns() < leastBrokenRide.NumbersOfShutdowns())
                    {
                        leastBrokenRide = ride;
                    }
                }
                return leastBrokenRide;
            }
        }

        public Ride MostRecentlyBroken
        {
            get
            {
                Ride ride = RideRepository.GetLatestBrokenRide();
                return ride;
            }
        }

        public void OnGet()
        {
            
        }
    }
}