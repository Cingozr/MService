using AutoMapper;
using Contact.API.Models;
using Contact.API.Validators;
using Contact.Core.Repository;
using Contact.Data.Contexts;
using Contact.Data.Entities;
using Contact.Messaging.Options;
using Contact.Messaging.Sender;
using Contact.Service.Command.Create;
using Contact.Service.Command.Delete;
using Contact.Service.Query.List;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Contact.API
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
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);

            services.AddDbContext<ContactContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Defaultconnection"), b => b.MigrationsAssembly("Contact.Data")));
            services.AddScoped<DbContext>(provider => provider.GetService<ContactContext>());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.API", Version = "v1" });
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<CreateContactModel>, CreateContactValidator>();
            services.AddTransient<IValidator<CreateContactInformationModel>, CreateContactInformationValidator>();

            services.AddSingleton<IContactInformationSender, ContactInformationSender>();

            services.AddTransient<IRequestHandler<CreateContactCommand, bool>, CreateContactCommandHandler>();
            services.AddTransient<IRequestHandler<CreateContactInformationCommand, bool>, CreateContactInformationCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteContactCommand, bool>, DeleteContactCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteContactInformationCommand, bool>, DeleteContactInformationCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllContactInformationQuery, List<Contacts>>, GetAllContactInformationQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllContactQuery, List<Contacts>>, GetAllContactQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
