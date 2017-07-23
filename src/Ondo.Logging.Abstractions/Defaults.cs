using Microsoft.Extensions.Logging;

namespace Ondo.Logging.Abstractions
{
    public class Defaults
    {
        public const string APPLICATION_NAME_KEY = "ApplicationName";
        internal static readonly LogLevel MINIMUM_LOG_LEVEL = LogLevel.Information;
        

        #region Rolling File 

        internal static readonly bool INCLUDE_FILE = true;
        internal static readonly string FILE_NAME = @"Logs\log-{Date}.txt";
        internal static readonly int MAX_NUMBER_OF_FILES_TO_KEEP = 31;
        internal static readonly long ONE_MEGABYTE = 1024 * 1024;

        #endregion

        #region Console

        internal static readonly bool INCLUDE_CONSOLE = false;

        #endregion

        #region LogServer

        internal static readonly bool INCLUDE_LOG_SERVER = true;
        internal static readonly string SEQ_URL = "http://localhost:5341/";

        #endregion

        public enum ServerType
        {
            Seq = 0,
            Rest = 1
        };


    }
}
