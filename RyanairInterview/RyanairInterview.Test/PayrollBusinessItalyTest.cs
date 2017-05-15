using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RyanairInterview.Business;
using RyanairInterview.Domain;

namespace RyanairInterview.Test
{
    [TestClass]
    public class PayrollBusinessItalyTest
    {
        [TestMethod]
        public void ItalyIncomingTaxLessThan600()
        {
            var payroll = new PayrollBusinessItaly(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Italy });

            Assert.AreEqual(25, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void ItalyIncomingTaxUpperThan600()
        {
            var payroll = new PayrollBusinessItaly(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Italy });

            Assert.AreEqual(250, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void ItalyINPSLessThan500()
        {
            var payroll = new PayrollBusinessItaly(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Italy });

            Assert.AreEqual(9, payroll.CalculateINPS());
        }

        [TestMethod]
        public void ItalyINPSUpperThan500()
        {
            var payroll = new PayrollBusinessItaly(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Italy });

            Assert.AreEqual(70, payroll.CalculateINPS());
        }
    }
}