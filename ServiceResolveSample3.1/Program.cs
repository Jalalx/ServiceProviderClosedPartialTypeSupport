using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceResolveSample2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new ServiceCollection()
                .AddSingleton(typeof(Service<>), typeof(Service2<>))
                .BuildServiceProvider();

            var service2 = provider.GetService(typeof(Service<Status>));

            Console.WriteLine("Hello World!");
        }
    }

    public enum Status { Pending, Done }

    public class Service<TEnum> where TEnum : Enum
    {
        public TEnum Status { get; set; }
    }

    public class Service2<TEnum> where TEnum : Enum
    {
        public TEnum Status { get; set; }
    }

}
