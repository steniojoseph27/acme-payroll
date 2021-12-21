using Payroll.Payroll.Domain;
using Payroll.PayrollDomain;
using System;
using System.IO;
using System.Linq;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Payroll.Data/Data.txt";
            ReadFile(filePath);
        }

        public static void ReadFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                int workedHour = 0;

                foreach (var line in File.ReadAllLines(filePath))
                {
                    var result = line.Split('=', ',');

                    var employee = new Employee();
                    employee.Name = result[0];

                    foreach (var item in result.Skip(1))
                    {
                        var day = item[..2];
                        var fromHour = int.Parse(item[2..4]);
                        var toHour = int.Parse(item[8..10]);

                        workedHour = toHour - fromHour;
                        Console.WriteLine($"The amount to pay {employee.Name} is: {workedHour} hours");
                    }
                }
            }
        }

        bool checkWorkDay(WorkDay workDay)
        {
            return ((workDay & (WorkDay.MO | WorkDay.TU | WorkDay.WE | WorkDay.TH | WorkDay.FR)) != 0);
        }

        bool checkWeekend(Weekend weekend)
        {
            return ((weekend & (Weekend.SA | Weekend.SU)) != 0);
        }

        public static string GetShortDayName(string line)
        {
            var day = line[..2];
            if (checkWorkDay)
            {
                if (!checkWeekend())
                {
                    Console.WriteLine("Error obtaining day name");
                }
            }
            return day;
        }

        public static object GetEmployeeName(string line)
        {
            var employeeName = line.Split("=")[0];
            return employeeName;
        }

        public static object GetDayTimes(string dayWorked)
        {
            var timesWorked = dayWorked[2];
            return timesWorked;
        }

        public static string GetHoursMinutes(string hours)
        {
            try
            {
                var fromHours = hours.Split('-');
                var toHours = hours.Split('-');
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error obtaining hours and minutes times");
            }
            return (fromHours, toHours);
        }

        public static object GetWeekWorked(string line)
        {
            string WeekWorked;
            try
            {
                WeekWorked = line.Split("=")[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error obtaining week worked");
            }
            return WeekWorked;
        }

        // Pass hours from string format HH:MM to hours decimal
        public static object ConvertHoursToDecimal(string time)
        {
            try
            {
                var h = time.Split(':');
                var m = time.Split(':');
                //m = m("\n"); // string.Replace
                // These validations move to _check_hours()
                if (m.Count > 2)
                {
                    Console.WriteLine("Error in length of minutes");
                }
                if (Convert.ToInt32(m) > 60)
                {
                    Console.WriteLine("Error in minutes times");
                }
                var hours = Convert.ToInt32(h) + Convert.ToInt32(m) / 60;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing hours");
            }
            return hours;
        }

        public static object ConvertHoursToString(string hour)
        {
            var h = Convert.ToInt32(hours);
            var m = Convert.ToInt32((hours - h) * 60);
            h = h.ToString();
            m = m.ToString();
            if (h == "0")
            {
                h += "0";
            }
            if (m == "0")
            {
                m += "0";
            }
            return "{h}:{m}";
        }
    }
}
