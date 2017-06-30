using Ondo.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Ondo.Logging.Extensions.DependencyInjection
{
    public static class LoggingServiceCollectionExtensions
    {
        public static IServiceCollection AddOndoLogging<T>(this IServiceCollection services, IConfiguration configuration) where T : class, ILoggerAdapter
        {

            services.AddLogging()
                    .AddOptions()
                    .AddSingleton<LoggingSetup>()
                    .AddSingleton<ILoggerAdapter, T>()
                    .Configure<LoggingOptions>(configuration.GetSection("LoggingOptions"))
                    .AddScoped(cfg => cfg.GetService<IOptions<LoggingOptions>>().Value);

            return services;
        }       

        public static IServiceCollection AddOndoLogging<TLoggerAdapter>(this IServiceCollection services, ILoggerFactory loggerFactory, LoggingOptions options) where TLoggerAdapter : class, ILoggerAdapter, new()

        {
            services.AddSingleton(loggerFactory)
            .AddOptions()
            .AddSingleton(new LoggingSetup(loggerFactory, new TLoggerAdapter(), options))
            .AddSingleton<ILoggerAdapter, TLoggerAdapter>();            

            return services;
        }
    }
}
