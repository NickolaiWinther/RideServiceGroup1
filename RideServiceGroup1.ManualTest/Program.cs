using System;
using System.Collections.Generic;
using RideServiceGroup1.DAL;
using RideServiceGroup1.Entities;
using RideServiceGroup1.Web;
using System.Linq;
using System.Data.SqlClient;

namespace RideServiceGroup1.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RideRepository rideRepository = new RideRepository();
            CategoryRepository categoryRepository = new CategoryRepository();

            List<Ride> rides = new List<Ride>();
            rides = rideRepository.GetAll();
            foreach (var ride in rides)
            {
                Console.WriteLine(ride.Name);
            }
            Console.ReadLine();
        }
    }
}
