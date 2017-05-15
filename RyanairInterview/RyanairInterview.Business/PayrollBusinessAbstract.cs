using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Business
{
    public abstract class PayrollBusinessAbstract
    {
        public double grossAmount;

        public PayrollBusinessAbstract(Employee employee)
        {
            grossAmount = employee.HoursWorked * employee.HourlyRate;
        }

        public abstract StringBuilder ReportAllTaxes();
    }
}
