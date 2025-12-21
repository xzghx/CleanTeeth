using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsListl;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;

public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<GetPatientsListDto>>
{
    private readonly IPatientRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public GetPatientsListQueryHandler(
        IPatientRepository repository,
        IUnitOfWork unitOfWork
        )
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }
    public async Task<List<GetPatientsListDto>> Handle(GetPatientsListQuery request)
    {

        try
        {
            var result = await repository.GetAll();
            return result.Select(e => e.toDto()).ToList();

        }
        catch (Exception)
        {
            await unitOfWork.RollBack();
            throw;
        }

    }
}
