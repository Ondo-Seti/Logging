using Microsoft.Extensions.Logging;
using System;

namespace Ondo.Logging.Abstractions
{
    /// <summary>
    /// Kan Test
    /// </summary>
    public interface ILoggerAdapter: IDisposable
    {
        void AddLog(ILoggerFactory loggerFactory, LoggingOptions loggingOptions);
    }
}