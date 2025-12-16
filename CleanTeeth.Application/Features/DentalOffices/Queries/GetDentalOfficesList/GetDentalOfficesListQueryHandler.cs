using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public class GetDentalOfficesListQueryHandler :
        IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDto>>
{
    private readonly IDentalOfficeRepository repository;

    public GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository)
    {
        this.repository = repository;
    }
    public async Task<List<DentalOfficesListDto>> Handle(GetDentalOfficesListQuery request)
    {
        var items = await repository.GetAll();
        List<DentalOfficesListDto> dtos = items.Select(e => e.toDto()).ToList();

        return dtos;
    }
}

