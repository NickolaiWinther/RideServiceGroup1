using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class ReportRepository : BaseRepository
    {
        public List<Report> GetReports(Ride ride)
        {
            string sql = $"SELECT * FROM Reports WHERE RideId LIKE {ride.Id}";
            throw new NotImplementedException();
        }
    }
}
