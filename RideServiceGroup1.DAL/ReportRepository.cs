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
            data.Rows.Cast<DataRow>().ToList().ForEach(row => 
            {
                Report report = new Report()
                {
                    Id = (int)row["ReportId"],
                    Status = (Status)row["Status"],
                    ReportTime = (DateTime)row["ReportTime"],
                    Notes = (string)row["Notes"],
                    //Ride = rideRepository.GetById((int)row["RideId"]), Ride is assigned inside RideRepository
                };
                reports.Add(report);
            });
            
            return reports;
        }

        public List<Report> GetAll()
        {
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports ORDER BY ReportTime DESC");
            return HandleData(reportsTable);
        }

        public List<Report> GetAllByRideId(int id)
        {
            DataTable reportsTable = ExecuteQuery($"SELECT * FROM Reports WHERE RideId = {id}");
            return HandleData(reportsTable);
        }

        public int Insert(Report report)
        {
            return ExecuteNonQuery($"INSERT INTO Reports VALUES({(int)report.Status}, '{report.ReportTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{report.Notes}', {report.Ride.Id})");
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
