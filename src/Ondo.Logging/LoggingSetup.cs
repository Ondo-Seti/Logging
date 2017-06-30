using Microsoft.Extensions.Logging;
using Ondo.Logging.Abstractions;
using System;

namespace Ondo.Logging
{
    public class LoggingSetup : IDisposable
    {
        private readonly ILoggerAdapter _loggerAdapter;
        public ILoggerFactory LoggerFactory { get; }        

        public LoggingSetup(ILoggerFactory loggerFactory,
                            ILoggerAdapter loggerAdapter,
                            LoggingOptions options)
        {
            try
            {
                if (options == null) { options = new LoggingOptions(); }

                _loggerAdapter = loggerAdapter;
                _loggerAdapter.AddLog(loggerFactory, options);
                LoggerFactory = loggerFactory;
                ApplicationLogging.UseLoggerFactory(LoggerFactory);
            }
            catch (Exception) { } //silently continue
        }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _loggerAdapter.Dispose();
            }
        }

        #endregion              
    }
}
