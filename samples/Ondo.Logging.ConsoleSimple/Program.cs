using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ondo.Logging.ConsoleSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Ondo.Logging.Desktop.Application.UseOndoLogging())
            {
                var logger = Ondo.Logging.ApplicationLogging.CreateLogger<Program>();

                logger.LogInformation("Information is logged");
            }
            
        }
    }
}
