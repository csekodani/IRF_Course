using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.RestAPI
{
    public class WeatherProcessor
    {
        string apiKey = "1e98a6276b52c465746e1853aef68c90"; // my personal apiKey free and has a limit per day
        string langMode;
        string units;
        public async Task LoadWeather(int id, LangChooser lang, UnitChooser unit)
        {
            // language choice will set the language parameter
            if (lang == LangChooser.Hungarian)
            {
                langMode = "hu";
            }else if (lang == LangChooser.German)
            {
                langMode = "de";
            }else if (lang == LangChooser.English)
            {
                langMode = "en";
            }
            // unit choice will set the unit parameter
            if (unit == UnitChooser.Imperial)
            {
                units = "imperial";
            }
            else if (unit == UnitChooser.Metric)
            {
                units = "metric";
            }
            else if (unit== UnitChooser.Standard)
            {
                units = "standard";
            }
            string url = $"http://api.openweathermap.org/data/2.5/weather?id={ id }&lang={ langMode }&units={ unit }&appid={ apiKey }";
        }
        public async Task LoadWeather(decimal latit, decimal longit, LangChooser lang, UnitChooser unit)
        {   //language choice
            if (lang == LangChooser.Hungarian)
            {
                langMode = "hu";
            }
            else if (lang == LangChooser.German)
            {
                langMode = "de";
            }
            else if (lang == LangChooser.English)
            {
                langMode = "en";
            }
            //unit choice
            if (unit == UnitChooser.Imperial)
            {
                units = "imperial";
            }
            else if (unit == UnitChooser.Metric)
            {
                units = "metric";
            }
            else if (unit == UnitChooser.Standard)
            {
                units = "standard";
            }
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={ latit }&lon={longit}&lang={ langMode }&units={ unit }&appid={ apiKey }";
        }
        public async Task LoadWeather(string City, LangChooser lang, UnitChooser unit)
        {   //unit choice
            if (unit == UnitChooser.Imperial)
            {
                units = "imperial";
            }
            else if (unit == UnitChooser.Metric)
            {
                units = "metric";
            }
            else if (unit == UnitChooser.Standard)
            {
                units = "standard";
            }
            //language choice
            if (lang == LangChooser.Hungarian)
            {
                langMode = "hu";
            }
            else if (lang == LangChooser.German)
            {
                langMode = "de";
            }
            else if (lang == LangChooser.English)
            {
                langMode = "en";
            }
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={ City }&units={ unit }&lang={ langMode }&appid={ apiKey }";
        }
    }
}
