using System;
using System.Collections.Generic;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Liskov Substitution Principle good

            List<IEmployee> allEmployees = new List<IEmployee>();
            allEmployees.Add(new Nurse("Mary", 56));
            allEmployees.Add(new Doctor("John", 120));
            allEmployees.Add(new VolunteerNurse("Vance", 16));
            foreach (var item in allEmployees)
            {
                item.GetInfo();
            }

            List<SalaryEmployee> salaryEmployees = new List<SalaryEmployee>();
            salaryEmployees.Add(new Nurse("Mary", 56));
            salaryEmployees.Add(new Doctor("John", 120));
            //salaryEmployees.Add(new VolunteerNurse("Vance", 16));
            foreach (var item in salaryEmployees)
            {
                item.CalculateSalary(500);
            }

            Console.ReadKey();
        }
    }
}
