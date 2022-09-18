using System;

namespace SOLIDPrinciples
{
    class Calcuator
    {
        public void Calculate(float a, float b, char operation)
        {
            switch (operation)
            {
                case '+': Console.WriteLine(a + b); break;
                case '-': Console.WriteLine(a - b); break;
                default:
                    Console.WriteLine("Operation does not exist");
                    break;
            }
        }

        public void GetAvailableOperations()
        {
            Console.WriteLine("Available operations: ");
            Console.WriteLine("Addition: +");
            Console.WriteLine("Subtraction: -");
        }
    }
}
