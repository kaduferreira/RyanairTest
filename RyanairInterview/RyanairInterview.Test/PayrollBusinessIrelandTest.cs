using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RyanairInterview.Business;
using RyanairInterview.Domain;

namespace RyanairInterview.Test
{
    [TestClass]
    public class PayrollBusinessIrelandTest
    {
        [TestMethod]
        public void IrelandIncomingTaxLessThan600()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Ireland });

            Assert.AreEqual(25, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void IrelandIncomingTaxUpperThan600()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Ireland });

            Assert.AreEqual(310, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void IrelandUniversalSocialChangeLessThan500()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Ireland });

            Assert.AreEqual(7.ToString(), payroll.CalculateUniversalSocialChange().ToString());
        }

        [TestMethod]
        public void IrelandUniversalSocialChangeUpperThan500()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Ireland });

            Assert.AreEqual(75, payroll.CalculateUniversalSocialChange());
        }

        [TestMethod]
        public void IrelandCompulsoryPensionLessThan500()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Ireland });

            Assert.AreEqual(4, payroll.CalculateCompulsoryPension());
        }

        [TestMethod]
        public void IrelandCompulsoryPensionUpperThan500()
        {
            var payroll = new PayrollBusinessIreland(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Ireland });

            Assert.AreEqual(40, payroll.CalculateCompulsoryPension());
        }
    }
}