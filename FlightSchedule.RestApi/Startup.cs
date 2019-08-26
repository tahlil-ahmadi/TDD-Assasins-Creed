using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSchedule.Application;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Persistence.EF;
using FlightSchedule.RestApi.Middlewares;
using FlightSchedule.RestApi.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightSchedule.RestApi
{
    public class Startup
    {
        private FlightScheduleOptions _options;
        public Startup(IConfiguration configuration)
        {
            _options = configuration.Get<FlightScheduleOptions>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<ICharterScheduleService, CharterScheduleService>();
            services.AddScoped<IConnectionManager, ConnectionManager>();
            //services.AddScoped<FlightScheduleDbContext>(a =>
            //{
            //    var connectionManager = a.GetService(typeof(IConnectionManager)) as IConnectionManager;
            //    var builder = new DbContextOptionsBuilder();
            //    builder.UseSqlServer(connectionManager.Get());
            //    return new FlightScheduleDbContext(builder.Options);
            //});

            services.AddDbContext<FlightScheduleDbContext>(a => a.UseSqlServer(_options.ConnectionString));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSandbox();
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
