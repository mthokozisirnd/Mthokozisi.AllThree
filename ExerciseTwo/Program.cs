using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console string calculator app.
            Console.WriteLine("Console String Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string stringInput1 = "";
                int result = 0;

                // Ask the user to type their string.
                Console.Write("Type your string, and then press Enter: ");
                stringInput1 = Console.ReadLine();

                string op = Console.ReadLine();

                try
                {
                    result = StringCalculator.AddNumbers(stringInput1);
                    if (result == null)
                    {
                        Console.WriteLine("This operation will result in a calculation error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the calculation.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
