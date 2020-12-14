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

namespace IRF_Project_Work
{
    public partial class Form1 : Form
    {
        LangChooser languageChoice = LangChooser.Hungarian;
        public Form1()
        {
            InitializeComponent();
            Api_Helper.InitializeClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_GO_Click(object sender, EventArgs e)
        {
            Result_Form f1 = new Result_Form();
            f1.Show();
          
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
        }

        private void imp_Unit_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stand_Unit_CBox.Checked) stand_Unit_CBox.Checked = false;
            if (metric_Unit_CBox.Checked) metric_Unit_CBox.Checked = false;
        }

        private void metric_Unit_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (imp_Unit_CBox.Checked) imp_Unit_CBox.Checked = false;
            if (stand_Unit_CBox.Checked) stand_Unit_CBox.Checked = false;
        }
    }
}
