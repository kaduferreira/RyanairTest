using RyanairInterview.Business.Interface;
using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Business
{
    public class PayrollBusinessGermany : PayrollBusinessAbstract, IPayrollBusiness, IPayrollBusinessGermany
    {
        private Employee employee;

        private double minIncomeTax = 0.25;
        private double maxIncomeTax = 0.32;
        private double minIncomeRange = 400;

        private double compulsoryPensionTax = 0.02;


        public PayrollBusinessGermany(Employee employee) : base(employee)
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
            sb.AppendLine($"Compulsory Pension: €{CalculateCompulsoryPension()}");

            return sb;
        }
    }
}
