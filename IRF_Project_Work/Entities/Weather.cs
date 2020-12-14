using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.Entities
{
    public class Weather
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string CountrySign { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public decimal  Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public decimal WindSpeed { get; set; }
        public string WindDirection { get; set; } //name attribute
        public string CloudName { get; set; }
        public int Visibility { get; set; }
        public DateTime LastUpdate { get; set; }

        // unit parameters from xml
        public string TemperatureUnit { get; set; }
        public string HumidityUnit { get; set; }
        public string PressureUnit { get; set; }
        public string WindSpeedUnit { get; set; }
        
    }
}
