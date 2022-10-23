using System;
using System.Collections.Generic;

namespace SOLIDPrinciples
{
    interface IEmployee
    {
        string Name { get;}
        int HoursWorked { get; }
        void GetInfo();
    }
    interface ICalculateSalary
    {
        void CalculateSalary(float salary);
    }

    abstract class SalaryEmployee :IEmployee, ICalculateSalary
    {
        public string Name { get; }
        public int HoursWorked { get; }

        public SalaryEmployee() { }
        public SalaryEmployee(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }

        public abstract void CalculateSalary(float salary);
        public abstract void GetInfo();
    }
    class Nurse : SalaryEmployee
    {
        public Nurse(string name, int hoursWorked) : base(name, hoursWorked) { }
        public override void CalculateSalary(float salary)
        {
            Console.WriteLine(string.Format("Nurse {0} got {1} money", Name, salary + (HoursWorked * 2)));
        }

        public override void GetInfo()
        {
            Console.WriteLine(string.Format("Nurse {0} worked {1} hours", Name, HoursWorked));
        }
    }

    class Doctor : SalaryEmployee
    {
        public Doctor(string name, int hoursWorked) : base(name, hoursWorked) { }
        public override void CalculateSalary(float salary)
        {
            Console.WriteLine(string.Format("Doctor {0} got {1} money", Name, salary + (HoursWorked * 5)));
        }

        public override void GetInfo()
        {
            Console.WriteLine(string.Format("Doctor {0} worked {1} hours", Name, HoursWorked));
        }
    }

    class VolunteerNurse : IEmployee
    {
        public string Name { get; }
        public int HoursWorked { get; }
        public VolunteerNurse(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }
        public void GetInfo()
        {
            Console.WriteLine(string.Format("Volunteering nurse {0} worked {1} hours", Name, HoursWorked));
        }
    }
}
