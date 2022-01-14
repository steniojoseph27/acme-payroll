using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Payroll.Payroll.Domain;
using Payroll.PayrollDomain;


namespace Payroll.PayrollServices
{
    public static class PayrollDataService
    {
        public static ArrayList GetPayrollData(string fileName)
        {
            ArrayList data = new ArrayList();
            var employee = new Employee();

            if (File.Exists(fileName))
            {
                double diffHour = 0;

                foreach (var line in File.ReadAllLines(fileName))
                {
                    var result = line.Split('=', ',');
                    employee.Id += 1;
                    employee.Name = result[0];

                    data.Add(employee.Name);
                    data.Add(employee.Id);

                    foreach (var item in result.Skip(1))
                    {
                        var day = item[..2];
                        var startHour = TimeSpan.Parse(item[2..7]);
                        var endHour = TimeSpan.Parse(item[8..13]);

                        if (endHour == TimeSpan.Zero)
                        {
                            diffHour = Convert.ToDouble((TimeSpan.Parse("1.00:00:00") - startHour).TotalMinutes);
                        }
                        else
                        {
                            diffHour = Convert.ToDouble((endHour - startHour).TotalMinutes);
                        }

                        data.Add(day);
                        data.Add(diffHour);
                    }
                }
            }
            return data;
        }

        public static List<string> GetEmployee(string fileName)
        {
            List<string> employeeName = new List<string>();

            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadAllLines(fileName))
                {
                    var result = line.Split('=', ',');
                    employeeName.Add(result[0]);
                }

                foreach (var emp in employeeName)
                {
                    Console.WriteLine(emp);
                }
            }
            return employeeName;
        }

        public static List<string> GetWeekWorked(string fileName)
        {
            List<string> weekWorked = new List<string>();

            if (File.Exists(fileName))
            {
                string day = "";

                foreach (var line in File.ReadAllLines(fileName))
                {
                    var result = line.Split('=', ',');

                    foreach (var item in result.Skip(1))
                    {
                        day = item[..2];

                        if (Enum.IsDefined(typeof(WorkDay), day))
                        {
                            weekWorked.Add("Week");
                        }
                        else if (Enum.IsDefined(typeof(Weekend), day))
                        {
                            weekWorked.Add("Weekend");
                        }
                        else
                        {
                            Console.WriteLine("Invalid day");
                        }
                    }

                    foreach (var week in weekWorked)
                    {
                        Console.WriteLine(week);
                    }
                }
            }
            return weekWorked;
        }

        public static List<string> GetShiftWorked(string fileName)
        {
            List<string> shiftWorked = new List<string>();

            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadAllLines(fileName))
                {
                    var result = line.Split('=', ',');

                    foreach (var item in result.Skip(1))
                    {
                        var startHour = TimeSpan.Parse(item[2..7]);
                        var endHour = TimeSpan.Parse(item[8..13]);

                        if (startHour >= TimeSpan.Parse(Shift.FirstShiftStart) && endHour <= TimeSpan.Parse(Shift.FirstShiftEnd))
                        {
                            shiftWorked.Add("FirstShift");
                        }
                        else if (startHour >= TimeSpan.Parse(Shift.SecondShiftStart) && endHour <= TimeSpan.Parse(Shift.SecondShiftEnd))
                        {
                            shiftWorked.Add("SecondShift");
                        }
                        else if (startHour >= TimeSpan.Parse(Shift.ThirdShiftStart) && endHour <= TimeSpan.Parse(Shift.ThirdShiftEnd))
                        {
                            shiftWorked.Add("ThirdShift");
                        }
                        else
                        {
                            Console.WriteLine("Invalid time");
                        }
                    }

                    foreach (var shift in shiftWorked)
                    {
                        Console.WriteLine(shift);
                    }
                }
            }
            return shiftWorked;
        }
    }
}
