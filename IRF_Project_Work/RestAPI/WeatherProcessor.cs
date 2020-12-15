using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IRF_Project_Work.RestAPI
{
    public class WeatherProcessor
    {
        
        
        public static async Task<XmlDocument> LoadWeather(int id, LangChooser lang, UnitChooser unit)
        {
            string apiKey = "1e98a6276b52c465746e1853aef68c90"; // my personal apiKey free and has a limit per day
            string langMode="en";
            string units="standard";
            XmlDocument myRestXML = new XmlDocument();
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
            string url = $"http://api.openweathermap.org/data/2.5/weather?id={ id }&mode=xml&lang={ langMode }&units={ units }&appid={ apiKey }";
            using (HttpResponseMessage response = await Api_Helper.ApiClient.GetAsync(url))
                {
                string streamString;
                if (response.IsSuccessStatusCode)
                    {
                    streamString = await response.Content.ReadAsStringAsync();
                    myRestXML.LoadXml(streamString);
                    return myRestXML;
                }
                    else
                    {
                    throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        public static async Task<XmlDocument> LoadWeather(decimal latit, decimal longit, LangChooser lang, UnitChooser unit)
        {
            string apiKey = "1e98a6276b52c465746e1853aef68c90"; // my personal apiKey free and has a limit per day
            string langMode = "en";
            string units = "standard";
            XmlDocument myRestXML = new XmlDocument();
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
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={ latit }&lon={longit}&lang={ langMode }&mode=xml&units={ units }&appid={ apiKey }";
            using (HttpResponseMessage response = await Api_Helper.ApiClient.GetAsync(url))
            {
                string streamString;
                if (response.IsSuccessStatusCode)
                {
                    streamString = await response.Content.ReadAsStringAsync();
                    myRestXML.LoadXml(streamString);
                    return myRestXML;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<XmlDocument> LoadWeather(string City, LangChooser lang, UnitChooser unit)
        {
            string apiKey = "1e98a6276b52c465746e1853aef68c90"; // my personal apiKey free and has a limit per day
            string langMode = "en";
            string units = "standard";
            XmlDocument myRestXML = new XmlDocument();
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
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={ City }&units={ units }&lang={ langMode }&mode=xml&appid={ apiKey }";
            using (HttpResponseMessage response = await Api_Helper.ApiClient.GetAsync(url))
            {
                string streamString;
                
                if (response.IsSuccessStatusCode)
                {
                    streamString= await response.Content.ReadAsStringAsync();
                    myRestXML.LoadXml(streamString);
                    return myRestXML;
                }
                else
                {
                    //MessageBox.Show(response.ReasonPhrase, "Hiba", MessageBoxButtons.OK);
                    // throw new Exception(response.ReasonPhrase);
                    return new XmlDocument();
                }
            }
        }
    }
}
