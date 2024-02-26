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
    public partial class frmAdmin : Form
    {
        private OleDbConnection connection = new OleDbConnection(); // Create command object.
        static int[] Marks = new int[5];    // Marks array will store the students marks

        public frmAdmin()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Students.accdb;Persist Security Info=False;";   // Connect to the access database.
            InitializeComponent();
        }

        // When the form loads, the PopulateCmbName() method will display students in the combo box and the disableUpdate() method will be called to disable certain features and hide certain button and labels
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            PopulateCmbName();  // Students will be displayed in the combo box
            disableUpdate();    // disable certain features and hide certain button and labels
        }

        // Method will enable certain elements and make certain elements visible
        public void enableUpdate()
        {
            txtBoxFName.Enabled = true;
            txtBoxLName.Enabled = true;
            txtBoxBirthMonth.Enabled = true;
            txtBoxBirthDay.Enabled = true;
            txtBoxBirthYear.Enabled = true;
            txtBoxUsername.Enabled = true;
            txtBoxPassword.Enabled = true;
            btnDelete.Visible = true;
            txtMarks.Enabled = true;
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
            btnSaveNew.Visible = false;
            btnDelete.Visible = false;
            btnChart.Visible = false;
            btnClearChart.Visible = false;
            btnEdit.Visible = false;
            btnExitMode.Visible = false;
            btnExport.Visible = false;
        }

        // Students will be displayed in the combo box
        private void PopulateCmbName()
        {
            // try catch will catch any exceptions that occur
            try
            {
                connection.Open();      // Open the connection
                OleDbCommand command = new OleDbCommand();  // Create command object.
                command.Connection = connection;    // Have the command object connect to the database

                // Select all the users except admin
                string query = "SELECT LastName, FirstName FROM tblStudents WHERE UserName <> 'admin'";
                command.CommandText = query;    // Store the query as a command
                OleDbDataReader reader = command.ExecuteReader();   // Execute the query

                // While the reader is reading, add the students to the combo box
                while (reader.Read())
                {
                    cmbNames.Items.Add(reader[0].ToString() + ", " + reader[1].ToString());
                }
                reader.Close();     // Close the reader
                connection.Close();     // Close the connection
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());  // Output the exception
                connection.Close();     // Close the connection
            }
        }

        // When a student is selected in the combo box, their info and marks will be displayed
        private void cmbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            // try catch will catch any exceptions that occur
            try
            {
                txtMarks.Text = "";     // Empty the marks text box
                btnExport.Visible = true;   // Make the export button visible
                connection.Open();  // Open connection to database
                OleDbCommand command = new OleDbCommand();  // Command object for running the query
                command.Connection = connection;    // Have the command object connect to the database

                // Select the first name, last name, username, password, date of birth, student id, and the marks of the selected student
                string query = "SELECT FirstName, LastName, UserName, Password, DOB, StuID, Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblStudents WHERE LastName + ', ' + FirstName='" + cmbNames.Text + "'";
                command.CommandText = query;    // Store the query as a command
                OleDbDataReader reader = command.ExecuteReader();   // Execute the query

                reader.Read();      // Read the database

                // Output the info that is selected into the corresponding text boxes
                txtBoxFName.Text = reader["FirstName"].ToString();
                txtBoxLName.Text = reader["LastName"].ToString();
                txtBoxStuID.Text = reader["StuID"].ToString();
                txtBoxUsername.Text = reader["UserName"].ToString();
                txtBoxPassword.Text = reader["Password"].ToString();
                string DOB = Convert.ToDateTime(reader["DOB"].ToString()).ToString("dd/MMM/yy");
                txtBoxBirthDay.Text = DOB.Substring(0, 2);
                txtBoxBirthMonth.Text = DOB.Substring(3, 3);
                txtBoxBirthYear.Text = DOB.Substring(7, 2);
                
                // Output marks and store them into marks array
                for (int i = 0; i < 5; i++)
                {
                    txtMarks.Text += "Mark " +  (i + 1) + ": " + (reader[i + 6].ToString()) + Environment.NewLine;  // Output marks
                    Marks[i] = int.Parse(reader[i + 6].ToString());     // Store into marks array
                }

                reader.Close();     // Close the reader
                connection.Close();     // Close the connection
                btnChart.Visible = true;    // Make the chart visible
                btnClearChart.Visible = true;   // Make the clear chart button visible
                btnEdit.Visible = true;     // Make the edit button visible
                btnDelete.Visible = true;   // Make the delete button visible

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

        // Method enables different items on the form
        private void enableNew()
        {
            txtMarks.Enabled = true;
            txtBoxFName.Enabled = true;
            txtBoxLName.Enabled = true;
            txtBoxBirthDay.Enabled = true;
            txtBoxBirthMonth.Enabled = true;
            txtBoxBirthYear.Enabled = true;
            txtBoxUsername.Enabled = true;
            txtBoxUsername.Enabled = true;
            txtBoxPassword.Enabled = true;
            cmbNames.Enabled = false;
            btnSaveNew.Visible = true;
            btnExitMode.Visible = true;
        }

        // Empty text boxes
        private void clearText()
        {
            txtBoxFName.Text = "";
            txtBoxLName.Text = "";
            txtBoxBirthDay.Text = "";
            txtBoxBirthYear.Text = "";
            txtBoxUsername.Text = "";
            txtBoxStuID.Text = "";
            txtMarks.Text = "";
            txtBoxPassword.Text = "";
            txtBoxBirthMonth.Text = "";
            cmbNames.Text = "";
            lblLevel.Text = "";
        }

        // When the new button is clicked, the user will be given the ability to add a new user
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMarks.Enabled = false;   // Disable Marks text box
            DialogResult dialogResult = MessageBox.Show("Enter new data?", "Entering Data", MessageBoxButtons.YesNo);   // Ask user if they want to enter new data
            
            // if the user says yes then put them change the page so that we are able to add new users
            if (dialogResult == DialogResult.Yes)
            {
                btnEdit.Visible = false;    // Make edit button invisible
                enableNew();    // Enable the items that are needed for adding new users
                clearText();    // Clear text boxes
                clearChart();   // Clear the chart
                btnChart.Visible = false;   // Make the chart button invisible
                btnClearChart.Visible = false;  // Make the clear chart button invisible
                btnDelete.Visible = false;      // Make the delete button invisible
            }
        }

        // When the save new button is clicked, then the info the user has given will be added to the database
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            // try catch will catch any exceptions that occur
            try
            {
                connection.Open();  // Open connection to database
                OleDbCommand command = new OleDbCommand();  // Command object for running the query
                command.Connection = connection;    // Have the command variable connect to the database
                
                string DateOfBirth;     // Used for putting the birth month in letter form

                // Check if any of the text boxes are empty or have white space, if there is no issues then save the new user info to the database
                // Learned from: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0
                if (string.IsNullOrWhiteSpace(txtBoxFName.Text) || string.IsNullOrWhiteSpace(txtBoxLName.Text) || string.IsNullOrWhiteSpace(txtBoxUsername.Text) || string.IsNullOrWhiteSpace(txtBoxPassword.Text) || string.IsNullOrWhiteSpace(txtBoxBirthMonth.Text) || string.IsNullOrWhiteSpace(txtBoxBirthDay.Text) || string.IsNullOrWhiteSpace(txtBoxBirthYear.Text))
                {
                    MessageBox.Show("Not all information has been submitted.");
                }
                else
                {
                    int BirthMonthNum = 0;      // Used for birth month in number format
                    int BirthDay = 0;   // Used for birth day
                    int BirthYear = 0;      // Used for birth year

                    // Make sure that the user entered in proper inputs for the DOB
                    if (int.TryParse(txtBoxBirthMonth.Text, out BirthMonthNum) && int.TryParse(txtBoxBirthDay.Text, out BirthDay) && int.TryParse(txtBoxBirthYear.Text, out BirthYear))
                    {
                        // In the access database birth month writen with letters so change month format to letters
                        if (BirthMonthNum == 1)
                        {
                            DateOfBirth = "Jan";
                        }
                        else if (BirthMonthNum == 2)
                        {
                            DateOfBirth = "Feb";
                        }
                        else if (BirthMonthNum == 3)
                        {
                            DateOfBirth = "Mar";
                        }
                        else if (BirthMonthNum == 4)
                        {
                            DateOfBirth = "Apr";
                        }
                        else if (BirthMonthNum == 5)
                        {
                            DateOfBirth = "May";
                        }
                        else if (BirthMonthNum == 6)
                        {
                            DateOfBirth = "Jun";
                        }
                        else if (BirthMonthNum == 7)
                        {
                            DateOfBirth = "Jul";
                        }
                        else if (BirthMonthNum == 8)
                        {
                            DateOfBirth = "Aug";
                        }
                        else if (BirthMonthNum == 9)
                        {
                            DateOfBirth = "Sep";
                        }
                        else if (BirthMonthNum == 10)
                        {
                            DateOfBirth = "Oct";
                        }
                        else if (BirthMonthNum == 11)
                        {
                            DateOfBirth = "Nov";
                        }
                        else if (BirthMonthNum == 12)
                        {
                            DateOfBirth = "Dec";
                        }
                        else
                        {
                            MessageBox.Show("Invalid Input");
                        }

                        // Insert the info the user provided into the database
                        // [] are used for handling reserved keywords. Learned from: https://stackoverflow.com/questions/52898/what-is-the-use-of-the-square-brackets-in-sql-statements
                        string query = "INSERT INTO tblStudents (FirstName, LastName, UserName, [Password], DOB) VALUES ('" + txtBoxFName.Text + "', '" + txtBoxLName.Text + "', '" + txtBoxUsername.Text + "', '" + txtBoxPassword.Text + "', '" + txtBoxBirthYear.Text + "-" + txtBoxBirthMonth.Text + "-" + txtBoxBirthDay.Text + "')";

                        command.CommandText = query;    // Store the query as a command
                        command.ExecuteNonQuery();      // Execute the query
                        connection.Close();     // Close the connection to the database
                        cmbNames.Items.Clear();     // Clear the combo box
                        PopulateCmbName();      // Insert the users into the combo box again. This time it will have the new user.
                    }
                    else    // if the user put invalid input then notify them
                    {
                        MessageBox.Show("Inavlid Input");
                        connection.Close();     // Close the connection to the database
                    }                    
                }
            }
            catch (Exception Ex)
            {
                connection.Close();     // Close the connection to the database
                MessageBox.Show(Ex.Message);    // Display the exception
            }
        }

        // When the delete button is clicked, the student selected in the combo box will be deleted from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ask the user if they want to delete the student
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student? This action cannot be undone.", "Delete Student?", MessageBoxButtons.YesNo);

            // if the user says yes then delete the user from the database
            if (dialogResult == DialogResult.Yes)
            {
                // try catch will catch any exceptions that occur
                try
                {
                    connection.Open();      // Open the connection to database
                    OleDbCommand command = new OleDbCommand();      // Command object for running the query 

                    command.Connection = connection;    // Have the command variable connect to the database

                    // Save the DOB in a unspecified variable
                    var DOB = Convert.ToDateTime(txtBoxBirthYear.Text + "-" + txtBoxBirthMonth.Text + "-" + txtBoxBirthDay.Text);

                    // Delete the student by looking at their student id
                    string query = "DELETE FROM tblStudents WHERE StuID = " + txtBoxStuID.Text;

                    command.CommandText = query;    // Store the query as a command
                    command.ExecuteNonQuery();      // Execute the query
                    MessageBox.Show("Data Deleted");    // Tell the user that the student has been deleted
                    connection.Close();     // Close the connection to the database
                    cmbNames.Items.Clear();     // Clear the combo box
                    clearText();    // Clear the text boxes
                    PopulateCmbName();      // Insert the users into the combo box again. This time it will have the new user.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);  // Dusplay the exception
                    connection.Close();     // Close the connection to the database
                }
            }
        }

        // When the edit button is clicked, the user will be asked if they want to go into edit mode. If they want to then a new form will appear where they can edit the users marks and info.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Ask the user if they want to enter edit mode
            DialogResult dialogResult = MessageBox.Show("You are about to enter Edit mode. Make your changes and hit save.", "Edit Mode", MessageBoxButtons.YesNo);

            // if they say yes then enter edit mode
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    this.Hide();    // hide the admin form
                    frmEdit frmEdit = new frmEdit(cmbNames.Text);   // Create a frmEdit form object of type frmEdit. This object will allow us to show the new form, and will pass the selected user as a parameter
                    frmEdit.ShowDialog();   // Open the edit form
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // When the chart button is clicked, the chart is displayed
        private void btnChart_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();  // Connect to the database
                OleDbCommand command = new OleDbCommand();  // Command object for running the query 
                command.Connection = connection;    // Have the command variable connect to the database

                // Select the marks of the student that we have selected by using their student id to check which student it is
                string query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblStudents WHERE StuID =" + txtBoxStuID.Text;
                command.CommandText = query;    // Store the query as a command
                OleDbDataReader reader = command.ExecuteReader();   // Execute the query
                chartMarks.Series["Marks"].YValuesPerPoint = 5; // Sets the number of y-values for each data point

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

        // This method clears the chart
        private void clearChart()
        {
            // Clear the chart not the series                     
            foreach (var series in chartMarks.Series)
            {
                series.Points.Clear();
            }
        }

        // When the clear chart button is clicked, the clearChart method is called that will clear the chart
        private void btnClearChart_Click(object sender, EventArgs e)
        {
            clearChart();   // Clears the chart
        }

        // When the exit mode button is clicked, the form will go back to normal mode from new user mode
        private void btnExitMode_Click(object sender, EventArgs e)
        {
            disableUpdate();    // Disable items
            clearText();    // Clear the text boxes
            cmbNames.Enabled = true;    // Enable combo box
        }

        // When the exit button is clicked, the form will close
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();       // Close the form
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
