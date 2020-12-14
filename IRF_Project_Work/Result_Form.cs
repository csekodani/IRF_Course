﻿using IRF_Project_Work.Entities;
using IRF_Project_Work.MnbServiceReference;
using IRF_Project_Work.RestAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace IRF_Project_Work
{
    public partial class Result_Form : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<NameDay> NameDays = new BindingList<NameDay>();
        Weather resultWeater = new Weather(); //instance that we will display and get data in
        

        public Result_Form()
        {
            
            InitializeComponent();
            FillNameDayList();
            GetCurrentExchangeRates();
            DisplayNameDay();
            LoadWeatherData();
            DisplayWeather();
            mnbRateDataGridView.DataSource = Rates;
            
        }
        public void LoadWeatherData()
        {
            //run request, and get the response to resultWeather properties

             var GotResponse = WeatherProcessor.LoadWeather("Budapest",LangChooser.Hungarian,UnitChooser.Standard);

        }

        public void DisplayWeather()
        {
            //set all labels accourding to the data of the instance
            // e.g.  label98.Text= resultWeather.Preassure

        }
        public void DisplayNameDay()        //displays name on the label of the form
        {
            foreach (NameDay item in NameDays)
            {
                if ((item.Honap==DateTime.Today.Month) && (item.Nap==DateTime.Today.Day))
                {
                    NevLabel.Visible = true;
                    NevLabel.Text = item.Nev;
                }
            }
        }
        public void FillNameDayList()
        {
            var xml = new XmlDocument();
            xml.Load(@"nevnapok.xml");                              // one nevnap is an item and has 3 nodes
            foreach (XmlElement item in xml.DocumentElement)        // honap- nap- nev with inner text as their value
            {
                var nd = new NameDay();
                    var honapChild = (XmlElement)item.ChildNodes[0];
                    nd.Honap = int.Parse(honapChild.InnerText);
                    var napChild = (XmlElement)item.ChildNodes[1];
                    nd.Nap = int.Parse(napChild.InnerText);
                    var nevChild = (XmlElement)item.ChildNodes[2];
                    nd.Nev = nevChild.InnerText;
    
                NameDays.Add(nd);
            }
        }
        public void GetCurrentExchangeRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrentExchangeRatesRequestBody();
            var response = mnbService.GetCurrentExchangeRates(request);
            var result = response.GetCurrentExchangeRatesResult;

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                //DocumentElement - MNBCurrentExchangeRates
                //element         - Day (has only 1 attribute (current date))
                // element childNodes - Rate (every Rate is a node with attributes )

                

                foreach (XmlElement item in element.ChildNodes)
                {
                    var rate = new RateData();
                    Rates.Add(rate);

                    rate.Currency = item.GetAttribute("curr");

                    var unit = decimal.Parse(item.GetAttribute("unit"));
                    var value = decimal.Parse(item.InnerText.ToString().Replace(',', '.')); //default separator conflict
                    if (unit != 0)
                    {
                        rate.Value = value / unit;
                    }
                }
                
            }



        }
        private void Result_Form_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach  (RateData item in Rates)
            {
                if (item.Currency == fxSearchTB.Text.ToUpper()) { fxSearchLabel.Visible = true; fxSearchLabel.Text = item.Value.ToString(); }
            }
        }
    }
}
