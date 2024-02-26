namespace MarkBook
{
    partial class frmAdmin
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtBoxStuID = new System.Windows.Forms.TextBox();
            this.txtBoxFName = new System.Windows.Forms.TextBox();
            this.txtBoxLName = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.cmbNames = new System.Windows.Forms.ComboBox();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.chartMarks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnClearChart = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtBoxBirthYear = new System.Windows.Forms.TextBox();
            this.txtBoxBirthMonth = new System.Windows.Forms.TextBox();
            this.txtBoxBirthDay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitMode = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblLevelIndicator = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(35, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(58, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Student ID";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(35, 54);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(35, 97);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // txtBoxStuID
            // 
            this.txtBoxStuID.Location = new System.Drawing.Point(157, 6);
            this.txtBoxStuID.Name = "txtBoxStuID";
            this.txtBoxStuID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStuID.TabIndex = 4;
            // 
            // txtBoxFName
            // 
            this.txtBoxFName.Location = new System.Drawing.Point(157, 48);
            this.txtBoxFName.Name = "txtBoxFName";
            this.txtBoxFName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFName.TabIndex = 5;
            // 
            // txtBoxLName
            // 
            this.txtBoxLName.Location = new System.Drawing.Point(157, 94);
            this.txtBoxLName.Name = "txtBoxLName";
            this.txtBoxLName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLName.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(663, 22);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(501, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(501, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(582, 22);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNew.TabIndex = 12;
            this.btnSaveNew.Text = "Save";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // cmbNames
            // 
            this.cmbNames.FormattingEnabled = true;
            this.cmbNames.Location = new System.Drawing.Point(334, 24);
            this.cmbNames.Name = "cmbNames";
            this.cmbNames.Size = new System.Drawing.Size(121, 21);
            this.cmbNames.TabIndex = 13;
            this.cmbNames.SelectedIndexChanged += new System.EventHandler(this.cmbNames_SelectedIndexChanged);
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(38, 264);
            this.txtMarks.Multiline = true;
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(276, 139);
            this.txtMarks.TabIndex = 14;
            // 
            // chartMarks
            // 
            chartArea1.Name = "chartMarks";
            this.chartMarks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMarks.Legends.Add(legend1);
            this.chartMarks.Location = new System.Drawing.Point(334, 127);
            this.chartMarks.Name = "chartMarks";
            series1.ChartArea = "chartMarks";
            series1.Legend = "Legend1";
            series1.Name = "Marks";
            this.chartMarks.Series.Add(series1);
            this.chartMarks.Size = new System.Drawing.Size(348, 311);
            this.chartMarks.TabIndex = 15;
            this.chartMarks.Text = "chart1";
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(722, 146);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 16;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnClearChart
            // 
            this.btnClearChart.Location = new System.Drawing.Point(722, 190);
            this.btnClearChart.Name = "btnClearChart";
            this.btnClearChart.Size = new System.Drawing.Size(75, 23);
            this.btnClearChart.TabIndex = 17;
            this.btnClearChart.Text = "Clear Chart";
            this.btnClearChart.UseVisualStyleBackColor = true;
            this.btnClearChart.Click += new System.EventHandler(this.btnClearChart_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(157, 224);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(35, 231);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 19;
            this.lblPassword.Text = "Password";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(157, 183);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUsername.TabIndex = 10;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(35, 190);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 21;
            this.lblUsername.Text = "Username";
            // 
            // txtBoxBirthYear
            // 
            this.txtBoxBirthYear.Location = new System.Drawing.Point(231, 143);
            this.txtBoxBirthYear.MaxLength = 2;
            this.txtBoxBirthYear.Name = "txtBoxBirthYear";
            this.txtBoxBirthYear.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthYear.TabIndex = 9;
            // 
            // txtBoxBirthMonth
            // 
            this.txtBoxBirthMonth.Location = new System.Drawing.Point(195, 143);
            this.txtBoxBirthMonth.MaxLength = 2;
            this.txtBoxBirthMonth.Name = "txtBoxBirthMonth";
            this.txtBoxBirthMonth.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthMonth.TabIndex = 8;
            // 
            // txtBoxBirthDay
            // 
            this.txtBoxBirthDay.Location = new System.Drawing.Point(157, 143);
            this.txtBoxBirthDay.MaxLength = 2;
            this.txtBoxBirthDay.Name = "txtBoxBirthDay";
            this.txtBoxBirthDay.Size = new System.Drawing.Size(26, 20);
            this.txtBoxBirthDay.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "DOB (DD/MM/YY)";
            // 
            // btnExitMode
            // 
            this.btnExitMode.Location = new System.Drawing.Point(582, 54);
            this.btnExitMode.Name = "btnExitMode";
            this.btnExitMode.Size = new System.Drawing.Size(75, 23);
            this.btnExitMode.TabIndex = 13;
            this.btnExitMode.Text = "Exit Mode";
            this.btnExitMode.UseVisualStyleBackColor = true;
            this.btnExitMode.Click += new System.EventHandler(this.btnExitMode_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(714, 409);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 35);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(714, 368);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 35);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export User Info";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblLevelIndicator
            // 
            this.lblLevelIndicator.AutoSize = true;
            this.lblLevelIndicator.Location = new System.Drawing.Point(35, 414);
            this.lblLevelIndicator.Name = "lblLevelIndicator";
            this.lblLevelIndicator.Size = new System.Drawing.Size(39, 13);
            this.lblLevelIndicator.TabIndex = 30;
            this.lblLevelIndicator.Text = "Level: ";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(70, 414);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(35, 13);
            this.lblLevel.TabIndex = 31;
            this.lblLevel.Text = "label2";
            this.lblLevel.Visible = false;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLevelIndicator);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExitMode);
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
            this.Controls.Add(this.cmbNames);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtBoxLName);
            this.Controls.Add(this.txtBoxFName);
            this.Controls.Add(this.txtBoxStuID);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblID);
            this.Name = "frmAdmin";
            this.Text = "Admin Controls";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtBoxStuID;
        private System.Windows.Forms.TextBox txtBoxFName;
        private System.Windows.Forms.TextBox txtBoxLName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.ComboBox cmbNames;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarks;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnClearChart;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtBoxBirthYear;
        private System.Windows.Forms.TextBox txtBoxBirthMonth;
        private System.Windows.Forms.TextBox txtBoxBirthDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitMode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblLevelIndicator;
        private System.Windows.Forms.Label lblLevel;
    }
}