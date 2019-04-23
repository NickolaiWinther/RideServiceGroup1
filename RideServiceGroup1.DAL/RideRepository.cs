using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class RideRepository : BaseRepository
    {
        ReportRepository reportRepository = new ReportRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        public List<Ride> GetAllRides()
        {
            List<Ride> rides = new List<Ride>();
            DataTable rideTable = ExecuteQuery("SELECT * FROM Rides");

            rideTable.Rows.Cast<DataRow>().ToList().ForEach(d => 
            {
                Ride ride = new Ride()
                {
                    Id = (int)d["RideId"],
                    Name = (string)d["Name"],
                    Description = (string)d["Description"],
                    Reports = reportRepository.GetAllReportsFor((int)d["RideId"]),
                    Category = categoryRepository.GetRideCategory((int)d["CategoryId"])
                };
                rides.Add(ride);
            });
            return rides;
        }

        public Ride GetRide(int id)
        {
            DataTable categoriesTable = ExecuteQuery($"SELECT * FROM Rides WHERE RideId = {id}");
            Ride ride = new Ride();

            categoriesTable.Rows.Cast<DataRow>().ToList().ForEach(d =>
            {
                ride.Id = (int)d["RideId"];
                ride.Name = (string)d["Name"];
                ride.Description = (string)d["Description"];
                ride.Reports = reportRepository.GetAllReportsFor((int)d["RideId"]);
                ride.Category = categoryRepository.GetRideCategory((int)d["CategoryId"]);
            });
            return ride;
        }
        //public List<Ride> GetAllRides()
        //{
        //    List<Ride> rides = new List<Ride>();
        //    DataTable rideTable = ExecuteQuery("SELECT * FROM Rides");

        //    foreach (DataRow row in rideTable.Rows)
        //    {
        //        RideCategory rideCategory = new RideCategory((int)row["CategoryId"]);
        //        Ride ride = new Ride() {
        //            Id = (int)row["RideId"],
        //            Name = (string)row["Name"],
        //            Description = (string)row["Description"],
        //            Category = rideCategory
        //        };
        //        rides.Add(ride);
        //    }
        //    return rides;
        //}
    }
}
