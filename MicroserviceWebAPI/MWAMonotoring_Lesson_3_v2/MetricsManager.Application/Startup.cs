using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Repositories;
using MetricsManager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void DataBaseCreate()
        {
            using var connection = new SQLiteConnection("Data source=metrics.db");
            connection.Open();
            
            // Delete prev tabel;
            using var commandDrop = new SQLiteCommand(connection);
            commandDrop.CommandText = "drop table Agents;";
            commandDrop.ExecuteNonQuery();
            
            using var command = new SQLiteCommand(connection);
            command.CommandText = @"
                create table Agents
                    (
	                    id integer not null
		                    constraint Agents_pk
			                    primary key autoincrement,
	                    uri TEXT not null
                    );
            ";

            command.ExecuteNonQuery();
        }

        private void DataBaseAddSeeding()
        {
            using var connection = new SQLiteConnection("Data source=metrics.db");
            connection.Open();
            using var command = new SQLiteCommand(connection);

            command.CommandText = "INSERT INTO Agents (uri) VALUES (@uri);";
            command.Parameters.AddWithValue("@uri", "http://localhost:5000");
            command.Prepare();
            command.ExecuteNonQuery();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Scrutor
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsManager", Version = "v1" });
            });

            services.AddTransient<IAgentServices, AgentServices>();
            services.AddTransient<AgentRepository>();
            DataBaseCreate();
            DataBaseAddSeeding();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsManager v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}