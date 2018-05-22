using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Microsoft Accademy Lesson 13 manipulating Date and Time data format.
/// </summary>
namespace DatesAndTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now;

            Console.WriteLine(myValue.ToString());
            Console.WriteLine(myValue.ToShortDateString());
            Console.WriteLine(myValue.ToShortTimeString());
            Console.WriteLine(myValue.ToLongDateString());
            Console.WriteLine(myValue.ToLongTimeString());
            Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            Console.WriteLine(myValue.AddHours(3).ToLongTimeString());
            Console.WriteLine(myValue.AddHours(-3).ToLongTimeString());
            Console.WriteLine(myValue.Month);
            DateTime myBirthday = new DateTime(1987, 08, 25);
            Console.WriteLine(myBirthday.ToShortDateString());

            DateTime myBirthday2 = DateTime.Parse("25/08/1987");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday2);
            Console.WriteLine(myAge.TotalDays);



            Console.ReadLine();
        }
    }
}
