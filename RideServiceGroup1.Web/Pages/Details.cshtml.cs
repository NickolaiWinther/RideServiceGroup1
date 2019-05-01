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
        [BindProperty(SupportsGet = true)]
        public string Notes { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime ReportTime { get; set; }
        [BindProperty(SupportsGet = true)]
        public Status Status { get; set; }

        public Ride Ride { get; set; }

        public void OnPost(int id)
        {
            ReportRepository reportRepository = new ReportRepository();
            RideRepository rideRepository = new RideRepository();
            Ride = rideRepository.GetById(id);

            if (Notes != string.Empty && Notes != null)
            {
                Report report = new Report()
                {
                    Notes = Notes,
                    ReportTime = DateTime.Now,
                    Status = Status,
                    Ride = Ride
                };
                reportRepository.Insert(report);
                Ride.Reports.Add(report);
            }
        }

        public void OnGet(int id)
        {
            RideRepository rideRepository = new RideRepository();
            Ride = rideRepository.GetById(id);
        }
    }
}