using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class ReportRepository : BaseRepository
    {
        public List<Report> GetReports(Ride ride)
        {
            List<Report> reports = new List<Report>();
            DataTable reportTable = ExecuteQuery($"SELECT * FROM Reports WHERE RideId = {ride.Id}");
            ReportRepository reportRepository = new ReportRepository();
            foreach (DataRow row in reportTable.Rows)
            {
                RideCategory rideCategory = new RideCategory((int)row["CategoryId"]);
                Report report = new Report()
                {
                    Id = (int)row["ReportId"],
                    Status = (Status)row["Status"],
                    ReportTime = (DateTime)row["ReportTime"],
                    Notes = (string)row["Notes"],
                    Ride = (Ride)row["RideId"]
                };
                
                reports.Add(report);
            }
            return reports;
        }
    }
}
