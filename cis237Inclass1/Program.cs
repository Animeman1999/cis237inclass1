using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring a variable of type Employee(whic is a class) and instanciating a new instance of Employee and
            //assigning it to the variable using the NEW keywork means that memory will get allocated on the Heap for that class.
            Employee myEmployee = new Employee();

            //Use the properties to assign values.
            myEmployee.FirstName = "David";
            myEmployee.LastName = "Barnes";
            myEmployee.WeeklySalary = 2048.34m;

            //Output the first name of the employee using the property
            Console.WriteLine(myEmployee.FirstName);
            //Output the entre employee, which will cal the TooString method implicitly
            //This would work even without overriding the ToString method in the Employee class,
            //however it would only spit out the namespace and the name of the class instead of something useful.
            Console.WriteLine(myEmployee);

            //Create an array of type Employee to hold a bunch of Employees
            Employee[] employees = new Employee[10];

            //Assing values to the array. Each spot needs to contain an instance of an Employee
            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Jean-Luc", "Picard", 290.00m);
            employees[2] = new Employee("Benjamin", "Sisko", 530.00m);
            employees[3] = new Employee("Kathryn", "Janeway", 350.00m);
            employees[4] = new Employee("Johnathan", "Archer", 743.00m);

            //A foreach loop.  It is usefull for doing a collection of objects.
            //Each object in the array 'employees' will get assigned to the local 
            //variable 'employee' inside the loop.
            foreach (Employee employee in employees)
            {
                //Run a check to make sure the spot in the array is not empty
                if (employee != null)// Error checking to make sure each record exists
                {
                    //Print the employee
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }

            //Instanciate a new UI class
            UserInterface ui = new UserInterface();

            
            //Get the user input from the UI Class
            int choice = ui.GetUserInput();

            //While the choice that was entered is not 2, we will loop to
            //continue to get the next choice of what they want to do.
            while (choice != 2)
            {
                // If the choice they made is 1, (which for us is the only choice)
                if (choice == 1)
                {
                    //Create a string to concat the output
                    string allOutput = "";

                    //Loop through all the employees just like above only instead of 
                    //writing out the employees, we are concating them together.
                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + employee.YearlySalary() + Environment.NewLine;
                        }
                    }
                    //Once the concat is done, have the UI class print out the result
                    ui.PrintAllOutput(allOutput);
                }
                //Get the next choice from the user.
                choice = ui.GetUserInput();
            }
        }
    }
}
