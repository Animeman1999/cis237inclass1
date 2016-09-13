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
            Employee myEmployee = new Employee();
            myEmployee.FirstName = "David";
            myEmployee.LastName = "Barnes";
            myEmployee.WeeklySalary = 2048.34m;

            Console.WriteLine(myEmployee.FirstName);
            Console.WriteLine(myEmployee);

            Employee[] employees = new Employee[10];

            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Jean-Luc", "Picard", 290.00m);
            employees[2] = new Employee("Benjamin", "Sisko", 530.00m);
            employees[3] = new Employee("Kathryn", "Janeway", 350.00m);
            employees[4] = new Employee("Johnathan", "Archer", 743.00m);

            foreach (Employee employee in employees)
            {
                if (employee != null)// Error checking to make sure each record exists
                {
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }
        }
    }
}
