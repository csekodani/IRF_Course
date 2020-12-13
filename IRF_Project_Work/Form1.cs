﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_GO_Click(object sender, EventArgs e)
        {

        }

        private void radioBtn_ID_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = true;
            textBox_Coord.Visible = false;
            textBox_Name.Visible = false;

        }

        private void radioBtn_Coord_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = false;
            textBox_Coord.Visible = true;
            textBox_Name.Visible = false;

        }

        private void radioBtn_Name_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ID.Visible = false;
            textBox_Coord.Visible = false;
            textBox_Name.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hunFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gerFlag_CBox.Checked){ gerFlag_CBox.Checked = false; }
            if (engFlag_CBox.Checked) { engFlag_CBox.Checked = false; }
        }

        private void gerFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engFlag_CBox.Checked) { engFlag_CBox.Checked = false; }
            if (hunFlag_CBox.Checked) { hunFlag_CBox.Checked = false; }
        }

        private void engFlag_CBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hunFlag_CBox.Checked) { hunFlag_CBox.Checked = false; }
            if (gerFlag_CBox.Checked) { gerFlag_CBox.Checked = false; }
        }
    }
}
