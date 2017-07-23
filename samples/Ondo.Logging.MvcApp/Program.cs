using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Ondo.Logging.Adapters;

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
