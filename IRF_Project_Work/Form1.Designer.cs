namespace IRF_Project_Work
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainLabel = new System.Windows.Forms.Label();
            this.radioBtn_ID = new System.Windows.Forms.RadioButton();
            this.radioBtn_Coord = new System.Windows.Forms.RadioButton();
            this.radioBtn_Name = new System.Windows.Forms.RadioButton();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Coord_Long = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.btn_GO = new System.Windows.Forms.Button();
            this.languageLabel = new System.Windows.Forms.Label();
            this.engFlag_CBox = new System.Windows.Forms.CheckBox();
            this.gerFlag_CBox = new System.Windows.Forms.CheckBox();
            this.hunFlag_CBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stand_Unit_CBox = new System.Windows.Forms.CheckBox();
            this.imp_Unit_CBox = new System.Windows.Forms.CheckBox();
            this.metric_Unit_CBox = new System.Windows.Forms.CheckBox();
            this.textBox_Coord_Lat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainLabel.Location = new System.Drawing.Point(57, 25);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(219, 25);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Keresett város adata:";
            this.MainLabel.UseMnemonic = false;
            // 
            // radioBtn_ID
            // 
            this.radioBtn_ID.AutoSize = true;
            this.radioBtn_ID.BackColor = System.Drawing.Color.Transparent;
            this.radioBtn_ID.Location = new System.Drawing.Point(41, 80);
            this.radioBtn_ID.Name = "radioBtn_ID";
            this.radioBtn_ID.Size = new System.Drawing.Size(36, 17);
            this.radioBtn_ID.TabIndex = 1;
            this.radioBtn_ID.TabStop = true;
            this.radioBtn_ID.Text = "ID";
            this.radioBtn_ID.UseVisualStyleBackColor = false;
            this.radioBtn_ID.CheckedChanged += new System.EventHandler(this.radioBtn_ID_CheckedChanged);
            // 
            // radioBtn_Coord
            // 
            this.radioBtn_Coord.AutoSize = true;
            this.radioBtn_Coord.BackColor = System.Drawing.Color.Transparent;
            this.radioBtn_Coord.Location = new System.Drawing.Point(41, 113);
            this.radioBtn_Coord.Name = "radioBtn_Coord";
            this.radioBtn_Coord.Size = new System.Drawing.Size(79, 17);
            this.radioBtn_Coord.TabIndex = 2;
            this.radioBtn_Coord.TabStop = true;
            this.radioBtn_Coord.Text = "Koordináta:";
            this.radioBtn_Coord.UseVisualStyleBackColor = false;
            this.radioBtn_Coord.CheckedChanged += new System.EventHandler(this.radioBtn_Coord_CheckedChanged);
            // 
            // radioBtn_Name
            // 
            this.radioBtn_Name.AutoSize = true;
            this.radioBtn_Name.BackColor = System.Drawing.Color.Transparent;
            this.radioBtn_Name.Location = new System.Drawing.Point(41, 147);
            this.radioBtn_Name.Name = "radioBtn_Name";
            this.radioBtn_Name.Size = new System.Drawing.Size(45, 17);
            this.radioBtn_Name.TabIndex = 3;
            this.radioBtn_Name.TabStop = true;
            this.radioBtn_Name.Text = "Név";
            this.radioBtn_Name.UseVisualStyleBackColor = false;
            this.radioBtn_Name.CheckedChanged += new System.EventHandler(this.radioBtn_Name_CheckedChanged);
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.LightBlue;
            this.textBox_ID.Location = new System.Drawing.Point(134, 80);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(100, 20);
            this.textBox_ID.TabIndex = 4;
            this.textBox_ID.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_ID_Validating);
            // 
            // textBox_Coord_Long
            // 
            this.textBox_Coord_Long.BackColor = System.Drawing.Color.LightBlue;
            this.textBox_Coord_Long.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_Coord_Long.Location = new System.Drawing.Point(134, 113);
            this.textBox_Coord_Long.Name = "textBox_Coord_Long";
            this.textBox_Coord_Long.Size = new System.Drawing.Size(73, 20);
            this.textBox_Coord_Long.TabIndex = 5;
            this.textBox_Coord_Long.Text = "Hosszúság";
            this.textBox_Coord_Long.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Coord_Long_Validating);
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.Color.LightBlue;
            this.textBox_Name.Location = new System.Drawing.Point(134, 147);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 6;
            this.textBox_Name.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Name_Validating);
            // 
            // btn_GO
            // 
            this.btn_GO.BackColor = System.Drawing.Color.Transparent;
            this.btn_GO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_GO.Location = new System.Drawing.Point(438, 243);
            this.btn_GO.Name = "btn_GO";
            this.btn_GO.Size = new System.Drawing.Size(106, 50);
            this.btn_GO.TabIndex = 7;
            this.btn_GO.Text = "Go";
            this.btn_GO.UseVisualStyleBackColor = false;
            this.btn_GO.Click += new System.EventHandler(this.btn_GO_Click);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.BackColor = System.Drawing.Color.Transparent;
            this.languageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.languageLabel.Location = new System.Drawing.Point(414, 25);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(200, 25);
            this.languageLabel.TabIndex = 8;
            this.languageLabel.Text = "Lekérdezés nyelve:";
            this.languageLabel.UseMnemonic = false;
            // 
            // engFlag_CBox
            // 
            this.engFlag_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.engFlag_CBox.BackgroundImage = global::IRF_Project_Work.Properties.Resources.usFlag;
            this.engFlag_CBox.Checked = true;
            this.engFlag_CBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.engFlag_CBox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.engFlag_CBox.FlatAppearance.BorderSize = 4;
            this.engFlag_CBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.engFlag_CBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.engFlag_CBox.Location = new System.Drawing.Point(551, 100);
            this.engFlag_CBox.Name = "engFlag_CBox";
            this.engFlag_CBox.Size = new System.Drawing.Size(63, 44);
            this.engFlag_CBox.TabIndex = 11;
            this.engFlag_CBox.UseVisualStyleBackColor = true;
            this.engFlag_CBox.CheckedChanged += new System.EventHandler(this.engFlag_CBox_CheckedChanged);
            // 
            // gerFlag_CBox
            // 
            this.gerFlag_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.gerFlag_CBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gerFlag_CBox.BackgroundImage")));
            this.gerFlag_CBox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gerFlag_CBox.FlatAppearance.BorderSize = 4;
            this.gerFlag_CBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.gerFlag_CBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.gerFlag_CBox.Location = new System.Drawing.Point(479, 100);
            this.gerFlag_CBox.Name = "gerFlag_CBox";
            this.gerFlag_CBox.Size = new System.Drawing.Size(65, 44);
            this.gerFlag_CBox.TabIndex = 10;
            this.gerFlag_CBox.UseVisualStyleBackColor = true;
            this.gerFlag_CBox.CheckedChanged += new System.EventHandler(this.gerFlag_CBox_CheckedChanged);
            // 
            // hunFlag_CBox
            // 
            this.hunFlag_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.hunFlag_CBox.BackgroundImage = global::IRF_Project_Work.Properties.Resources.hunFlag;
            this.hunFlag_CBox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.hunFlag_CBox.FlatAppearance.BorderSize = 4;
            this.hunFlag_CBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.hunFlag_CBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.hunFlag_CBox.Location = new System.Drawing.Point(408, 100);
            this.hunFlag_CBox.Name = "hunFlag_CBox";
            this.hunFlag_CBox.Size = new System.Drawing.Size(65, 44);
            this.hunFlag_CBox.TabIndex = 9;
            this.hunFlag_CBox.UseVisualStyleBackColor = true;
            this.hunFlag_CBox.CheckedChanged += new System.EventHandler(this.hunFlag_CBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(74, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mérési egység:";
            this.label1.UseMnemonic = false;
            // 
            // stand_Unit_CBox
            // 
            this.stand_Unit_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.stand_Unit_CBox.AutoSize = true;
            this.stand_Unit_CBox.Location = new System.Drawing.Point(45, 285);
            this.stand_Unit_CBox.Name = "stand_Unit_CBox";
            this.stand_Unit_CBox.Size = new System.Drawing.Size(60, 23);
            this.stand_Unit_CBox.TabIndex = 13;
            this.stand_Unit_CBox.Text = "Standard";
            this.stand_Unit_CBox.UseVisualStyleBackColor = true;
            this.stand_Unit_CBox.CheckedChanged += new System.EventHandler(this.stand_Unit_CBox_CheckedChanged);
            // 
            // imp_Unit_CBox
            // 
            this.imp_Unit_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.imp_Unit_CBox.AutoSize = true;
            this.imp_Unit_CBox.Location = new System.Drawing.Point(122, 285);
            this.imp_Unit_CBox.Name = "imp_Unit_CBox";
            this.imp_Unit_CBox.Size = new System.Drawing.Size(60, 23);
            this.imp_Unit_CBox.TabIndex = 14;
            this.imp_Unit_CBox.Text = "Imperiális";
            this.imp_Unit_CBox.UseVisualStyleBackColor = true;
            this.imp_Unit_CBox.CheckedChanged += new System.EventHandler(this.imp_Unit_CBox_CheckedChanged);
            // 
            // metric_Unit_CBox
            // 
            this.metric_Unit_CBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.metric_Unit_CBox.AutoSize = true;
            this.metric_Unit_CBox.Checked = true;
            this.metric_Unit_CBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metric_Unit_CBox.Location = new System.Drawing.Point(197, 285);
            this.metric_Unit_CBox.Name = "metric_Unit_CBox";
            this.metric_Unit_CBox.Size = new System.Drawing.Size(57, 23);
            this.metric_Unit_CBox.TabIndex = 15;
            this.metric_Unit_CBox.Text = "Metrikus";
            this.metric_Unit_CBox.UseVisualStyleBackColor = true;
            this.metric_Unit_CBox.CheckedChanged += new System.EventHandler(this.metric_Unit_CBox_CheckedChanged);
            // 
            // textBox_Coord_Lat
            // 
            this.textBox_Coord_Lat.BackColor = System.Drawing.Color.LightBlue;
            this.textBox_Coord_Lat.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_Coord_Lat.Location = new System.Drawing.Point(234, 112);
            this.textBox_Coord_Lat.Name = "textBox_Coord_Lat";
            this.textBox_Coord_Lat.Size = new System.Drawing.Size(73, 20);
            this.textBox_Coord_Lat.TabIndex = 16;
            this.textBox_Coord_Lat.Text = "Szélesség";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(636, 354);
            this.Controls.Add(this.textBox_Coord_Lat);
            this.Controls.Add(this.metric_Unit_CBox);
            this.Controls.Add(this.imp_Unit_CBox);
            this.Controls.Add(this.stand_Unit_CBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.engFlag_CBox);
            this.Controls.Add(this.gerFlag_CBox);
            this.Controls.Add(this.hunFlag_CBox);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.btn_GO);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.textBox_Coord_Long);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.radioBtn_Name);
            this.Controls.Add(this.radioBtn_Coord);
            this.Controls.Add(this.radioBtn_ID);
            this.Controls.Add(this.MainLabel);
            this.Name = "Form1";
            this.Text = "Morning Starter App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.RadioButton radioBtn_ID;
        private System.Windows.Forms.RadioButton radioBtn_Coord;
        private System.Windows.Forms.RadioButton radioBtn_Name;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Coord_Long;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button btn_GO;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.CheckBox hunFlag_CBox;
        private System.Windows.Forms.CheckBox gerFlag_CBox;
        private System.Windows.Forms.CheckBox engFlag_CBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox stand_Unit_CBox;
        private System.Windows.Forms.CheckBox imp_Unit_CBox;
        private System.Windows.Forms.CheckBox metric_Unit_CBox;
        private System.Windows.Forms.TextBox textBox_Coord_Lat;
    }
}

