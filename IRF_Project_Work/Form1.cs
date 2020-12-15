using IRF_Project_Work.Entities;
using IRF_Project_Work.RestAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace IRF_Project_Work
{
   
    public partial class Form1 : Form
    {
        LangChooser languageChoice = LangChooser.Hungarian;
        UnitChooser unitChoice = UnitChooser.Standard;
        bool validToGo = false;
        private const int WM_CLOSE = 0x0010;




        public Form1()
        {
            InitializeComponent();
            Api_Helper.InitializeClient();
            //BackGround paint
            this.Paint += Form1_Paint;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(57, 128, 227), Color.FromArgb(0,0,0), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        private void set_background(Object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;
            //the rectangle, the same size as Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_GO_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            if (validToGo==true)
            {


                decimal lon = 0;
                decimal lat = 0;
                string id = "";
                string name = "";
                int searchType = 0;
                LangChooser lc = LangChooser.Hungarian;
                UnitChooser uc = UnitChooser.Standard;
                if (textBox_ID.Visible == true)
                {
                    id = textBox_ID.Text;
                    searchType = 1;
                }
                if (textBox_Coord_Lat.Visible == true)
                {
                    lon = decimal.Parse(textBox_Coord_Long.Text);
                    lat = decimal.Parse(textBox_Coord_Lat.Text);
                    searchType = 2;
                }
                if (textBox_Name.Visible == true)
                {
                    name = textBox_Name.Text;
                    searchType = 3;
                }
                lc = languageChoice;
                uc = unitChoice;

                Result_Form f1 = new Result_Form(id, lon, lat, name, searchType, lc, uc);
                f1.Show();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE) // Attempting to close Form
                AutoValidate = AutoValidate.Disable; //this stops (all) validations

            base.WndProc(ref m);    //call the base method to handle other messages
        }
        private void radioBtn_ID_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = true;
            textBox_Coord_Long.Visible = false;
            textBox_Coord_Lat.Visible = false;
            textBox_Name.Visible = false;

        }

        private void radioBtn_Coord_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = false;
            textBox_Coord_Long.Visible = true;
            textBox_Coord_Lat.Visible = true;
            textBox_Name.Visible = false;

        }

        private void radioBtn_Name_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = false;
            textBox_Coord_Long.Visible = false;
            textBox_Coord_Lat.Visible = false;
            textBox_Name.Visible = true;
        }

        private void hunFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gerFlag_CBox.Checked){ gerFlag_CBox.Checked = false; }
            if (engFlag_CBox.Checked) { engFlag_CBox.Checked = false; }
            languageChoice = LangChooser.Hungarian;

        }

        private void gerFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engFlag_CBox.Checked) { engFlag_CBox.Checked = false; }
            if (hunFlag_CBox.Checked) { hunFlag_CBox.Checked = false; }
            languageChoice = LangChooser.German;
        }

        private void engFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hunFlag_CBox.Checked) { hunFlag_CBox.Checked = false; }
            if (gerFlag_CBox.Checked) { gerFlag_CBox.Checked = false; }
            languageChoice = LangChooser.English;
        }

        private void stand_Unit_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (imp_Unit_CBox.Checked) imp_Unit_CBox.Checked = false;
            if (metric_Unit_CBox.Checked) metric_Unit_CBox.Checked = false;
            unitChoice = UnitChooser.Standard;
        }

        private void imp_Unit_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stand_Unit_CBox.Checked) stand_Unit_CBox.Checked = false;
            if (metric_Unit_CBox.Checked) metric_Unit_CBox.Checked = false;
            unitChoice = UnitChooser.Imperial;
        }

        private void metric_Unit_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (imp_Unit_CBox.Checked) imp_Unit_CBox.Checked = false;
            if (stand_Unit_CBox.Checked) stand_Unit_CBox.Checked = false;
            unitChoice = UnitChooser.Metric;
        }

        private void textBox_ID_Validating(object sender, CancelEventArgs e)
        {
            int i;
            bool numConvert = int.TryParse(textBox_ID.Text, out i);
            if (string.IsNullOrWhiteSpace(textBox_ID.Text) && textBox_ID.Visible)
            {
                e.Cancel = true;

                MessageBox.Show("A kiválasztott keresési mező üres, kérem töltse ki!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if (!numConvert && textBox_ID.Visible)
            {
                e.Cancel = true;

                MessageBox.Show("A kitöltött érték nem szám!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if (numConvert && textBox_ID.Visible && (!string.IsNullOrWhiteSpace(textBox_ID.Text)))
            {
                validToGo = true;
            }
            else { validToGo = false; }
        }

        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"[a-zA-Z]";
            Regex rg = new Regex(pattern);
            if (string.IsNullOrWhiteSpace(textBox_Name.Text)&&textBox_Name.Visible)
            {
                e.Cancel = true;

                MessageBox.Show("A kiválasztott keresési mező üres, kérem töltse ki!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if(!rg.IsMatch(textBox_Name.Text)&&textBox_Name.Visible)
            {
                e.Cancel = true;
                MessageBox.Show("Regex!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if(rg.IsMatch(textBox_Name.Text) && textBox_Name.Visible&& !string.IsNullOrWhiteSpace(textBox_Name.Text))
            {
                validToGo = true;
            }
            else { validToGo = false; }
        }

        private void textBox_Coord_Long_Validating(object sender, CancelEventArgs e)
        {
            decimal latI;
            decimal lonI;
            bool latConvert = decimal.TryParse(textBox_Coord_Lat.Text, out latI);
            bool lonConvert = decimal.TryParse(textBox_Coord_Long.Text, out lonI);
            if ((string.IsNullOrWhiteSpace(textBox_Coord_Lat.Text) && textBox_Coord_Lat.Visible) || (string.IsNullOrWhiteSpace(textBox_Coord_Long.Text) && textBox_Coord_Long.Visible))
            { // at least one of them is empty
                e.Cancel = true;

                MessageBox.Show("A kiválasztott keresés mezeje üres, kérem töltse ki!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if ((!latConvert && textBox_Coord_Lat.Visible) ||(!lonConvert && textBox_Coord_Long.Visible))
            {
                e.Cancel = true;

                MessageBox.Show("A kitöltött értékek közt van nem szám érték!", "Kitöltés hiba", MessageBoxButtons.OK);
            }
            else if((latConvert && textBox_Coord_Lat.Visible) && (lonConvert && textBox_Coord_Long.Visible) && !(string.IsNullOrWhiteSpace(textBox_Coord_Lat.Text) && textBox_Coord_Lat.Visible) || (string.IsNullOrWhiteSpace(textBox_Coord_Long.Text) && textBox_Coord_Long.Visible))
            {
                validToGo = true;
            }
            else { validToGo = false; }
        }
    }
}
