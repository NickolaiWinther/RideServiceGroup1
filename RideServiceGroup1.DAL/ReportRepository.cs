using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace RideServiceGroup1.DAL
{
    public class ReportRepository : BaseRepository
    {
        RideRepository rideRepository = new RideRepository();

        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports");

            reportsTable.Rows.Cast<DataRow>().ToList().ForEach(d => 
            {
                Report report = new Report()
                {
                    Id = (int)d["ReportId"],
                    Status = (Status)d["Status"],
                    ReportTime = (DateTime)d["ReportTime"],
                    Notes = (string)d["Notes"],
                };
                reports.Add(report);
            });
            return reports;
        }

        public List<Report> GetAllReportsFor(int id)
        {
            List<Report> reports = new List<Report>();
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports WHERE RideId = {id} ORDER BY ReportTime DESC");

            reportsTable.Rows.Cast<DataRow>().ToList().ForEach(d =>
            {
                Report report = new Report()
                {
                    Id = (int)d["ReportId"],
                    Status = (Status)d["Status"],
                    ReportTime = (DateTime)d["ReportTime"],
                    Notes = (string)d["Notes"],
                    Ride = rideRepository.GetRide((int)d["RideId"])
                };
                reports.Add(report);
            });
            return reports;
        }
    }
}
