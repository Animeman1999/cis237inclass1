using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            //Use the SCVProcessor method that we wrote into main to load the 
            //employees from the scv file
            ImportCSV("employees.csv", employees);

            //Instanciate a new UI class
            UserInterface ui = new UserInterface();


            //Get the user input from the UI Class
            //int choice = ui.GetUserInput();
            //could use the instance one above, but to demonstrate using a static
            //class, we are calling the statice version.
            //If you HATE staic classes and want to avoid them, feel free to 
            //cmmnet the below line and uncomment the above line.
            int choice = StaticUserInterface.GetUserInput();

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

        static bool ImportCSV(string pathToCSVFile, Employee[] employees)
        {
            //Declare a variable for the stream reader. Not going to instanciate it yet
            StreamReader streamReader = null;


            //Start a try since the path to the file could be incorrect, ac thus throw an exception
            try
            {
                //Delare a streing for each line we will read in
                string line;

                //Instanciate the streamReader. If the path to file is incorrect it will throw an exception that we can catch.
                streamReader = new StreamReader(pathToCSVFile);

                //Set up a counter that we are not using yet
                int counter = 0;


                //While there is a  line to read the line and put it in the linve var
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Call the process line method and send over the read in line,
                    //the employees array (which is passed by refence automatically).
                    //and the counter, which will be used as the index for the array.
                    //We are also increementing the counter after we send it in with the ++ operator
                
                    processLine(line, employees, counter++);
                }

                // All the reads are sucessful, return true.
                return true;
            }

            catch (Exception e)
            {
                //Ouptut the exception string and the stack trace.
                //The stack trace is all of the method calls that lead to 
                //where the exception occored.
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                //Return false, reading failed.
                return false;
            }
            //Used to ensure the code within it gets executed regardless of whether the 
            //try succeeds or the catch gets executed
            finally
            {
                //Check to make sure that the streamReader is actually instanciated before
                //tring to call a method on it
                if(streamReader != null)
                {
                    //Close the streamReader because its the right thing to do.
                    streamReader.Close();
                }
            }
          
        }

        static void processLine(string line, Employee[] employees, int index)
        {
            //declare a string array and assign the split line to it
            string[] parts = line.Split(',');

            //Assign the parts to local variables that mean something
            string firstName = parts[0];
            string lastName = parts[1];
            decimal salary = decimal.Parse(parts[2]);

            //Use the variables to instanciate a new Employee and assign it to 
            //the spot in the employees array indexed by the index that was passed in.
            employees[index] = new Employee(firstName, lastName, salary);
        }
    }
}
