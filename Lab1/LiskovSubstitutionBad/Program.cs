using System;
using System.Collections.Generic;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main()
        {
            //Liskov Substitution Principle bad
            List<Employee> employees = new List<Employee>
            {
                new Nurse("Mary", 56),
                new Doctor("John", 120),
                new VolunteerNurse("Vance", 16)
            };

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
