using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassDemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionWorker worker = new ReflectionWorker();
            worker.Start();
            
            Console.ReadLine();

            // demo of Linq-code
            //var l = new List<string>().Where( s=>s=="");
        }
    }
}
