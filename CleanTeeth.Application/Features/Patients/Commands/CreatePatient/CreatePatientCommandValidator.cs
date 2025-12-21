using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The fieled {PropertyName} is required.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("The fieled {PropertyName} is required.");


    }
}
