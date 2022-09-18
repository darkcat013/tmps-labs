using System;
using System.Collections.Generic;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Liskov Substitution Principle bad
            List<Employee> employees = new List<Employee>();
            employees.Add(new Nurse("Mary", 56));
            employees.Add(new Doctor("John", 120));
            employees.Add(new VolunteerNurse("Vance", 16));

            foreach (var item in employees)
            {
                item.GetInfo();
            }
            foreach (var item in employees)
            {
                item.CalculateSalary(500);
            }

            Console.ReadKey();
        }
    }
}
