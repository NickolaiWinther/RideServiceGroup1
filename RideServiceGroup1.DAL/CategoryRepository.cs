using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace RideServiceGroup1.DAL
{
    public class CategoryRepository : BaseRepository
    {
        private List<RideCategory> HandleData(DataTable data)
        {
            List<RideCategory> categories = new List<RideCategory>();
            
            foreach (DataRow row in data.Rows)
            {
                RideCategory rideCategory = new RideCategory()
                {
                    Id = (int)row["RideCategoryId"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"]
                };
                categories.Add(rideCategory);
            }
            return categories;
        }

        public List<RideCategory> GetAll()
        {
            DataTable categoriesTable = ExecuteQuery("SELECT * FROM RideCategory");
            return HandleData(categoriesTable);
        }

        public RideCategory GetById(int id)
        {
            DataTable categoriesTable = ExecuteQuery($"SELECT * FROM RideCategory WHERE RideCategoryId = {id}");
            return HandleData(categoriesTable).FirstOrDefault();
        }
    }
}
