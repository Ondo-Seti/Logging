using System;
using Ondo.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using System.Linq;

namespace Ondo.Logging.Adapters
{
    public class SerilogAdapter : ILoggerAdapter, IDisposable
    {
        private LoggingOptions _loggingOptions;

        public void AddLog(ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
        {
            _loggingOptions = loggingOptions;

            try
            {
                ConfigureLogger(loggerFactory);
            }
            catch (Exception) { /*silently continue*/}
        }

        private void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration();

            loggerConfiguration.MinimumLevel.Is(ConvertLevel(_loggingOptions.MinimumLevel));

            if (_loggingOptions.RollingFile.Include)
            {
                loggerConfiguration.WriteTo.Async(RollingFile, bufferSize: 10000);
            }
            if (_loggingOptions.Console.Include)
            {
                loggerConfiguration.WriteTo.LiterateConsole();
            }
            if (_loggingOptions.LogServer.Include)
            {
                TrySeqConfiguration(loggerConfiguration);
                TryRestConfiguration(loggerConfiguration);                
            }

            loggerConfiguration.ApplyEnrichers(_loggingOptions);

            Log.Logger = loggerConfiguration.CreateLogger();

            loggerFactory.AddSerilog();
        }

        private void TrySeqConfiguration(LoggerConfiguration loggerConfiguration)
        {
            var server = _loggingOptions.LogServer.Servers.FirstOrDefault(item => item.Type.ToLower() == "seq");
            if (server != null)
            {
                try
                {
                    loggerConfiguration.WriteTo.Seq(serverUrl: server.Url);
                }
                catch (Exception) { } //silently continue seq configuration
            }
        }

        private void TryRestConfiguration(LoggerConfiguration loggerConfiguration)
        {
            var server = _loggingOptions.LogServer.Servers.FirstOrDefault(item => item.Type.ToLower() == "rest");
            if (server != null)
            {
                try
                {
                    loggerConfiguration.WriteTo.Http(server.Url, new Serilog.Sinks.Http.Options());
                }
                catch (Exception) { } //silently continue REST configuration
            }
        }

        private void RollingFile(LoggerSinkConfiguration sink)
        {
            sink.RollingFile(pathFormat: _loggingOptions.RollingFile.RollingFilePath,
                             retainedFileCountLimit: _loggingOptions.RollingFile.MaxNumberOfFilesToKeep,
                             fileSizeLimitBytes: _loggingOptions.RollingFile.FileSizeLimitInBytes);
        }

        /// <summary>
        /// Convert <see cref="Microsoft.Extensions.Logging.LogLevel"/> to <see cref="Serilog.Events.LogEventLevel"/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        static LogEventLevel ConvertLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return LogEventLevel.Fatal;
                case LogLevel.Error:
                    return LogEventLevel.Error;
                case LogLevel.Warning:
                    return LogEventLevel.Warning;
                case LogLevel.Information:
                    return LogEventLevel.Information;
                case LogLevel.Debug:
                    return LogEventLevel.Debug;
                case LogLevel.Trace:
                default:
                    return LogEventLevel.Verbose;
            }
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
                Log.CloseAndFlush();
            }
        }

        #endregion              
    }
}
