using IRF_Project_Work.Entities;
using IRF_Project_Work.MnbServiceReference;
using IRF_Project_Work.RestAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        private ExchangeController _controller = new ExchangeController();

       
        public Result_Form(string id,decimal lon ,decimal lat,string city, int searchType, LangChooser lc, UnitChooser uc)
        {
            InitializeComponent();
            this.Paint += Result_Form_Paint;
            FillNameDayList();
            GetCurrentExchangeRates();
            DisplayNameDay();
            LoadWeatherData(id,lon,lat,city,searchType,lc,uc);
            DisplayWeather();
            mnbRateDataGridView.DataSource = Rates;
            dgwSaveExchange.DataSource = _controller.ExchangeManager.Exchanges;

        }

        private void Result_Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(57, 128, 227), Color.FromArgb(19, 54, 99), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        public async void LoadWeatherData(string id, decimal lon, decimal lat, string city, int searchType,LangChooser lc,UnitChooser uc)
        {
            XmlDocument GotResponse = new XmlDocument();

            if (searchType == 1) GotResponse = await WeatherProcessor.LoadWeather(id, lc, uc);
            if (searchType == 2) GotResponse = await WeatherProcessor.LoadWeather(lat, lon, lc, uc);
            if (searchType == 3) GotResponse = await WeatherProcessor.LoadWeather(city, lc, uc);

            if (GotResponse.LastChild != null)
            {

                foreach (XmlElement element in GotResponse.LastChild)
                {   //LastChild is current the other oe is the format header
                    //on this level we have 11 nodes
                    if (element.Name == "city")
                    {
                        resultWeater.ID = int.Parse(element.GetAttribute("id"));
                        resultWeater.Name = element.GetAttribute("name");
                        foreach (XmlElement item in element)            // city has 4 childNodes - iterete through
                        {
                            if (item.Name == "coord")
                            {
                                resultWeater.Longitude = decimal.Parse(item.GetAttribute("lon"));
                                resultWeater.Latitude = decimal.Parse(item.GetAttribute("lat"));
                            }
                            if (item.Name == "country")
                            {
                                resultWeater.CountrySign = item.InnerText;
                            }
                            if (item.Name == "sun")
                            {
                                resultWeater.SunRise = DateTime.Parse(item.GetAttribute("rise"));
                                resultWeater.SunSet = DateTime.Parse(item.GetAttribute("set"));
                            }
                        }
                    }
                    if (element.Name == "temperature")
                    {
                        resultWeater.Temperature = decimal.Parse(element.GetAttribute("value"));
                        resultWeater.TemperatureUnit = element.GetAttribute("unit");
                    }
                    if (element.Name == "humidity")
                    {
                        resultWeater.Humidity = int.Parse(element.GetAttribute("value"));
                        resultWeater.HumidityUnit = element.GetAttribute("unit");
                    }
                    if (element.Name == "pressure")
                    {
                        resultWeater.Pressure = int.Parse(element.GetAttribute("value"));
                        resultWeater.PressureUnit = element.GetAttribute("unit");
                    }
                    if (element.Name == "wind")
                    {
                        foreach (XmlElement item in element)
                        {
                            if (item.Name == "speed")
                            {
                                resultWeater.WindSpeed = decimal.Parse(item.GetAttribute("value"));
                                resultWeater.WindSpeedUnit = item.GetAttribute("unit");
                            }
                            if (item.Name == "direction")
                            {
                                resultWeater.WindDirection = item.GetAttribute("name");
                            }
                        }
                    }
                    if (element.Name == "clouds")
                    {
                        resultWeater.CloudName = element.GetAttribute("name");
                    }
                    if (element.Name == "visibility")
                    {
                        resultWeater.Visibility = int.Parse(element.GetAttribute("value"));
                    }
                    if (element.Name == "lastupdate")
                    {
                        resultWeater.LastUpdate = DateTime.Parse(element.GetAttribute("value"));
                    }
                }
            }
            else
            {
                MessageBox.Show("Nem található ilyen adat, a bezárást követően próblája újra", "Hiba", MessageBoxButtons.OK);
                this.Close();
            }
            DisplayWeather();
         }

        public void DisplayWeather()    //label setting- hardcoding
        {
            lbwID.Text = resultWeater.ID.ToString();
            lbwID.Visible = true;

            lbwName.Text = resultWeater.Name;
            lbwName.Visible = true;

            lbwLongitude.Text = resultWeater.Longitude.ToString();
            lbwLongitude.Visible = true;

            lbwLatitude.Text = resultWeater.Latitude.ToString();
            lbwLatitude.Visible = true;

            lbwCountry.Text = resultWeater.CountrySign;
            lbwCountry.Visible = true;

            lbwSunRise.Text = resultWeater.SunRise.Hour.ToString()+" : "+ resultWeater.SunRise.Minute.ToString();
            lbwSunRise.Visible = true;

            lbwSunSet.Text = resultWeater.SunSet.Hour.ToString() + " : " + resultWeater.SunSet.Minute.ToString();
            lbwSunSet.Visible = true;

            lbwTemperature.Text = resultWeater.Temperature.ToString();
            lbwTemperature.Visible = true;

            lbwHumidity.Text = resultWeater.Humidity.ToString();
            lbwHumidity.Visible = true;

            lbwPressure.Text = resultWeater.Pressure.ToString();
            lbwPressure.Visible = true;

            lbwWindSpeed.Text = resultWeater.WindSpeed.ToString();
            lbwWindSpeed.Visible = true;

            lbwWindDirection.Text = resultWeater.WindDirection;
            lbwWindDirection.Visible = true;

            lbwCloud.Text = resultWeater.CloudName;
            lbwCloud.Visible = true;

            lbwVisibility.Text = resultWeater.Visibility.ToString();
            lbwVisibility.Visible = true;

            lbwLastUpdated.Text = resultWeater.LastUpdate.ToString();
            lbwLastUpdated.Visible = true;

            lbwTempUnit.Text = resultWeater.TemperatureUnit;
            lbwTempUnit.Visible = true;

            lbwHumidUnit.Text = resultWeater.HumidityUnit;
            lbwHumidUnit.Visible = true;

            lbwPressureUnit.Text = resultWeater.PressureUnit;
            lbwPressureUnit.Visible = true;

            lbwWindspeedUnit.Text = resultWeater.WindSpeedUnit;
            lbwWindspeedUnit.Visible = true;
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
            //for some reason the textbox text property comes one function later...
            mnbRateDataGridView.CurrentCell.Selected = false;
            if (fxSearchTB.Text.Length == 3)
            {

                int runner = 0;
                
                // runner without selection
                foreach (RateData item in Rates)
                {

                    if (item.Currency == fxSearchTB.Text.ToUpper())
                    {
                        fxSearchLabel.Visible = true;
                        fxSearchLabel.Text = item.Value.ToString();
                        mnbRateDataGridView.ClearSelection();
                        mnbRateDataGridView.Rows[runner].Cells[0].Selected = true;
                        mnbRateDataGridView.CurrentCell = mnbRateDataGridView.Rows[runner].Cells[0];
                        break;//found it
                    }
                    runner++;
                   
                }
            }
        }

        private void btnAddFavorites_Click(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(fxSearchLabel.Text);
                _controller.AddFavorites(fxSearchTB.Text.ToUpper(),value);
                fxSearchTB.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteFromSaved_Click(object sender, EventArgs e)
        {
            if (_controller.ExchangeManager.Exchanges.Count==0)
            {
                MessageBox.Show("Nincs törölhető elem", "Elem nem található", MessageBoxButtons.OK);
            }
            //törlés
            foreach (RateData item in _controller.ExchangeManager.Exchanges)
            {
                string str = item.Currency;
                decimal dec = item.Value;
                decimal i;
                if (decimal.TryParse(dgwSaveExchange.CurrentCell.Value.ToString(), out i))
                {
                    //if decimal than we go and search the item in the bindingList
                    if (dec==i)
                    {
                        _controller.ExchangeManager.Exchanges.Remove(item);
                        break;
                    }
                }
                else
                {
                    if (str == (string)dgwSaveExchange.CurrentCell.Value)
                    {
                        _controller.ExchangeManager.Exchanges.Remove(item);
                        break;// cant handle modification of list in the middle of the foreach loop
                    }
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Kedvencek mentése";
            sf.DefaultExt = "csv";
            sf.Filter = "CSV Files (*.csv)|*csv";

            

            if (sf.ShowDialog() == DialogResult.OK)
            {

                using (StreamWriter outputFile = new StreamWriter(sf.FileName))
                {
                    foreach (var item in _controller.ExchangeManager.Exchanges)
                    {
                        outputFile.WriteLine(item.Currency+","+item.Value.ToString());
                    }
                }
            }
        }

        private void mnbRateDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (mnbRateDataGridView.SelectedCells.Count == 1)
            {
                int ri= mnbRateDataGridView.SelectedCells[0].RowIndex;
                mnbRateDataGridView.CurrentCell = mnbRateDataGridView.Rows[ri].Cells[0];
                

                foreach (RateData item in Rates)
                {
                    string str = item.Currency;
                    decimal dec = item.Value;
                    decimal i;
                    
                    if (decimal.TryParse(mnbRateDataGridView.CurrentCell.Value.ToString(), out i))
                    {
                        //if decimal than we go and search the item in the bindingList
                        if (dec == i)
                        {
                            //then fx label set
                            fxSearchTB.Text = item.Currency;
                            fxSearchLabel.Text = item.Value.ToString();
                            break;
                        }
                    }
                    else
                    {
                        if (str == (string)mnbRateDataGridView.CurrentCell.Value)
                        {
                            fxSearchTB.Text = item.Currency;
                            fxSearchLabel.Text = item.Value.ToString();
                            break;

                        }
                    }
                    
                }
            }
            else if (mnbRateDataGridView.SelectedCells.Count > 1)
            {
                MessageBox.Show("Túl sok kijelolt elem", "Hiba", MessageBoxButtons.OK);
            }
        }

        private void mnbRateDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
