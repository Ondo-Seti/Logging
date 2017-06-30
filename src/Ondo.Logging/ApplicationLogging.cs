using Microsoft.Extensions.Logging;
using System;

namespace Ondo.Logging
{
    public class ApplicationLogging
    {
        internal static ILoggerFactory LoggerFactory { get; private set; }
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);

        internal static void UseLoggerFactory(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));            
        }
    }
}
