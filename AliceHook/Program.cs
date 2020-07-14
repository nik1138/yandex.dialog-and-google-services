using Microsoft.AspNetCore.Hosting;
using System;

namespace AliceHook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartServer();  
        }
        private static void StartServer()
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build()
                .Run();
            Console.WriteLine("Son4a");
        }
    }
}