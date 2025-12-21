using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application;

public static class RegisterApplicationServices
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        //--------------//DentalOffices//--------------//
        services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>
            , CreateDentalOfficeCommandHandler>();

        services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDto>
            , GetDentalOfficeDetailQueryHandler>();

        services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDto>>
            , GetDentalOfficesListQueryHandler>();

        services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>
            , UpdateDentalOfficeCommandHandler>();

        services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>
            , DeleteDentalOfficeCommandHandler>();

        //--------------// Patients //--------------//
        services.AddScoped<IRequestHandler<CreatePatientCommand, Guid>
            , CreatePatientCommandHandler>();

        services.AddScoped<IRequestHandler<GetPatientsListQuery, List<GetPatientsListDto>>
            , GetPatientsListQueryHandler>();

        return services;
    }
}
