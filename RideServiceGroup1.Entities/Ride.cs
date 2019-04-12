using System;
using System.Collections.Generic;

namespace RideServiceGroup1.Entities
{
    public class Ride
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RideCategory Category { get; set; }
        public Status Status { get; }
        public List<Report> Reports { get; set; }
        public string Url
        {
            get
            {
                return $"Img/{Name.ToLower()}.jpg";
            }
        }
        public Ride()
        {

        }

        public int NumbersOfShutdowns()
        {
            throw new NotImplementedException();
        }

        public int DaysSinceLastShutdown()
        {
            throw new NotImplementedException();
        }

        public string GetShortDescription()
        {
            throw new NotImplementedException();
        }
    }
}
