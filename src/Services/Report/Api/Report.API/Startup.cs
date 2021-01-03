using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Report.Core.Repository;
using Report.Data.Contexts;
using Report.Service.Query.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Report.API
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
            services.AddHealthChecks();
            services.AddOptions();

            services.AddDbContext<ReportContext>(options =>
                                                options.UseNpgsql(Configuration.GetConnectionString("Defaultconnection"),
                                                b => b.MigrationsAssembly("Report.Data")));
            services.AddScoped<DbContext>(provider => provider.GetService<ReportContext>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report.API", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<GetAllCountOfContactRegisteredToLocationQuery, int>,
                                                  GetAllCountOfContactRegisteredToLocationQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllLocationQuery, List<string>>, GetAllLocationQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllNumbersInLocationQuery, int>, GetAllNumbersInLocationQueryHandler>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IReportRepository, ReportRepository>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
