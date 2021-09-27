using System;
using Agent.DB;
using Agent.DB.Entities;
using Agent.Service.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using CronExpression = Agent.Service.Jobs.CronExpression;

namespace Agent.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("connection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agent.Application", Version = "v1" });
            });

            services.AddScoped<DbRepository<CpuMetric>>();
            services.AddScoped<DbRepository<NetworkMetric>>();
            services.AddScoped<DbRepository<DotNetMetric>>();
            services.AddScoped<DbRepository<HddMetric>>();
            services.AddScoped<DbRepository<RamMetric>>();

            // Job Scheduler
            services.AddScoped<CpuMetricJob>();
            services.AddScoped<HddMetricJob>();
            services.AddScoped<RamMetricJob>();
            services.AddScoped<DotNetMetricJob>();
            services.AddScoped<NetworkMetricJob>();

            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: CronExpression.Every5Second.Value
            ));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: CronExpression.Every5Second.Value
            ));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: CronExpression.Every5Second.Value
            ));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: CronExpression.Every5Second.Value
            ));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotNetMetricJob),
                cronExpression: CronExpression.Every5Second.Value
            ));
            
            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agent.Application v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}