using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Report.Service.Command.Create;
using Report.Service.Query.List;
using Report.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Report.Service.Dependency
{
    public static class ReportServiceDependencyInjection
    {
        public static IServiceCollection ReportService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IRequestHandler<GetAllCountOfContactRegisteredToLocationQuery, int>, GetAllCountOfContactRegisteredToLocationQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllLocationQuery, List<string>>, GetAllLocationQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllNumbersInLocationQuery, int>, GetAllNumbersInLocationQueryHandler>();
            services.AddScoped<IRequestHandler<CreateContactInformationCommand, Unit>, CreateContactInformationCommandHandler>();
            services.AddScoped<IContactInformationToPersonService, ContactInformationToPersonService>();
             
            return services;
        }
    }
}
