using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\t" + "Reach the API from:");
            Console.WriteLine("\t" + "   \" http://localhost:3000/api/unit \"");
            Console.WriteLine("\t" + "Reach specific unit on:");
            Console.WriteLine("\t" + "   \" http://localhost:3000/api/unit/*index from unit overview* \"" + "\n");
            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
