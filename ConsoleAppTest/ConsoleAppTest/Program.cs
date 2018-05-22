using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        //Microsoft virtual academy - Lesson 10 - method call
        static void Main(string[] args)
        {
            Console.WriteLine("The Name Game");

            Console.WriteLine("Whats your first name? ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Whats your last name? ");
            string lastName = Console.ReadLine();

            Console.WriteLine("In what city were you born? ");
            string city = Console.ReadLine();

            DisplayResult(ReverseString(firstName), ReverseString(lastName), ReverseString(city));
            DisplayResult(ReverseString(firstName) + " " + ReverseString(lastName) + " " + ReverseString(city));

            Console.ReadLine();
        }

        private static void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        private static string ReverseString(string message)
        {
            //catch a string from the user and reverse them
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }

        //testing overload methods
        private static void DisplayResult(string reversedFirstName, string reversedLastName, string reversedCity)
        {
            Console.Write("Results: ");
            Console.Write(String.Format("{0} {1} {2}", reversedFirstName, reversedLastName, reversedCity));
        }

        private static void DisplayResult(string message)
        {
            Console.Write("\nResults: ");
            Console.Write(message);
        }
    }
}
