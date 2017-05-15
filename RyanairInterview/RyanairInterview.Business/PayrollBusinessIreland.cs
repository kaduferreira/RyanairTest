using RyanairInterview.Business.Interface;
using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Business
{
    public class PayrollBusinessIreland : PayrollBusinessAbstract, IPayrollBusiness, IPayrollBusinessIreland
    {
        private Employee employee;

        private double minIncomeTax = 0.25;
        private double maxIncomeTax = 0.40;
        private double minIncomeRange = 600;

        private double minUniversalSocialTax = 0.07;
        private double maxUniversalSocialTax = 0.08;
        private double minUniversalSocialRange = 500;

        private double compulsoryPensionTax = 0.04;

        public PayrollBusinessIreland(Employee employee) : base(employee)
        {
            this.employee = employee;
        }

        public double CalculateIncomeTax()
        {
            if (this.grossAmount <= minIncomeRange)
            {
                return this.grossAmount * minIncomeTax;
            }
            else
            {
                return (minIncomeRange * minIncomeTax) + ((this.grossAmount - minIncomeRange) * maxIncomeTax);
            }
        }

        public double CalculateUniversalSocialChange()
        {
            if (this.grossAmount <= minUniversalSocialRange)
            {
                return this.grossAmount * minUniversalSocialTax;
            }
            else
            {
                return (minUniversalSocialRange * minUniversalSocialTax) + ((this.grossAmount - minUniversalSocialRange) * maxUniversalSocialTax);
            }
        }

        public double CalculateCompulsoryPension()
        {
            return this.grossAmount * compulsoryPensionTax;
        }

        public override StringBuilder ReportAllTaxes()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employee location: {employee.Location}");
            sb.AppendLine();
            sb.AppendLine($"Gross Amount: €{this.grossAmount}");
            sb.AppendLine();
            sb.AppendLine("Less deductions");
            sb.AppendLine();
            sb.AppendLine($"Income Tax : €{CalculateIncomeTax()}");
            sb.AppendLine($"Universal Social Charge: €{CalculateUniversalSocialChange()}");
            sb.AppendLine($"Pension: €{CalculateCompulsoryPension()}");

            return sb;
        }
    }
}