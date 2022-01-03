using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.PayrollDomain
{
    public static class Shift
    {
        public static string FirstShiftStart { get; set; } = "00:01";
        public static string FirstShiftEnd { get; set; } = "09:00";
        public static string SecondShiftStart { get; set; } = "09:01";
        public static string SecondShiftEnd { get; set; } = "18:00";
        public static string ThirdShiftStart { get; set; } = "18:01";
        public static string ThirdShiftEnd { get; set; } = "00:00";
    }
}
