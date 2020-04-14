using System;
using System.IO;
using System.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AopExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WithAutofac.Run();
        }
    }

    


}
