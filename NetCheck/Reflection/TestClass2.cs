using System;

namespace Reflection
{
    public class TestClass2
    {
        [Custom]
        public void Hello()
        {
            Console.WriteLine("Hello() called");
        }

        [Custom]
        public string TestNoParameters()
        {
            Console.WriteLine("TestNoParameters() called");

            return "TestNoParameters() called";
        }

        [Custom]
        public void Execute(object[] parameters)
        {
            Console.WriteLine("Execute() called");
            Console.WriteLine("Number of parameters received: " + parameters.Length);

            foreach (var parameter in parameters)
            {
                Console.WriteLine(parameter);
            }
        }
    }
}