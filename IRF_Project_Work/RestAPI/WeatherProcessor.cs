using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.RestAPI
{
    public class WeatherProcessor
    {
        string apiKey = "1e98a6276b52c465746e1853aef68c90"; // my personal apiKey
        
        public async Task LoadWeather(int id, int lang)
        {

            string url = $"http://api.openweathermap.org/data/2.5/weather?id={ id }&appid={ apiKey }";
        }
        public async Task LoadWeather(decimal latit, decimal longit, int lang)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={ latit }&lon={longit}&appid={ apiKey }";
        }
        public async Task LoadWeather(string City, int lang)
        {
            string url =$"api.openweathermap.org/data/2.5/weather?q=London&appid={ apiKey }";
        }
    }
}
