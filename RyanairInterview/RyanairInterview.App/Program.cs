using RyanairInterview.Business;
using RyanairInterview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanairInterview.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            double hoursWorked;
            double hourlyRate;
            eLocation employeeLocation;

            try
            {
                do
                {
                    Console.Write("Please enter the hours worked: ");
                    line = Console.ReadLine();
                } while (!double.TryParse(line, out hoursWorked));


                do
                {
                    Console.WriteLine();
                    Console.Write("Please enter the hourly rate: ");
                    line = Console.ReadLine();
                } while (!double.TryParse(line, out hourlyRate));


                ConsoleKeyInfo keyPressed;
                do
                {
                    Console.WriteLine();
                    Console.Write("Please enter the employee’s location ([1] - Ireland, [2] - Italy or [3] - Germany): ");
                    keyPressed = Console.ReadKey();
                } while (!Enum.TryParse(keyPressed.KeyChar.ToString(), true, out employeeLocation) || (int.Parse(keyPressed.KeyChar.ToString()) != 1 && int.Parse(keyPressed.KeyChar.ToString()) != 2 && int.Parse(keyPressed.KeyChar.ToString()) != 3));

                Console.Clear();

                var payroll = new PayrollBusinessCreator(new Employee() { HourlyRate = hourlyRate, HoursWorked = hoursWorked, Location = employeeLocation }).Create();

                Console.WriteLine(payroll.ReportAllTaxes().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}