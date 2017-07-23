using Ondo.Logging.Abstractions;
using Ondo.Logging.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Ondo.Logging.Desktop
{
    public class Application
    {
        public static LoggingSetup UseOndoLogging(LoggingOptions loggingOptions)
        {
            //TODO:Create LoggingSetup Factory class
            return new LoggingSetup(new LoggerFactory(), new SerilogAdapter(), loggingOptions);
        }

        public static LoggingSetup UseOndoLogging()
        {
            //TODO:Create LoggingSetup Factory class
            return new LoggingSetup(new LoggerFactory(), new SerilogAdapter(), Configure().GetSection("LoggingOptions").Get<LoggingOptions>());
        }

        public static IConfiguration Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
