using MedicationControlSystem.src.data;
using MedicationControlSystem.src.repositories;
using MedicationControlSystem.src.repositories.implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
namespace MedicationControlSystem
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

            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            // Configuraçãp Banco de Dados
            if (Configuration["Environment:Start"] == "PROD")
            {
                services.AddEntityFrameworkNpgsql()
                .AddDbContext<MCSystemContext>(
                opt =>
                opt.UseNpgsql(Configuration["ConnectionStringsProd:DefaultConnection"]));
            }
            else
            {
                services.AddDbContext<MCSystemContext>(
                opt =>
                opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));
            }

            // Configure repositories
            services.AddScoped<IPatient, PatientRepository>();
            services.AddScoped<IMedication, MedicationRepository>();


            // Configure controllers
            services.AddCors();
            services.AddControllers();

            // Configuration Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicationControlSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MCSystemContext context)
        {
            // Development Environment
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicationControlSystem v1");
                    c.RoutePrefix = String.Empty;
                });
            }

            



            app.UseRouting();

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseCors(c => c
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
           );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
