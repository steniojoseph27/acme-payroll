using System;
using Payroll.Payroll.Domain;


namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separator = 
            { 
                WorkDay.MO.ToString(),
                WorkDay.TU.ToString(),
                WorkDay.WE.ToString(),
                WorkDay.TH.ToString(),
                WorkDay.FR.ToString(),
                Weekend.SA.ToString(),
                Weekend.SU.ToString(),

            };

            string text = "the dog :is very# cute";
            string str = text.Split(':', '#')[1]; // [1] means it selects second part of your what you split parts of your string. (Zero based)
            Console.WriteLine(str);

            string strSource = @"Payroll.Data/Data.txt";
            var names = strSource.Split('=')[0];
            Console.WriteLine(names);
            //var days = strSource.Split(':');
            var days = strSource.Split(':', ',')[1];
            Console.WriteLine(days);
            var hours = strSource.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine(names);
            //Console.WriteLine(days);
            //foreach (var d in days)
            //{
            //    Console.WriteLine(d);
            //}

            ////Console.WriteLine(hour);
            //foreach(string h in hours)
            //{
            //    Console.WriteLine(h);
            //}
            //string filePath = @"Payroll.Data/Data.txt";
            //ReadFile(filePath);

        }

        public static string[] GetDayAbbreviation(string input)
        {
            string[] day = { };

            // Check if day exist in workweek

            // Check if day exist in weekend

            return day;
        }

        public static string[] GetEmployee(string fileName)
        {
            string filePath = fileName;

            string[] employee = { };


            return employee;
        }

        public static string GetEmployeeName(string employeeName)
        {
            var employeeNames = employeeName.Split('=')[0];

            return employeeNames;
        }

        public static string[] GetDayTimes(string dayTime)
        {
            string[] dayTimes = { };

            return dayTimes;
        }

        public static string[] hoursMinutes(string hour)
        {
            string[] hours = { };

            return hours;
        }

        public static string[] GetWeekWorked(string weekWorked)
        {
            string[] weeksWorked = { };

            return weeksWorked;
        }

        public static void ReadFile(string filePath)
        {
            int counter = 0;

            if (System.IO.File.Exists(filePath))
            {
                foreach (var line in System.IO.File.ReadAllLines(filePath))
                {
                    Console.WriteLine(line);
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Please check the file path.");
            }
        }
    }
}
