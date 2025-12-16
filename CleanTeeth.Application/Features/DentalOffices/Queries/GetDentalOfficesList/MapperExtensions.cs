using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

internal static class MapperExtensions
{

    public static DentalOfficesListDto toDto(this DentalOffice dentalOffice)
    {
        var dto = new DentalOfficesListDto
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
        return dto;
    }

}
