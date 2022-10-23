using System;

namespace SOLIDPrinciples
{
    interface Operation
    {
        void Calculate(float a, float b);
    }
    class Addition : Operation
    {
        public void Calculate(float a, float b)
        {
            Console.WriteLine(a+b);
        }
        
        public override string ToString()
        {
            return "Addition: +";
        }
    }
    class Subtraction : Operation
    {
        public void Calculate(float a, float b)
        {
            Console.WriteLine(a-b);
        }
        public override string ToString()
        {
            return "Subtraction: -";
        }
    }

}
