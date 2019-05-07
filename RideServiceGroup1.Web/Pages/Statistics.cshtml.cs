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
            Rides = rideRepository.GetAll();
            Reports = reportRepository.GetAll();
        }
        public List<Ride> Rides { get; set; }
        public List<Report> Reports { get; set; }
        public int MyProperty { get; set; }
        public ReportRepository reportRepository { get; set; } = new ReportRepository();
        RideRepository rideRepository { get; set; } = new RideRepository();

        public Ride MostBrokenRide
        {
            get => Rides.Where(x => x.NumbersOfShutdowns() == Rides.Max(y => y.NumbersOfShutdowns())).First();
        }

        public Ride MostRecentlyBroken
        {
            get
            {
                Ride ride = rideRepository.GetLatestBrokenRide();


                return ride;
            }
        }

        public void OnGet()
        {
            
        }
    }
}