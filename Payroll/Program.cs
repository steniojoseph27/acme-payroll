using System;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            // Read the file and display it line by line.
            foreach (var line in System.IO.File.ReadLines(@"Payroll.Data/Data.txt"))
            {
                Console.WriteLine(line);
                counter++;
            }
        }
    }
}
