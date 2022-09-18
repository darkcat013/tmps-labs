using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open Closed Principle bad
            int a = 3, b = 5;
            Calcuator calcuator = new Calcuator();
            Console.WriteLine(string.Format("a={0}, b={1}", a, b));
            calcuator.GetAvailableOperations();
            calcuator.Calculate(a, b, '+');
            calcuator.Calculate(a, b, '-');
            Console.ReadKey();
        }
    }
}
