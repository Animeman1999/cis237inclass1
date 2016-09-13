using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Employee
    {

        //*************************************
        //Backing Fields
        //*************************************
        private string _firstName;
        private string _lastName;
        private decimal _weeklySalary;

        //*************************************
        //Properties
        //*************************************

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName;}
            set { _lastName = value; }
        }

        public decimal WeeklySalary
        {
            get { return _weeklySalary; }
            set { _weeklySalary = value; }
        }

        //***********************************
        //Public methods
        //***********************************

        public override string ToString()
        { // This overrides what will be shown if you try to print out the class. Overides what normally would be shown which would be the exact name of the class.
            return this._firstName + " " + this._lastName;
        }

        public decimal YearlySalary()
        {
            return this._weeklySalary * 52;
            
        }

        //**************************************
        //Constructor
        //**************************************

        public Employee(string firstName, string lastName, decimal weeklySalary)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._weeklySalary = weeklySalary;
        }

        public Employee()
        {
            //Do Nothing - Default constructor
        }

    }
}
