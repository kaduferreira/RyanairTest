using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Business
{
    public class PayrollBusinessCreator
    {
        private Employee employee;

        public PayrollBusinessCreator(Employee employee)
        {
            this.employee = employee;
        }

        public dynamic Create()
        {
            if (employee.Location == eLocation.Ireland)
                return new PayrollBusinessIreland(employee);
            else if (employee.Location == eLocation.Italy)
                return new PayrollBusinessItaly(employee);
            else
                return new PayrollBusinessGermany(employee);
        }
    }
}