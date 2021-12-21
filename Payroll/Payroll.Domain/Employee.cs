
using System;
using System.Linq;
using Payroll.Payroll.Domain;
using Payroll.PayrollDomain;

namespace Payroll.PayrollDomain
{
    public class Employee
    {
        public string Name { get; set; }

        public static void CalculateSalary(string weekwork)
        {
            int salary = 0;

            var dateTimes = weekwork.Split(',');
            if (dateTimes.Contains(""))
            {
                return;
            }
            else
            {
                foreach (var dt in dateTimes)
                {
                    
                }
            }
        }
    }
}
