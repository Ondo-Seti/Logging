using Ondo.Logging.Abstractions;

namespace Serilog
{
    internal static class LoggerConfigurationExtensions
    {
        internal static LoggerConfiguration ApplyEnrichers(this LoggerConfiguration loggerConfiguration, LoggingOptions options)
        {
            loggerConfiguration
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithProperty(Defaults.APPLICATION_NAME_KEY, options.ApplicationName)
                .Enrich.FromLogContext();

            return loggerConfiguration;
        }
    }
}
