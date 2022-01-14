using System;

namespace Payroll.Payroll.Domain
{
    class PayrollResults
    {
        // Employee name
        public string Name { get; set; }

        // Shifts
        public static TimeSpan FirstShiftStart { get; set; }
        public static TimeSpan FirstShiftEnd { get; set; }
        public static TimeSpan SecondShiftStart { get; set; }
        public static TimeSpan SecondShiftEnd { get; set; }
        public static TimeSpan ThirdShiftStart { get; set; }
        public static TimeSpan ThirdShiftEnd { get; set; }

        // Rate
        public static int WeekFirstShift { get; set; }
        public static int WeekSecondShift { get; set; }
        public static int WeekThirdShift { get; set; }
        public static int WeekendFirstShift { get; set; }
        public static int WeekendSecondShift { get; set; }
        public static int WeekendThirdShift { get; set; }
    }
}
