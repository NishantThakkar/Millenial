using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Millennial.DB;
using Serilog;
using Millennial.Core.Repository.Interface;
using Millennial.Core.Repository.Implementation;
using Millennial.Core.Service.Interface;
using Millennial.Core.Service.Implementation;
using Microsoft.OpenApi.Models;

namespace Millennial.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string CorsPolicy = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });
            });
            services.AddControllers();
            services.AddDbContext<ECommerceDemoContext>(context => context.UseSqlServer(Configuration.GetConnectionString("MillennialConnectionString"), b => b.MigrationsAssembly("Millennial.API")));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Demo", Version = "v1" });
            });
            //services.ConfigureLogging AddSerilog();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(CorsPolicy);
            app.UseHttpsRedirection();

            var logPath = Configuration.GetValue<string>("Logging:FilePath");
            loggerFactory.AddFile(logPath);
            //loggerFactory.AddFile()
            //.CreateLogger<Startup>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
