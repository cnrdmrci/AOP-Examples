using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AopExamples
{
    public class WithAutofac
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<Calculator>()
                .As<ICalculator>()
                .EnableInterfaceInterceptors();
            //  .InterceptedBy(typeof(CallLogger));

            builder.Register(c => new CallLogger(Console.Out));
            //  .Named<IInterceptor>("log-calls");

            using (var container = builder.Build())
            {
                var calculator = container.Resolve<ICalculator>();
                var result = calculator.Add(1, calculator.Multiply(2, 3));
                Console.WriteLine("Complete, program result is {0}.", result);
            }
        }
    }

    public interface ICalculator
    {
        int Add(int lhs, int rhs);
        int Multiply(int lhs, int rhs);
    }

    //[Intercept("log-calls")]
    [Intercept(typeof(CallLogger))]
    public class Calculator : ICalculator
    {
        public virtual int Add(int lhs, int rhs)
        {
            return lhs + rhs;
        }

        public virtual int Multiply(int lhs, int rhs)
        {
            return lhs * rhs;
        }
    }

    public class CallLogger : IInterceptor
    {
        TextWriter _output;

        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));
            _output.WriteLine($"Calling: {name}");
            _output.WriteLine($"Args: {args}");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed();
            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;
            _output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
            _output.WriteLine($"Execution Time: {executionTime} ms.");
        }
    }
}
