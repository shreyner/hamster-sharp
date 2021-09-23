using Agent.Client;
using MetricsManager.DB;
using MetricsManager.Entities;
using MetricsManager.Service.Jobs;
using MetricsManager.Service.Mapper;
using MetricsManager.Service.Services;
using MetricsManager.Service.Services.MetricsCollector;
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
using CronExpression = MetricsManager.Service.Jobs.CronExpression;

namespace MetricsManager.Application
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsManager.Application", Version = "v1" });
            });

            services.AddHttpClient<IAgentClient, AgentClient>();
            
            services.AddSingleton<IMetricsManagerMapper, MetricsManagerMapper>();
            
            services.AddScoped<DbRepository<Entities.Agent>>();
            services.AddScoped<DbRepository<CpuMetric>>();
            services.AddScoped<DbRepository<DotNetMetric>>();
            services.AddScoped<DbRepository<HddMetric>>();
            services.AddScoped<DbRepository<NetworkMetric>>();
            services.AddScoped<DbRepository<RamMetric>>();
            
            services.AddScoped<AgentService>();
            services.AddScoped<CpuMetricsCollectorService>();
            services.AddScoped<HddMetricsCollectorService>();
            services.AddScoped<MetricsCollectorService>();
            
            services.AddScoped<MetricsCollectorJob>();

            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            
            services.AddSingleton(new JobSchedule(
                jobType: typeof(MetricsCollectorJob),
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsManager.Application v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}