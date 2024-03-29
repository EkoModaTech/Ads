using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Extensions.Logging;

namespace FestivaNow.Ads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddPlaceholderResolver()
                .ConfigureLogging((context, builder) => builder.AddDynamicConsole())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging((builderContext, loggingBuilder) =>
                    {
                        loggingBuilder.AddDynamicConsole();
                    }
                );
                });
    }
}
