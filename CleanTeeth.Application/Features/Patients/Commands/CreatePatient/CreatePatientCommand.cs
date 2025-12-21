using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}
