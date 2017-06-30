using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Ondo.Logging.Adapters;
using Microsoft.Extensions.Configuration;
using Ondo.Logging.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ondo.Logging.Abstractions;

namespace Ondo.Logging.Mvc
{
    public class Program
    {
       public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseOndoLogging<SerilogAdapter>()                
                .Build();            

            host.Run();
        }
    }
}
