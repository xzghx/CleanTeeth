using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientById;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdDto>
{
    private readonly IPatientRepository repository;

    public GetPatientByIdQueryHandler(IPatientRepository repository)
    {
        this.repository = repository;
    }
    public async Task<GetPatientByIdDto> Handle(GetPatientByIdQuery request)
    {
        Patient? patient = await repository.GetById(request.Id);

        if (patient == null)
        {
            throw (new NotFoundException());
        }

        return patient.toDto();
    }
}
