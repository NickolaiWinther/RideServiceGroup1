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
            data.Rows.Cast<DataRow>().ToList().ForEach(row => {
                RideCategory rideCategory = new RideCategory()
                {
                    Id = (int)row["RideCategoryId"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"]
                };
                categories.Add(rideCategory);
            });
            return categories;
        }

        public List<RideCategory> GetAll()
        {
            DataTable categoriesTable = ExecuteQuery("SELECT * FROM RideCategories");
            return HandleData(categoriesTable);
        }

        public RideCategory GetById(int id)
        {
            DataTable categoriesTable = ExecuteQuery($"SELECT * FROM RideCategories WHERE RideCategoryId = {id}");
            return HandleData(categoriesTable).FirstOrDefault();
        }

        public int Insert(RideCategory category)
        {
            return ExecuteNonQuery($"INSERT INTO RideCategories VALUES('{category.Name}', '{category.Description}')");
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
