﻿using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class RideRepository : BaseRepository
    {
        public List<Ride> GetAllRideImgs()
        {
            List<Ride> rides = new List<Ride>();

            string sql = "SELECT Rides.RideId, Rides.Name, Reports.Status FROM Rides JOIN Reports ON Rides.RideId = Reports.RideId";

            DataTable rideTable = ExecuteQuery(sql);

            foreach (DataRow row in rideTable.Rows)
            {
                int id = (int)row["RideId"];
                string name = (string)row["Name"];
                int status = (int)row["Status"];

                Ride ride = new Ride();

                rides.Add(ride);
            }
            return rides;
        }
    }
}
