using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Tests
{
    public class TestData
    {
        public static IEnumerable<object[]> TestTextData
        {
            get
            {
                yield return new object[] { "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00" };
                yield return new object[] { "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00" };
                yield return new object[] { "SANDRA=MO05:00-09:00,TH00:05-05:00,SU21:00-00:00" };
                yield return new object[] { "JOHN=MO04:00-07:00,TU14:00-18:00,TH12:00-16:00" };
                yield return new object[] { "JOSEPH=MO01:00-05:00,TU18:01-22:00,TH12:00-17:00,SA19:00-23:00,SU10:00-17:00" };
            }
        }
    }
}
