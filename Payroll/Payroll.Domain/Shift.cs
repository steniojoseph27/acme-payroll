using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.PayrollDomain
{
    public static class Shift
    {
        public static string WeekFirstShift { get; set; } = "00:01-09:00";
        public static string WeekSecondShift { get; set; } = "09:01-18:00";
        public static string WeekThirdShift { get; set; } = "18:01-00:00";
    }
}
