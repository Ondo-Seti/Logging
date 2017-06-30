using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ondo.Logging.Abstractions
{

    /// <summary>
    /// Class describing the available logging options for Ondo.Logging library/> 
    /// </summary>
    ///   
    public class LoggingOptions
    {

        /// <summary>
        /// Gets or sets the minimum logging level <see cref="Microsoft.Extensions.Logging.LogLevel"/>. 
        /// Default value is Microsoft.Extensions.Logging.LogLevel.Information <see cref="Microsoft.Extensions.Logging.LogLevel.Information"/>
        /// </summary>
        public LogLevel MinimumLevel { get; set; } = Defaults.MINIMUM_LOG_LEVEL;
        public RollingFile RollingFile { get; set; } = new RollingFile();
        public Console Console { get; set; } = new Console();
        public LogServer LogServer { get; set; } = new LogServer();

#if NET45 || NET46
        public string ApplicationName { get; set; } = System.Reflection.Assembly.GetEntryAssembly().FullName;
#else
        public string ApplicationName { get; set; }
#endif
    }
}
