using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Reflection;

namespace NetCheck
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var reflectionDLLPath = $"{Directory.GetCurrentDirectory()}\\Reflection.dll";
            var reflectionDLL = Assembly.LoadFile(reflectionDLLPath);
            var testClass1 = reflectionDLL.GetExportedTypes().First(c => c.Name == nameof(TestClass1));

            dynamic instance = Activator.CreateInstance(testClass1);
            instance?.Method();
        }
    }
}