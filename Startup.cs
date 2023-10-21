using System;
using FestivaNow.Ads.Services.Impl;
using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Connector.Redis;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint;

namespace FestivaNow.Ads
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(Configuration);
            services.AddDistributedRedisCache(Configuration);
            services.AddAllActuators(Configuration);
            services.ActivateActuatorEndpoints();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FestivaNow.Ads", Version = "v1" });
            });

            //Set Config here, the dependency has a bug
            //Configuration["Redis:Client:Host"] = "192.168.1.130";//Environment.GetEnvironmentVariable("REDIS_URL");
            //Configuration["Redis:Client:Port"] = "6379";//Environment.GetEnvironmentVariable("REDIS_PORT");;
            services.AddRedisConnectionMultiplexer(Configuration);

            services.AddScoped<IAdsService, AdsService>();
            services.AddScoped<IAdsCreationService, AdsCreationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FestivaNow.Ads"));
            }

            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
