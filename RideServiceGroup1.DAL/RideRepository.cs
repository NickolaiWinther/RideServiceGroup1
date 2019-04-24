using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RideServiceGroup1.DAL
{
    public class RideRepository : BaseRepository, IRepository
    {
        ReportRepository reportRepository = new ReportRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        private List<Ride> HandleData(DataTable data)
        {
            List<Ride> rides = new List<Ride>(); 
            data.Rows.Cast<DataRow>().ToList().ForEach(d =>
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

        public List<Ride> GetAll()
        {
            DataTable rideTable = ExecuteQuery("SELECT * FROM Rides");
            return HandleData(rideTable);
        }

        public Ride GetById(int id)
        {
            DataTable rideTable = ExecuteQuery($"SELECT * FROM Rides WHERE RideId = {id}");
            return HandleData(rideTable).FirstOrDefault();
        }

        public List<DataTable> HandleData()
        {
            throw new NotImplementedException();
        }

        List<IEntity> IRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public IEntity GetById()
        {
            throw new NotImplementedException();
        }
    }
}
