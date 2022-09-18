using System;

namespace SOLIDPrinciples
{
    abstract class Employee
    {
        private string _name;
        private int _hoursWorked;
        public Employee() { }
        public Employee(string name, int hoursWorked)
        {
            _name = name;
            _hoursWorked = hoursWorked;
        }

        public abstract void CalculateSalary(float salary); 
        public string GetName() { return _name; }
        public int GetHoursWorked() { return _hoursWorked; }
        public abstract void GetInfo();
    }

    class Nurse : Employee
    {
        public Nurse (string name, int hoursWorked) : base(name, hoursWorked){   }
        public override void CalculateSalary(float salary)
        {
            Console.WriteLine(string.Format("Nurse {0} got {1} money",GetName(), salary+(GetHoursWorked()*2)));
        }

        public override void GetInfo()
        {
            Console.WriteLine(string.Format("Nurse {0} worked {1} hours", GetName(), GetHoursWorked()));
        }
    }

    class Doctor : Employee
    {
        public Doctor(string name, int hoursWorked) : base(name, hoursWorked) { }
        public override void CalculateSalary(float salary)
        {
            Console.WriteLine(string.Format("Doctor {0} got {1} money", GetName(), salary + (GetHoursWorked() * 5)));
        }

        public override void GetInfo()
        {
            Console.WriteLine(string.Format("Doctor {0} worked {1} hours", GetName(), GetHoursWorked()));
        }
    }

    class VolunteerNurse : Employee
    {
        public VolunteerNurse(string name, int hoursWorked) : base(name, hoursWorked) { }
        public override void CalculateSalary(float salary)
        {
            throw new NotImplementedException();
        }

        public override void GetInfo()
        {
            Console.WriteLine(string.Format("Volunteering nurse {0} worked {1} hours", GetName(), GetHoursWorked()));
        }
    }
}
