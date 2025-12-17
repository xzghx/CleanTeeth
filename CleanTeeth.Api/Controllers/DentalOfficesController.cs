using CleanTeeth.Api.DTOs.DentalOffices;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.Api.Controllers;


[ApiController]
[Route("DentalOffices")]
public class DentalOfficesController : ControllerBase
{
    private readonly IMediator mediator;

    public DentalOfficesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DentalOfficeDetailDto>> Get(Guid id)
    {
        var query = new GetDentalOfficeDetailQuery { Id = id };
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<DentalOfficesListDto>>> Get()
    {
        var query = new GetDentalOfficesListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDentalOfficeDto dto)
    {
        var command = new CreateDentalOfficeCommand { Name = dto.Name };
        await mediator.Send(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id , UpdateDentalOfficeDto input)
    {
        var command = new UpdateDentalOfficeCommand
        {
            Id = id,
            Name = input.Name
        };

        await mediator.Send(command);
        return NoContent();
    }

}
