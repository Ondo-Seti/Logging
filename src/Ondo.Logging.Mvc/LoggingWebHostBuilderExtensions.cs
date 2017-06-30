using Ondo.Logging.Abstractions;
using Ondo.Logging.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Ondo.Logging.Mvc
{
    public static class LoggingWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseOndoLogging<T>(this IWebHostBuilder webHostBuilder) where T : class, ILoggerAdapter, new()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            var loggerFactory = new LoggerFactory();

            webHostBuilder
                         .ConfigureServices(services =>
                         {
                             services.AddOndoLogging<T>(loggerFactory, configuration.GetSection("LoggingOptions").Get<LoggingOptions>());
                         })
                         .UseLoggerFactory(loggerFactory);

            return webHostBuilder;
        }
    }
}
