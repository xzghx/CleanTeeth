using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsListl
{
    internal static class MapperExtensions
    {
        internal static GetPatientsListDto toDto(this Patient patient)
        {
            return new GetPatientsListDto()
            {
                id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value
            };

        }
    }
}
