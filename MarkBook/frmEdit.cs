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
/*
Name: Fawaz Rizwan
Date: June 16, 2023
Program Name: Markbook
Program Description: To make a program that will allow students to view their marks and personal info. The admin account will be able to create new students and change the marks for students while students can only view info.
Enchancement: Used constructors, get/set method, encapsulation, and added a feature where the user can download info of the selected student as a pdf to their computer
*/
namespace MarkBook
{
    public partial class frmEdit : Form
    {
        private OleDbConnection connection = new OleDbConnection();     // Create object to connect to database.
        frmAdmin adminForm = new frmAdmin();    // Create object of type frmAdmin;
        static string Student;      // Variable will store the users' name
        static int BirtMonthNum;    // Birth month in number format will be stored here
        static string BirthMonth;   // Birth month in alphabet format will be stored here

        public frmEdit(string StudentToAccess)  // StudentUsername parameter is the students username that is passed from the admin form
        {
            Student = StudentToAccess;  // Make the Student variable equal to the StudentToAccess parameter that is passed from the admin form
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Students.accdb;Persist Security Info=False;";   // Connect to the database
            InitializeComponent();
        }

        // When the form loads then display the selected users info
        private void frmEdit_Load(object sender, EventArgs e)
        {
            txtBoxStuID.Enabled = false;    // Disable the student id text box
            connection.Open();  // Open connection to database
            OleDbCommand command = new OleDbCommand();  // Command object for running the query
            command.Connection = connection;    // Have the command variable connect to the database

            // Select the first name, last name, username, password, date of birth, student id, and the marks of the selected student
            string query = "SELECT FirstName, LastName, UserName, Password, DOB, StuID, Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblStudents WHERE LastName + ', ' + FirstName='" + Student + "'";
            command.CommandText = query;    // Store the query as a command
            OleDbDataReader reader = command.ExecuteReader();   // Execute the query

            reader.Read();      // Read the database

            // Put all the info into the designated text boxes. Convert all of the info to type string.
            txtBoxFName.Text = reader["FirstName"].ToString();
            txtBoxLName.Text = reader["LastName"].ToString();
            txtBoxStuID.Text = reader["StuID"].ToString();
            txtBoxUsername.Text = reader["UserName"].ToString();
            txtBoxPassword.Text = reader["Password"].ToString();
            string DOB = Convert.ToDateTime(reader["DOB"].ToString()).ToString("dd/MMM/yy");
            txtBoxBirthDay.Text = DOB.Substring(0, 2);  // Use string manipulation of the DOB variable to get the date and output it into the designated text box for it
            BirthMonth = DOB.Substring(3, 3);   // Use string manipulation of the DOB variable to get the month and save into the BirthMonth variable
            int MonthNum = 0;

            // Make the MonthNum variable equal to the corresponding number of the month of the student's birth.
            if (BirthMonth == "Jan")
            {
                MonthNum = 01;
            }
            else if (BirthMonth == "Feb")
            {
                MonthNum = 02;
            }
            else if (BirthMonth == "Mar")
            {
                MonthNum = 03;
            }
            else if (BirthMonth == "Apr")
            {
                MonthNum = 04;
            }
            else if (BirthMonth == "May")
            {
                MonthNum = 05;
            }
            else if (BirthMonth == "Jun")
            {
                MonthNum = 06;
            }
            else if (BirthMonth == "Jul")
            {
                MonthNum = 07;
            }
            else if (BirthMonth == "Aug")
            {
                MonthNum = 08;
            }
            else if (BirthMonth == "Sep")
            {
                MonthNum = 09;
            }
            else if (BirthMonth == "Oct")
            {
                MonthNum = 10;
            }
            else if (BirthMonth == "Nov")
            {
                MonthNum = 11;
            }
            else if (BirthMonth == "Dec")
            {
                MonthNum = 12;
            }

            txtBoxBirthMonth.Text = MonthNum.ToString();
            txtBoxBirthYear.Text = DOB.Substring(7, 2);     // Use string manipulation of the DOB variable to get the year and output it into the designated text box for it

            // Store marks
            string[] Marks = new string[5];

            // Save marks into Marks array for outputting
            for (int i = 0; i < 5; i++)
            {
                Marks[i] = (reader["Mark" + (i + 1)].ToString());
            }

            txtMark1.Text = Marks[0];   // Output marks into corresponding their text box
            txtMark2.Text = Marks[1];   // Output marks into corresponding their text box
            txtMark3.Text = Marks[2];   // Output marks into corresponding their text box
            txtMark4.Text = Marks[3];   // Output marks into corresponding their text box
            txtMark5.Text = Marks[4];   // Output marks into corresponding their text box

            reader.Close();     // Close reader
            connection.Close();     // Close connection
        }

        // Save the changes made by the user
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any of the text boxes are empty or have white space, if there is no issues then save the new user info to the database
                // Learned from: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0
                if (string.IsNullOrWhiteSpace(txtBoxFName.Text) || string.IsNullOrWhiteSpace(txtBoxLName.Text) || string.IsNullOrWhiteSpace(txtBoxUsername.Text) || string.IsNullOrWhiteSpace(txtBoxPassword.Text) || string.IsNullOrWhiteSpace(txtBoxBirthMonth.Text) || string.IsNullOrWhiteSpace(txtBoxBirthDay.Text) || string.IsNullOrWhiteSpace(txtBoxBirthYear.Text))
                {
                    MessageBox.Show("Not all information has been submitted.");
                }
                else
                {
                    int[] Marks = new int[5];   // Array for storing marks
                    int BirthMonthNum = 0;      // Birth month in number format
                    int BirthDay = 0;       // Birth day in number format
                    int BirthYear = 0;      // Birth year in number format

                    // The if statement will make sure that the user entered in proper inputs for the fields
                    if (int.TryParse(txtMark1.Text, out Marks[0]) && int.TryParse(txtMark2.Text, out Marks[1]) && int.TryParse(txtMark3.Text, out Marks[2]) && int.TryParse(txtMark4.Text, out Marks[3]) && int.TryParse(txtMark5.Text, out Marks[4]) && int.TryParse(txtBoxBirthMonth.Text, out BirthMonthNum) && int.TryParse(txtBoxBirthDay.Text, out BirthDay) && int.TryParse(txtBoxBirthYear.Text, out BirthYear))
                    {
                        // if there is any illogical numbers, then display an error, otherwise save the users changes
                        if (Marks[0] < 0 || Marks[0] > 100)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (Marks[1] < 0 || Marks[1] > 100)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (Marks[2] < 0 || Marks[2] > 100)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (Marks[3] < 0 || Marks[3] > 100)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (Marks[4] < 0 || Marks[4] > 100)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (BirthDay > 31 || BirthDay < 1)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (BirthMonthNum > 12 || BirthMonthNum < 1)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else if (BirthYear < 0)
                        {
                            MessageBox.Show("Invalid Input");
                        }
                        else
                        {
                            connection.Open();  // Open the connection to database
                            OleDbCommand command = new OleDbCommand();  // Command object for running the query 
                            command.Connection = connection;    // Have the command variable connect to the database

                            // In the access database birth month writen with letters so change month format to letters
                            if (BirthMonthNum == 1)
                            {
                                BirthMonth = "Jan";
                            }
                            else if (BirthMonthNum == 2)
                            {
                                BirthMonth = "Feb";
                            }
                            else if (BirthMonthNum == 3)
                            {
                                BirthMonth = "Mar";
                            }
                            else if (BirthMonthNum == 4)
                            {
                                BirthMonth = "Apr";
                            }
                            else if (BirthMonthNum == 5)
                            {
                                BirthMonth = "May";
                            }
                            else if (BirthMonthNum == 6)
                            {
                                BirthMonth = "Jun";
                            }
                            else if (BirthMonthNum == 7)
                            {
                                BirthMonth = "Jul";
                            }
                            else if (BirthMonthNum == 8)
                            {
                                BirthMonth = "Aug";
                            }
                            else if (BirthMonthNum == 9)
                            {
                                BirthMonth = "Sep";
                            }
                            else if (BirthMonthNum == 10)
                            {
                                BirthMonth = "Oct";
                            }
                            else if (BirthMonthNum == 11)
                            {
                                BirthMonth = "Nov";
                            }
                            else if (BirthMonthNum == 12)
                            {
                                BirthMonth = "Dec";
                            }

                            // Update all the student's info
                            string query = "UPDATE tblStudents SET FirstName='" + txtBoxFName.Text + "', LastName='" + txtBoxLName.Text + "', UserName='" + txtBoxUsername.Text + "', [Password]='" + txtBoxPassword.Text + "', Mark1='" + txtMark1.Text + "', Mark2='" + txtMark2.Text + "', Mark3='" + txtMark3.Text + "', Mark4='" + txtMark4.Text + "', Mark5='" + txtMark5.Text + "', DOB='" + txtBoxBirthYear.Text + "/" + txtBoxBirthMonth.Text + "/" + txtBoxBirthDay.Text + "' WHERE StuID=" + txtBoxStuID.Text;

                            command.CommandText = query;    // Store the query as a command
                            command.ExecuteNonQuery();      // Execute the query
                            connection.Close();     // Close the connection to the database
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);  // Display the exception
                connection.Close();     // Close the connection to the database
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();       // Close the form
            adminForm.Show();       // Show the admin form
        }
    }
}
