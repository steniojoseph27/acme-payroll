using Payroll.Payroll.Domain;
using Payroll.PayrollDomain;
using System;
using System.IO;
using System.Linq;

namespace Payroll
{
    class Program
    {
        private static readonly TimeSpan _midNight = TimeSpan.Parse("23:00:00");

        static void Main(string[] args)
        {
            string filePath = @"Payroll.Data/Data.txt";
            //GetEmployee(filePath);
            ////GetDay(filePath);
            GetHoursWorked(filePath);
            //CalculateRate(day, startHour, endHour);
        }

        public static string[] CalulateRateHour(string filePath)
        {
            string day = "";
            TimeSpan startHour = new TimeSpan();
            TimeSpan endHour = new TimeSpan();

            if (System.IO.File.Exists(filePath))
            {
                
                //var workedHour = 0;
                var midNight = TimeSpan.Parse("23:00:00");

                foreach (var line in File.ReadAllLines(filePath))
                {
                    var result = line.Split('=', ',');
                    var employee = new Employee();
                    employee.Name = result[0];

                    foreach (var item in result.Skip(1))
                    {
                        day = item[..2];
                        var fromHour = TimeSpan.TryParseExact(item[2..4], "%h", null, out startHour);
                        var toHour = TimeSpan.TryParseExact(item[8..10], "%h", null, out endHour);
                    }
                }
            }
            return new[] { day.ToString(), startHour.ToString(), endHour.ToString() };
        }

        public static string GetEmployee(string filePath)
        {
            var employee = new Employee();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var result = line.Split('=', '-');
                employee.Name = result[0];
                //Console.WriteLine(employee.Name = result[0]);
            }

            return employee.Name;
        }


        public static string GetDay(string filePath)
        {
            var dayWorked = "";

            if (System.IO.File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var result = line.Split('=', ',');

                    foreach (var item in result.Skip(1))
                    {
                        if (!Enum.IsDefined(typeof(WorkDay), item[..2]))
                        {
                            if (!Enum.IsDefined(typeof(Weekend), item[..2]))
                            {
                                Console.WriteLine("Please check the file data.");
                                return "";
                            }
                        }
                        
                        dayWorked = item[..2];
                        //Console.WriteLine(dayWorked = item[..2]);
                    }
                }
            }

            return dayWorked;
        }

        public static string[] GetHoursWorked(string filePath)
        {
            string day = "";
            TimeSpan startHour = new TimeSpan();
            TimeSpan endHour = new TimeSpan();

            if (System.IO.File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var result = line.Split('=', ',');

                    foreach (var item in result.Skip(1))
                    {
                        day = item[..2];
                        startHour = TimeSpan.Parse(item[2..7]);
                        endHour = TimeSpan.Parse(item[8..13]);

                        //Console.WriteLine(CalculateRate(day, startHour, endHour));
                        //Console.WriteLine($"{item[2..7]} - {item[8..13]}");
                    }
                }
            }

            return new[] { day, startHour.ToString(), endHour.ToString() };
        }

        public static int CalculateRate(string day, TimeSpan startHour, TimeSpan endHour)
        {
            int shiftRate = 0;

            if (Enum.IsDefined(typeof(WorkDay), day))
            {
                if (startHour >= TimeSpan.Parse(Shift.FirstShiftStart) && endHour <= TimeSpan.Parse(Shift.FirstShiftEnd))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekFirstShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekFirstShift);
                }
                else if (startHour >= TimeSpan.Parse(Shift.SecondShiftStart) && endHour <= TimeSpan.Parse(Shift.SecondShiftEnd))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekSecondShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekSecondShift);
                }
                else if (startHour >= TimeSpan.Parse(Shift.ThirdShiftStart) && endHour <= _midNight + TimeSpan.Parse("01:00"))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekThirdShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekThirdShift);
                }
            }
            else if (Enum.IsDefined(typeof(Weekend), day))
            {
                if (startHour >= TimeSpan.Parse(Shift.FirstShiftStart) && endHour <= TimeSpan.Parse(Shift.FirstShiftEnd))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendFirstShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendFirstShift);
                }
                else if (startHour >= TimeSpan.Parse(Shift.SecondShiftStart) && endHour <= TimeSpan.Parse(Shift.SecondShiftEnd))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendSecondShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendSecondShift);
                }
                else if (startHour >= TimeSpan.Parse(Shift.ThirdShiftStart) && endHour <= _midNight + TimeSpan.Parse("01:00"))
                {
                    shiftRate = ((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendThirdShift;
                    Console.WriteLine(((int)endHour.TotalHours - (int)startHour.TotalHours) * Rate.WeekendThirdShift);
                }
            }
            return shiftRate;
        }
    }
}
