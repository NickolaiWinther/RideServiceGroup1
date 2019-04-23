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
        public List<RideCategory> GetAllRideCategories()
        {
            List<RideCategory> categories = new List<RideCategory>();
            DataTable categoriesTable = ExecuteQuery("SELECT * FROM RideCategory");

            categoriesTable.Rows.Cast<DataRow>().ToList().ForEach(d => 
            {
                RideCategory rideCategory = new RideCategory()
                {
                    Id = (int)d["RideCategoryId"],
                    Name = (string)d["Name"],
                    Description = (string)d["Description"]
                };
                categories.Add(rideCategory);
            });
            return categories;
        }

        public RideCategory GetRideCategory(int id)
        {
            DataTable categoriesTable = ExecuteQuery($"SELECT * FROM RideCategory WHERE RideCategoryId = {id}");
            RideCategory rideCategory = new RideCategory();

            categoriesTable.Rows.Cast<DataRow>().ToList().ForEach(d =>
            {
                rideCategory.Id = (int)d["RideCategoryId"];
                rideCategory.Name = (string)d["Name"];
                rideCategory.Description = (string)d["Description"];
            });
            return rideCategory;
        }
    }
}
