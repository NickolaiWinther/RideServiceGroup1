using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup1.Entities
{
    public class WeatherInfo
    {
        public List<Weather> Weather { get; set; }
        public WeatherMain Main { get; set; }
    }
}
