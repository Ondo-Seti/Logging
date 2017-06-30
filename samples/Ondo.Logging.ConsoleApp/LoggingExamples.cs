using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ondo.Logging.ConsoleApp
{
    internal class LoggingExamples
    {
        private readonly ILogger _logger;
        public LoggingExamples(ILogger<LoggingExamples> logger)
        {
            _logger = logger;
        }

        internal void ShowLogExamples(string userInputFromConsole)
        {
            if (userInputFromConsole == LogLevel.Trace.ToString("D"))
            {
                _logger.LogTrace($"Log level {LogLevel.Trace}");
            }
            else if (userInputFromConsole == LogLevel.Debug.ToString("D"))
            {
                _logger.LogDebug($"Log level {LogLevel.Debug}");
            }
            else if (userInputFromConsole == LogLevel.Information.ToString("D"))
            {
                _logger.LogInformation($"Log Level {LogLevel.Information}");
            }
            else if (userInputFromConsole == LogLevel.Warning.ToString("D"))
            {
                _logger.LogWarning($"Log Level {LogLevel.Warning}");
            }
            else if (userInputFromConsole == LogLevel.Error.ToString("D"))
            {
                var ex = new ArgumentNullException();
                //proper way to use method signature to log exception object
                _logger.LogError(LoggingEvents.EXAMPLE, ex, $"Log level {LogLevel.Error} with {nameof(ArgumentNullException)}");

                //this just log string, do not use for exception object logging
                _logger.LogError($"Log level {LogLevel.Error}");

                try
                {
                    throw new Exception("Inner Demo", new NullReferenceException("Message from Inner Exception"));
                }
                catch (Exception exc)
                {
                    _logger.LogError(LoggingEvents.EXAMPLE, exc, $"Log level {LogLevel.Error} with {nameof(ex)}");
                }                
            }
            else if (userInputFromConsole == LogLevel.Critical.ToString("D"))
            {
                _logger.LogCritical(LoggingEvents.EXAMPLE, new NullReferenceException(), $"Log level {LogLevel.Critical} with {nameof(NullReferenceException)}");
            }
        }
    }
}
