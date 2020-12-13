using IRF_Project_Work.Entities;
using IRF_Project_Work.MnbServiceReference;
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

namespace IRF_Project_Work
{
    public partial class Result_Form : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        


        public Result_Form()
        {
            
            InitializeComponent();
            GetCurrentExchangeRates();
            mngRateDataGridView.DataSource = Rates;
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
