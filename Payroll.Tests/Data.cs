using Payroll.PayrollDomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Payroll.Tests
{
    public class Data
    {
        [Fact]
        public void TestGetEmployeesName()
        {
            Employee employee = new Employee();
            Assert.Equal("RENE", employee.Name);
            Assert.Equal("ASTRID", employee.Name);
            Assert.Equal("SANDRA", employee.Name);
            Assert.Equal("JOHN", employee.Name);
            Assert.Equal("JOSEPH", employee.Name);
        }

        public IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var dataLines = File.ReadAllLines("TestData.txt");

            var testCases = new List<object[]>();

            foreach (var line in dataLines)
            {
                var values = line.Split('=', ',');
                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}
