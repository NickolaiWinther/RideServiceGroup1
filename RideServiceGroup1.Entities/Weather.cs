using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup1.Entities
{
    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public string IconUrl { get { return $"http://openweathermap.org/img/w/{Icon}.png"; } }
    }
}
