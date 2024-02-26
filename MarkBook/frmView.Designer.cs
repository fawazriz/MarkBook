namespace MarkBook
{
    partial class frmView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLevelIndicator = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBoxBirthYear = new System.Windows.Forms.TextBox();
            this.txtBoxBirthMonth = new System.Windows.Forms.TextBox();
            this.txtBoxBirthDay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnClearChart = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.chartMarks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.txtBoxLName = new System.Windows.Forms.TextBox();
            this.txtBoxFName = new System.Windows.Forms.TextBox();
            this.txtBoxStuID = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(51, 417);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(35, 13);
            this.lblLevel.TabIndex = 54;
            this.lblLevel.Text = "label2";
            this.lblLevel.Visible = false;
            // 
            // lblLevelIndicator
            // 
            this.lblLevelIndicator.AutoSize = true;
            this.lblLevelIndicator.Location = new System.Drawing.Point(16, 417);
            this.lblLevelIndicator.Name = "lblLevelIndicator";
            this.lblLevelIndicator.Size = new System.Drawing.Size(39, 13);
            this.lblLevelIndicator.TabIndex = 53;
            this.lblLevelIndicator.Text = "Level: ";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(696, 365);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 35);
            this.btnExport.TabIndex = 46;
            this.btnExport.Text = "Export User Info";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(696, 406);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 35);
            this.btnExit.TabIndex = 44;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBoxBirthYear
            // 
            this.txtBoxBirthYear.Location = new System.Drawing.Point(212, 146);
            this.txtBoxBirthYear.MaxLength = 2;
            this.txtBoxBirthYear.Name = "txtBoxBirthYear";
            this.txtBoxBirthYear.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthYear.TabIndex = 40;
            // 
            // txtBoxBirthMonth
            // 
            this.txtBoxBirthMonth.Location = new System.Drawing.Point(176, 146);
            this.txtBoxBirthMonth.MaxLength = 2;
            this.txtBoxBirthMonth.Name = "txtBoxBirthMonth";
            this.txtBoxBirthMonth.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthMonth.TabIndex = 39;
            // 
            // txtBoxBirthDay
            // 
            this.txtBoxBirthDay.Location = new System.Drawing.Point(138, 146);
            this.txtBoxBirthDay.MaxLength = 2;
            this.txtBoxBirthDay.Name = "txtBoxBirthDay";
            this.txtBoxBirthDay.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthDay.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "DOB (DD/MM/YY)";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(138, 186);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUsername.TabIndex = 41;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 193);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 51;
            this.lblUsername.Text = "Username";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(138, 227);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassword.TabIndex = 42;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 234);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 50;
            this.lblPassword.Text = "Password";
            // 
            // btnClearChart
            // 
            this.btnClearChart.Location = new System.Drawing.Point(703, 193);
            this.btnClearChart.Name = "btnClearChart";
            this.btnClearChart.Size = new System.Drawing.Size(75, 23);
            this.btnClearChart.TabIndex = 49;
            this.btnClearChart.Text = "Clear Chart";
            this.btnClearChart.UseVisualStyleBackColor = true;
            this.btnClearChart.Click += new System.EventHandler(this.btnClearChart_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(703, 149);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 48;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // chartMarks
            // 
            chartArea1.Name = "chartMarks";
            this.chartMarks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMarks.Legends.Add(legend1);
            this.chartMarks.Location = new System.Drawing.Point(315, 130);
            this.chartMarks.Name = "chartMarks";
            series1.ChartArea = "chartMarks";
            series1.Legend = "Legend1";
            series1.Name = "Marks";
            this.chartMarks.Series.Add(series1);
            this.chartMarks.Size = new System.Drawing.Size(348, 311);
            this.chartMarks.TabIndex = 47;
            this.chartMarks.Text = "chart1";
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(19, 267);
            this.txtMarks.Multiline = true;
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(276, 139);
            this.txtMarks.TabIndex = 45;
            // 
            // txtBoxLName
            // 
            this.txtBoxLName.Location = new System.Drawing.Point(138, 97);
            this.txtBoxLName.Name = "txtBoxLName";
            this.txtBoxLName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLName.TabIndex = 37;
            // 
            // txtBoxFName
            // 
            this.txtBoxFName.Location = new System.Drawing.Point(138, 51);
            this.txtBoxFName.Name = "txtBoxFName";
            this.txtBoxFName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFName.TabIndex = 36;
            // 
            // txtBoxStuID
            // 
            this.txtBoxStuID.Location = new System.Drawing.Point(138, 9);
            this.txtBoxStuID.Name = "txtBoxStuID";
            this.txtBoxStuID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStuID.TabIndex = 35;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(16, 100);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 34;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(16, 57);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 33;
            this.lblFirstName.Text = "First Name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(16, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(58, 13);
            this.lblID.TabIndex = 32;
            this.lblID.Text = "Student ID";
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLevelIndicator);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtBoxBirthYear);
            this.Controls.Add(this.txtBoxBirthMonth);
            this.Controls.Add(this.txtBoxBirthDay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnClearChart);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.chartMarks);
            this.Controls.Add(this.txtMarks);
            this.Controls.Add(this.txtBoxLName);
            this.Controls.Add(this.txtBoxFName);
            this.Controls.Add(this.txtBoxStuID);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblID);
            this.Name = "frmView";
            this.Text = "View Info";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLevelIndicator;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtBoxBirthYear;
        private System.Windows.Forms.TextBox txtBoxBirthMonth;
        private System.Windows.Forms.TextBox txtBoxBirthDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnClearChart;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarks;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.TextBox txtBoxLName;
        private System.Windows.Forms.TextBox txtBoxFName;
        private System.Windows.Forms.TextBox txtBoxStuID;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblID;
    }
}