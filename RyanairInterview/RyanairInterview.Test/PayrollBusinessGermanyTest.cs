using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RyanairInterview.Business;
using RyanairInterview.Domain;

namespace RyanairInterview.Test
{
    [TestClass]
    public class PayrollBusinessGermanyTest
    {
        [TestMethod]
        public void GermanyIncomingTaxLessThan600()
        {
            var payroll = new PayrollBusinessGermany(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Germany });

            Assert.AreEqual(25, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void GermanyIncomingTaxUpperThan600()
        {
            var payroll = new PayrollBusinessGermany(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Germany });

            Assert.AreEqual(292, payroll.CalculateIncomeTax());
        }

        [TestMethod]
        public void GermanyCompulsoryPensionLessThan500()
        {
            var payroll = new PayrollBusinessGermany(new Employee() { HourlyRate = 10, HoursWorked = 10, Location = eLocation.Germany });

            Assert.AreEqual(2, payroll.CalculateCompulsoryPension());
        }

        [TestMethod]
        public void GermanyCompulsoryPensionUpperThan500()
        {
            var payroll = new PayrollBusinessGermany(new Employee() { HourlyRate = 10, HoursWorked = 100, Location = eLocation.Germany });

            Assert.AreEqual(20, payroll.CalculateCompulsoryPension());
        }
    }
}