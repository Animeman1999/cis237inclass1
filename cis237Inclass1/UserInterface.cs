using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class UserInterface
    { // Class to handle all input/lasoutput for the program

        //There are no backing field variables because we don't need any
        //There are no properties because we don't have any backing fields
        //There are also, no constructors. We will just use te default that is 
        //automatically provide to us.

            //This class eseentially beomes a collecton of methods that do work.

            //Get user input.
        public int GetUserInput()
        {
            //Call the printMenu method that is private to the calss
            this.printMenu();

            //Get input from the console
            String input = Console.ReadLine();


            //Continue to loop while the input is Not a valid choice
            while(input != "1" && input !="2")
            {
                //Since it is not valid, output a message saying so
                Console.WriteLine("That is not a valid entry.");
                Console.WriteLine("Pleae make a valid choice.");
                Console.WriteLine();

                //re-read the menu in case the user forgot what they could do
                this.printMenu();

                //re-get the input from the user
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        //At this point, the input is valid so we can return the parse of it.
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
