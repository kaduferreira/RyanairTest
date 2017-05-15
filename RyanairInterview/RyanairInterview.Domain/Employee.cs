using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.Domain
{
    public class Employee
    {
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public eLocation Location { get; set; }
    }
}