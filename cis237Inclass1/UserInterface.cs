using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class UserInterface
    { // Class to handle all input/output for the program
        public int GetUserInput()
        {
            this.printMenu();

            String input = Console.ReadLine();

            while(input != "1" && input !="2")
            {
                Console.WriteLine("That is not a valid entry.");
                Console.WriteLine("Pleae make a valid choice.");
                Console.WriteLine();

                this.printMenu();

                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        public void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }
        private void printMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Exit");

        }
    }
}
