using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsListl;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;

public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDto<GetPatientsListDto>>
{
    private readonly IPatientRepository repository;

    public GetPatientsListQueryHandler(IPatientRepository repository)
    {
        this.repository = repository;
    }
    public async Task<PaginatedDto<GetPatientsListDto>> Handle(GetPatientsListQuery request)
    {

        try
        {
            IEnumerable<Patient> result = await repository.GetPatientsPaginated(request);
            int totalCount = await repository.GetTotalAmountOfRecords();

            List<GetPatientsListDto> dtos = result
                                                .Select(e => e.toDto())
                                                .ToList();
            var paginatedDto = new PaginatedDto<GetPatientsListDto>()
            {
                Enitites = dtos,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };

            return paginatedDto;
        }
        catch (Exception)
        {
            throw;
        }

    }
}
