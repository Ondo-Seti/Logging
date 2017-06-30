using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Extensions.Logging
{
    public static class ILoggerExtensions
    {
        public static void LogDebug(
            this ILogger logger,
            string message,
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerFilePath] string callerFilePath = null,
            [CallerMemberName] string callerMemberName = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message).Append(" at line ").Append(callerLineNumber).Append(" in file ").Append(callerFilePath)
                .Append(" (").Append(callerMemberName).Append(")");

            logger.LogDebug(new EventId(), sb.ToString());
        }
    }
}
