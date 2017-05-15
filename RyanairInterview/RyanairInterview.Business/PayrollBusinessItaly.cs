using RyanairInterview.Business.Interface;
using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Business
{
    public class PayrollBusinessItaly : PayrollBusinessAbstract, IPayrollBusiness, IPayrollBusinessItaly
    {
        private Employee employee;

        private double minIncomeTax = 0.25;

        private double minINPSTax = 0.09;
        private double maxINPSTax = 0.01;
        private double minINPSRange = 500;


        public PayrollBusinessItaly(Employee employee) : base(employee)
        {
            this.employee = employee;
        }

        public double CalculateIncomeTax()
        {
            return this.grossAmount * minIncomeTax;
        }

        public double CalculateINPS()
        {
            if (this.grossAmount <= minINPSRange)
            {
                return this.grossAmount * minINPSTax;
            }
            else
            {
                double upperThanContributionBase = this.grossAmount - minINPSRange;
                double newTax = (upperThanContributionBase / 100) * maxINPSTax;

                return (minINPSRange * minINPSTax) + (upperThanContributionBase * newTax);
            }
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
            sb.AppendLine($"INPS Contribution: €{CalculateINPS()}");

            return sb;
        }
    }
}
