using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries;

public static class MapperExtensions
{
    public static DentalOfficeDetailDto ToDto(this DentalOffice dentailOffice)
    {
        var dto = new DentalOfficeDetailDto()
        {
            Id = dentailOffice.Id,
            Name = dentailOffice.Name
        };

        return dto;
    }
}
