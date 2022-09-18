using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main()
        {
            //Open Closed Principle good
            int a = 3, b = 5;
            Operation add = new Addition();
            Operation subtract = new Subtraction();
            Operation[] operations = { add, subtract };
            Console.WriteLine("Available operations: ");
            foreach (var item in operations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(string.Format("a={0}, b={1}", a, b));
            add.Calculate(a, b);
            subtract.Calculate(a, b);

            Console.ReadKey();
        }
    }
}
