using System;
using System.Collections.Generic;
using RideServiceGroup1.DAL;
using RideServiceGroup1.Entities;
using RideServiceGroup1.Web;
using System.Linq;

namespace RideServiceGroup1.ManualTest
{
    class Program
    {
        static RideRepository rideRepository = new RideRepository();
        static CategoryRepository categoryRepository = new CategoryRepository();
        static void Main(string[] args)
        {
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
