using CleanTeeth.Api.DTOs.Patients;
using CleanTeeth.Api.Utilities;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanTeeth.Api.Controllers;

[ApiController]
[Route("Patients")]
public class PatientsController : ControllerBase
{
    private readonly IMediator mediator;

    public PatientsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetPatientsListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);

    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(CreatePatientDto inputs)
    {
        var command = new CreatePatientCommand()
        {
            Name = inputs.Name,
            Email = inputs.Email
        };

        var result = await mediator.Send(command);
        return Ok(result);

    }
}
