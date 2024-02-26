using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkBook
{
    class Student
    {
        private string FirstName;   // Create private variable for the student's first name. It is private so it is protected.
        private string LastName;    // Create private variable for the student's last name. It is private so it is protected.
        private string UserName;    // Create private variable for the student's username. It is private so it is protected.
        private string Password;    // Create private variable for the student's password. It is private so it is protected.
        private int BirthDate;      // Create private variable for the student's birth date. It is private so it is protected.
        private int BirthMonth;     // Create private variable for the student's birth month. It is private so it is protected.
        private int BirthYear;      // Create private variable for the student's birth year. It is private so it is protected.
        private int StuID;          // Create private variable for the student's student id. It is private so it is protected.
        public int[] Marks = new int[5];    // Create punlic variable for the student's name. It is public so it is available in any class.

        // Constructor which will be used for creating an object of type Student
        // This is a constructor with the parameters of the students first name, last name, user name, password, birth day, birth month, birth year, and student id number
        // Constructors are a method that is used when intializing an object. It can be used for assigning the values of variables when the object is created. Learned from : https://www.w3schools.com/cs/cs_constructors.php
        public Student(string FName, string LName, string UName, string Pass, int BDate, int BMonth, int BYear, int StudentID)
        {
            FirstName = FName;  // Set the student first name to the first name parameter
            LastName = LName;   // Set the student last name to the last name parameter
            UserName = UName;   // Set the student username to the username parameter
            Password = Pass;    // Set the student password to the password parameter
            BirthDate = BDate;      // Set the student birth date to the birth date name parameter
            BirthMonth = BMonth;    // Set the student birth month to the birth month parameter
            BirthYear = BYear;  // Set the student birth year to the birth year parameter
            StuID = StudentID;  // Set the student StuID to the student ID parameter
        }

        // Get set method for the first name
        public string FName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        // Get set method for the last name
        public string LName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        // Get set method for the username
        public string UName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        // Get set method for the password
        public string Pass
        {
            get { return Password; }
            set { Password = value; }
        }

        // Get set method for the birth date
        public int BDate
        {
            get { return BirthDate; }
            set { BirthDate = value; }
        }

        // Get set method for the birth month
        public int BMonth
        {
            get { return BirthMonth; }
            set { BirthMonth = value; }
        }

        // Get set method for the birth year
        public int BYear
        {
            get { return BirthYear; }
            set { BirthYear = value; }
        }

        // Get set method for the student id
        public int StudentID
        {
            get { return StuID; }
            set { StuID = value; }
        }
    }
}
