using Microsoft.Extensions.Logging;
using System;

namespace Ondo.Logging.Abstractions
{
    public interface ILoggerAdapter: IDisposable
    {
        void AddLog(ILoggerFactory loggerFactory, LoggingOptions loggingOptions);
    }
}