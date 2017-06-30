using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ondo.Logging.Mvc
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(Startup)} ctor begins");

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            

            _logger.LogInformation($"{nameof(Startup)} ctor ends");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseOndoLogging();
            app.UseMvc();
            

            var logger = ApplicationLogging.CreateLogger<Startup>();
            logger.LogInformation("Message from Configure Method");
        }
    }
}
