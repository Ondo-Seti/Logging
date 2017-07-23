using Microsoft.AspNetCore.Builder;

namespace Ondo.Logging.Mvc
{
    public static class LoggingBuilderExtensions
    {
        public static void UseOndoLogging(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService(typeof(LoggingSetup));
        }
    }
}
