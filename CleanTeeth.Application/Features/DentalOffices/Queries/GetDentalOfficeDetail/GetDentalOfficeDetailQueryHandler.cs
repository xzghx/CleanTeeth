using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQueryHandler : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDto>
{
    private readonly IDentalOfficeRepository repository;

    public GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository repository)
    {
        this.repository = repository;
    }
    public async Task<DentalOfficeDetailDto> Handle(GetDentalOfficeDetailQuery request)
    {
        var dentailOffice = await repository.GetById(request.Id);

        if (dentailOffice is null)
        {
            throw new NotFoundException();
        }

        var dto = new DentalOfficeDetailDto()
        {
            Id = dentailOffice.Id,
            Name = dentailOffice.Name
        };

        return dto;
    }
}
