using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientById;

internal static class MapperExtensions
{
    internal static GetPatientByIdDto toDto(this Patient patient)
    {
        return new GetPatientByIdDto
        {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email.Value
        };
    }
}
