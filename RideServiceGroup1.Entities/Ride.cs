using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RideServiceGroup1.Entities
{
    public class Ride
    {
        public int Id { get; set; }

        [Display(Name="Navn")]
        public string Name { get; set; }

        [Display(Name="Beskrivelse")]
        public string Description { get; set; }

        [Display(Name="Kategori")]
        public RideCategory Category { get; set; }

        public Status Status
        {
            get => Reports.Count == 0
                ? Status.Working
                : ReportsOrderdByDate.FirstOrDefault().Status;
        }
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Report> ReportsOrderdByDate { get => Reports.OrderByDescending(o => o.ReportTime).ToList(); }
        //public Report LatestReport { get => ReportsOrderdByDate.FirstOrDefault(); }
        
        public string Url
        {
            get => $"/Img/{Name.ToLower()}.jpg";
        }

        public Ride()
        {

        }

        public int NumbersOfShutdowns()
        {
            int numberOfShutdowns = 0;
            //Reports.ForEach(x =>
            //{
            //    if (x.Status == Status.Broken)
            //        numberOfShutdowns++;
            //});
            foreach (Report report in Reports)
            {
                if (report.Status == Status.Broken)
                    numberOfShutdowns++;
            }
            return numberOfShutdowns;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the number of days since last shutdown.
        /// Returns -1 if there is no broken reports.
        /// </returns>
        public int DaysSinceLastShutdown()
        {
            DateTime lastShutdown = new DateTime();
            
            foreach (Report report in ReportsOrderdByDate)
            {
                if (report.Status == Status.Broken)
                {
                    lastShutdown = report.ReportTime;
                    TimeSpan timeSinceLastShutdown = DateTime.Now - lastShutdown;
                    return timeSinceLastShutdown.Days;
                }
            }
            return -1;
        }
    }
}
