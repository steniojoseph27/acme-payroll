using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.PayrollDomain
{
    public static class Rate
    {
        public static int WeekFirstShift { get; set; } = 25;
        public static int WeekSecondShift { get; set; } = 15;
        public static int WeekThirdShift { get; set; } = 20;
        public static int WeekendFirstShift { get; set; } = 30;
        public static int WeekendSecondShift { get; set; } = 20;
        public static int WeekendThirdShift { get; set; } = 25;
    }
}
