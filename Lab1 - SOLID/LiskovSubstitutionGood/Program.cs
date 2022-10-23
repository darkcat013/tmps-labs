using System;
using System.Collections.Generic;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main()
        {
            //Liskov Substitution Principle good

            List<IEmployee> allEmployees = new List<IEmployee>
            {
                new Nurse("Mary", 56),
                new Doctor("John", 120),
                new VolunteerNurse("Vance", 16)
            };
            foreach (var item in allEmployees)
            {
                item.GetInfo();
            }

            List<SalaryEmployee> salaryEmployees = new List<SalaryEmployee>
            {
                new Nurse("Mary", 56),
                new Doctor("John", 120),
                //new VolunteerNurse("Vance", 16)
            };
            foreach (var item in salaryEmployees)
            {
                item.CalculateSalary(500);
            }

            Console.ReadKey();
        }
    }
}
