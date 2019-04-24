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
        private List<Report> HandleData(DataTable data)
        {
            RideRepository rideRepository = new RideRepository();
            List<Report> reports = new List<Report>();

            foreach (DataRow row in data.Rows)
            {
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

        public List<Report> GetAll()
        {
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports");
            return HandleData(reportsTable);
        }

        public List<Report> GetAllByRideId(int id)
        {
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports WHERE RideId = {id}");
            //DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports WHERE RideId = {id} ORDER BY ReportTime DESC");
            return HandleData(reportsTable);
        }
    }
}
