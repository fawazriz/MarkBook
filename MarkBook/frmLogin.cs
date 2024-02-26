using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;        // We need this in order to access the OleDbConnection class
/*
Name: Fawaz Rizwan
Date: June 16, 2023
Program Name: Markbook
Program Description: To make a program that will allow students to view their marks and personal info. The admin account will be able to create new students and change the marks for students while students can only view info.
Enchancement: Used constructors, get/set method, encapsulation, and added a feature where the user can download info of the selected student as a pdf to their computer
*/
namespace MarkBook
{
    public partial class frmLogin : Form
    {
        private OleDbConnection connection = new OleDbConnection();     // Create object to connect to database.
        public frmLogin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Students.accdb;Persist Security Info=False;";   // Connection to the access database in the debug file of this project

            // Try to connect to the database, if the data base is unable to then a messagebox will appear that say "No Connection"
            try
            {
                connection.Open();
                lblDBConnection.Text = "Connected"; // Label will signify to user that they are connected to the database
                connection.Close();     // Close the connection to the database
            }
            catch
            {

                MessageBox.Show("No Connection");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // if the user name or the password is not filled then tell the user to fill them. Otherwise, let the program continue
            // Learned from: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
            }
            else
            {
                connection.Open();      // Open connection

                OleDbCommand command = new OleDbCommand();  // Command object for running the query

                command.Connection = connection;    // Have the command variable connect to the database

                // Select all the info from the row that has the same user name and password that the user entered
                command.CommandText = "SELECT * FROM tblStudents WHERE UserName='" + txtUser.Text + "' AND Password ='" + txtPassword.Text + "'";

                OleDbDataReader reader = command.ExecuteReader();   // Variable will be used to read the file


                int counter = 0;    // For password attempts
                string pass = "";   // Will store the first name of the user
                string pass2 = "";  // Will store the last name of the user

                while (reader.Read())   // While the reader reads for info it will check if it correct by adding to the counter. It will also save the first and last name to seperate variables
                {
                    counter++;  // Increment the counter
                    pass = reader["FirstName"].ToString();  // Store the first name of the user
                    pass2 = reader["LastName"].ToString();  // Store the last name of the user
                }
                if (counter == 1)   // If counter is equal to 1 (if the user gets the password correct) then allow the user to log in
                {
                    MessageBox.Show("Welcome " + pass + " " + pass2);
                    this.Hide();    // Hide the log in form
                    if (txtUser.Text == "admin")    // if the user is the admin then make the admin form appear
                    {
                        frmAdmin frmAdmin = new frmAdmin();  // Make a admin form object
                        frmAdmin.ShowDialog();      // Make the admin form appear
                    }
                    else
                    {
                        frmView frmView = new frmView(txtUser.Text);    // Make a view form object for students with the username entered as a parameter
                        frmView.ShowDialog();   // Make a the view form appear
                    }
                }
                // if the user is not part of the data base or if any incorrect info is entered then the program will alert the user
                else
                {
                    MessageBox.Show("Go Away " + txtUser.Text);
                }
                reader.Close();     // Close the reader
                connection.Close();     // Close the connection
            }
        }
    }
}
