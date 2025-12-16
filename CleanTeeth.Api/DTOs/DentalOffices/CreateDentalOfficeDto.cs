using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.Api.DTOs.DentalOffices;

public class CreateDentalOfficeDto
{
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
}
