using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;    // Namespace is used for linking to the access database
using iText.Kernel.Pdf;     // Using the iText.Kernel.PDF namespace for the assignment extension of downloading the student info as a pdf to the users computer. This is used for working with PDFs. Source: https://www.youtube.com/watch?v=7dyxOmf3zo8
using iText.Layout;         // Using the iText.Layout namespace for the assignment extension of downloading the student info as a pdf to the users computer. This is used for working with the overall layout of the pdf. Source: https://www.youtube.com/watch?v=7dyxOmf3zo8
using iText.Layout.Element;     // Using the iText.Layout.Elements namespace for the assignment extension of downloading the student info as a pdf to the users computer. This is used for working with the specific elements of the document such as paragraphs. Source: https://www.youtube.com/watch?v=7dyxOmf3zo8
using System.IO;    // Using System.IO so that I can access the Stream class and open the file dialog and save the file to the desired location. Source: https://stackoverflow.com/questions/4341488/how-can-i-prompt-a-user-to-choose-a-location-to-save-a-file
/*
Name: Fawaz Rizwan
Date: June 16, 2023
Program Name: Markbook
Program Description: To make a program that will allow students to view their marks and personal info. The admin account will be able to create new students and change the marks for students while students can only view info.
Enchancement: Used constructors, get/set method, encapsulation, and added a feature where the user can download info of the selected student as a pdf to their computer
*/
namespace MarkBook
{
    public partial class frmView : Form
    {
        private OleDbConnection connection = new OleDbConnection(); // Create object to connect to database.
        static int[] Marks = new int[5];    // Marks array will store the students marks
        string Username;    // Variable will store the users' username

        public frmView(string StudentUsername)  // StudentUsername parameter is the students username that is passed from the login form
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Students.accdb;Persist Security Info=False;";   // Connect to the access database.
            Username = StudentUsername;     // Make the Username variable equal to the StudentUsername parameter that is passed from the login form
            InitializeComponent();
        }

        // When the form loads, the students' info will be displayed.
        private void frmView_Load(object sender, EventArgs e)
        {
            // try catch will catch any exceptions that occur
            try
            {
                txtMarks.Text = "";
                disableUpdate();        // Disbale the text boxes
                btnExport.Visible = true;   // Make the export button visible
                connection.Open();      // Open connection to database
                OleDbCommand command = new OleDbCommand();  // Command object for running the query
                command.Connection = connection;    // Have the command variable connect to the database

                // Select the first name, last name, username, password, date of birth, student id, and the marks of the logged in student. We check what student is logged in by looking at the user name.
                string query = "SELECT FirstName, LastName, UserName, Password, DOB, StuID, Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblStudents WHERE UserName='" + Username + "'";
                command.CommandText = query;    // Store the query as a command
                OleDbDataReader reader = command.ExecuteReader();   // Execute the query

                reader.Read();  // Read the database

                // Put all the info into the designated text boxes. Convert all of the info to type string.
                txtBoxFName.Text = reader["FirstName"].ToString();
                txtBoxLName.Text = reader["LastName"].ToString();
                txtBoxStuID.Text = reader["StuID"].ToString();
                txtBoxUsername.Text = reader["UserName"].ToString();
                txtBoxPassword.Text = reader["Password"].ToString();
                string DOB = Convert.ToDateTime(reader["DOB"].ToString()).ToString("dd/MMM/yy");    // Convert to date time format of day/month/year
                txtBoxBirthDay.Text = DOB.Substring(0, 2);  // Use string manipulation of the DOB variable to get the date and output it into the designated text box for it
                txtBoxBirthMonth.Text = DOB.Substring(3, 3);    // Use string manipulation of the DOB variable to get the month and output it into the designated text box for it
                txtBoxBirthYear.Text = DOB.Substring(7, 2);     // Use string manipulation of the DOB variable to get the year and output it into the designated text box for it

                // Output the marks from the database into the marks text box and store them into the array
                for (int i = 0; i < 5; i++)
                {
                    txtMarks.Text += "Mark " + (i + 1) + ": " + (reader[i + 6].ToString()) + Environment.NewLine;
                    Marks[i] = int.Parse(reader[i + 6].ToString());     // Store the marks from the database into the Marks array
                }

                reader.Close();     // Close the reader
                connection.Close();     // Close the connection
                btnChart.Visible = true;    // Make the button for viewing the chart visible
                btnClearChart.Visible = true;   // Make the button for clearing the chart visible

                int StudentAverage = 0;     // Integer for student average

                // Calculate the student average
                for (int i = 0; i < Marks.Length; i++)  // Add the marks
                {
                    StudentAverage += Marks[i];
                }
                StudentAverage /= 5;    // Divide by number of marks

                // Determine the students' level based of their average and then display it
                if (StudentAverage >= 90 && StudentAverage <= 100)
                {
                    lblLevel.Text = "4+";
                }
                else if (StudentAverage >= 85 && StudentAverage < 90)
                {
                    lblLevel.Text = "4";
                }
                else if (StudentAverage >= 80 && StudentAverage < 85)
                {
                    lblLevel.Text = "4-";
                }
                else if (StudentAverage >= 75 && StudentAverage < 80)
                {
                    lblLevel.Text = "3+";
                }
                else if (StudentAverage >= 70 && StudentAverage < 75)
                {
                    lblLevel.Text = "3";
                }
                else if (StudentAverage >= 65 && StudentAverage < 70)
                {
                    lblLevel.Text = "3-";
                }
                else if (StudentAverage >= 60 && StudentAverage < 65)
                {
                    lblLevel.Text = "2+";
                }
                else if (StudentAverage >= 55 && StudentAverage < 60)
                {
                    lblLevel.Text = "2";
                }
                else if (StudentAverage >= 50 && StudentAverage < 55)
                {
                    lblLevel.Text = "2-";
                }
                else if (StudentAverage >= 45 && StudentAverage < 50)
                {
                    lblLevel.Text = "1+";
                }
                else if (StudentAverage >= 40 && StudentAverage < 45)
                {
                    lblLevel.Text = "1";
                }
                else if (StudentAverage >= 35 && StudentAverage < 40)
                {
                    lblLevel.Text = "1-";
                }
                else if (StudentAverage >= 0 && StudentAverage < 35)
                {
                    lblLevel.Text = "R";
                }

                lblLevel.Visible = true;    // Make the label for displaying the level true

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());     // Make the exception appear in the form of a messagebox
                connection.Close();     // Close the connection to the database
            }
        }

        // Method is used for disabling items and making them invisible
        public void disableUpdate()
        {
            txtBoxFName.Enabled = false;
            txtBoxLName.Enabled = false;
            txtBoxStuID.Enabled = false;
            txtBoxBirthDay.Enabled = false;
            txtBoxBirthMonth.Enabled = false;
            txtBoxBirthYear.Enabled = false;
            txtBoxUsername.Enabled = false;
            txtMarks.Enabled = false;
            txtBoxPassword.Enabled = false;
            txtBoxUsername.Enabled = false;
            btnChart.Visible = false;
            btnClearChart.Visible = false;
            btnExport.Visible = false;
        }

        // When the chart button is clicked the chart will appear
        private void btnChart_Click(object sender, EventArgs e)
        {
            // try catch will catch any exceptions that occur
            try
            {
                connection.Open();  // Open the connection to database
                OleDbCommand command = new OleDbCommand();  // Command object for running the query 
                command.Connection = connection;    // Have the command variable connect to the database

                string query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblStudents WHERE StuID =" + txtBoxStuID.Text;
                command.CommandText = query;    // Store the query as a command
                OleDbDataReader reader = command.ExecuteReader();   // Execute the query
                chartMarks.Series["Marks"].YValuesPerPoint = 5;     // Sets the number of y-values for each data point
                
                // While the reader is reading, clear the chart and put the number of marks on the x-axis of the chart and put level of each mark as the y-axis
                while (reader.Read())
                {
                    clearChart();   // Clear the chart

                    // Put the number of marks on the x-axis of the chart and put level of each mark as the y-axis
                    for (int x = 0; x < 5; x++)
                    {
                        this.chartMarks.Series["Marks"].Points.AddXY("Mark" + Convert.ToString(x + 1), reader[x].ToString());
                    }
                }
                connection.Close();     // Close the connection to the database
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // Make the exception appear in the form of a messagebox
                connection.Close();     // Close the connection
            }
        }

        // When the clear chart button is clicked the chart will be cleared
        private void btnClearChart_Click(object sender, EventArgs e)
        {
            clearChart();   // clearChart method is called to clear the chart
        }

        // clearChart method will clear the chart
        private void clearChart()
        {
            // Clear the chart not the series                     
            foreach (var series in chartMarks.Series)
            {
                series.Points.Clear();
            }
        }

        // When the exit button is clicked, the form will close
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();   // Close the form
        }

        // When the export user info button is clicked, the info of the student selected will be exported as a pdf
        // Learned code from: https://www.youtube.com/watch?v=7dyxOmf3zo8 and https://stackoverflow.com/questions/4341488/how-can-i-prompt-a-user-to-choose-a-location-to-save-a-file
        private void btnExport_Click(object sender, EventArgs e)
        {
            int MonthNum = 0;   // Will be used for putting the month in number form

            // Make the MonthNum variable equal to the corresponding number of the month of the student's birth.
            if (txtBoxBirthMonth.Text == "Jan")
            {
                MonthNum = 01;
            }
            else if (txtBoxBirthMonth.Text == "Feb")
            {
                MonthNum = 02;
            }
            else if (txtBoxBirthMonth.Text == "Mar")
            {
                MonthNum = 03;
            }
            else if (txtBoxBirthMonth.Text == "Apr")
            {
                MonthNum = 04;
            }
            else if (txtBoxBirthMonth.Text == "May")
            {
                MonthNum = 05;
            }
            else if (txtBoxBirthMonth.Text == "Jun")
            {
                MonthNum = 06;
            }
            else if (txtBoxBirthMonth.Text == "Jul")
            {
                MonthNum = 07;
            }
            else if (txtBoxBirthMonth.Text == "Aug")
            {
                MonthNum = 08;
            }
            else if (txtBoxBirthMonth.Text == "Sep")
            {
                MonthNum = 09;
            }
            else if (txtBoxBirthMonth.Text == "Oct")
            {
                MonthNum = 10;
            }
            else if (txtBoxBirthMonth.Text == "Nov")
            {
                MonthNum = 11;
            }
            else if (txtBoxBirthMonth.Text == "Dec")
            {
                MonthNum = 12;
            }

            // Create a student object. This uses a constructor with the parameters of the students first name, last name, user name, password, birth day, birth month, birth year, and student id number
            // Constructors are a method that is used when intializing an object. It can be used for assigning the values of variables when the object is created. Learned from : https://www.w3schools.com/cs/cs_constructors.php
            Student student = new Student(txtBoxFName.Text, txtBoxLName.Text, txtBoxUsername.Text, txtBoxPassword.Text, int.Parse(txtBoxBirthDay.Text), MonthNum, int.Parse(txtBoxBirthYear.Text), int.Parse(txtBoxStuID.Text));

            Stream myStream;    // Variable will be used to hold the stream for saving the pdf file
            SaveFileDialog saveFileDialog = new SaveFileDialog();   // Used for opening file dialog
            saveFileDialog.Filter = "pdf files (*.pdf)|*.pdf";      // Used for determining the type the file will save as
            string path = null;     // Used for holding the file path

            // FileDialog will open and the user will be asked to name and save the file somewhere
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    path = saveFileDialog.FileName;     // Path of the file is stored in the path variable
                    // Code to write the stream goes here.
                    myStream.Close();   // Closes the stream
                }

                PdfWriter pdfWriter = new PdfWriter(path);      // Create a PdfWriter object using the pdf file as a parameter
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);   // Create a PdfDocument object using the PdfWriter as a parameter
                Document document = new Document(pdfDocument);      // Create a Document object so that we can add content to the pdf

                // Add the student info and marks to the pdf
                document.Add(new Paragraph("First Name: " + student.FName));
                document.Add(new Paragraph("Last Name: " + student.LName));
                document.Add(new Paragraph("Student ID: " + student.StudentID));
                document.Add(new Paragraph("User Name: " + student.UName));
                document.Add(new Paragraph("Password: " + student.Pass));
                document.Add(new Paragraph("DOB (DD/MM/YY): " + student.BDate.ToString() + "/" + student.BMonth.ToString() + "/" + student.BYear.ToString()));

                for (int i = 0; i < Marks.Length; i++)
                {
                    student.Marks[i] = Marks[i];
                    document.Add(new Paragraph("Mark " + (i + 1) + ": " + student.Marks[i]));
                }
                document.Add(new Paragraph("Level: " + lblLevel.Text));

                document.Close();   // Close the document
            }
        }
    }
}
