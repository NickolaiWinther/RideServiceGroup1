using Newtonsoft.Json;
using RideServiceGroup1.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RideServiceGroup1.DAL.Services
{
    public class WeatherService
    {
        public string Url { get; set; } = "http://api.openweathermap.org/data/2.5/weather?appid=5862724786fd66d515a841189e06efa9";

        public WeatherInfo GetWeatherFor(string city, string units)
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                using (var client = new WebClient())
                {
                    string json = client.DownloadString(Url + $"&q={city}&units={units}");
                    WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);
                    return weatherInfo;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
