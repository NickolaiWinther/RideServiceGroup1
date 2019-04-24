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
        private List<Ride> HandleData(DataTable data)
        {
            ReportRepository reportRepository = new ReportRepository();
            CategoryRepository categoryRepository = new CategoryRepository();

            List<Ride> rides = new List<Ride>();
            foreach (DataRow row in data.Rows)
            {
                Ride ride = new Ride()
                {
                    Id = (int)row["RideId"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"],
                    Category = categoryRepository.GetById((int)row["CategoryId"]),
                };
                rides.Add(ride);
            }
            return rides;
        }

        public List<Ride> GetAll()
        {
            DataTable rideTable = new DataTable();
            rideTable = ExecuteQuery("SELECT * FROM Rides");
            return HandleData(rideTable);
        }

        public Ride GetById(int id)
        {
            DataTable rideTable = ExecuteQuery($"SELECT * FROM Rides WHERE RideId = {id}");
            return HandleData(rideTable).FirstOrDefault();
        }
    }
}
