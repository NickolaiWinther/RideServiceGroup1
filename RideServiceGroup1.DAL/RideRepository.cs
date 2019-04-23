using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class RideRepository : BaseRepository
    {
        public List<Ride> GetAllRides()
        {
            List<Ride> rides = new List<Ride>();
            DataTable rideTable = ExecuteQuery("SELECT * FROM Rides");
            
            foreach (DataRow row in rideTable.Rows)
            {
                RideCategory rideCategory = new RideCategory((int)row["CategoryId"]);
                Ride ride = new Ride() {
                    Id = (int)row["RideId"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"],
                    Category = rideCategory
                };
                rides.Add(ride);
            }
            return rides;
        }
    }
}
