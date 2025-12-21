using CleanTeeth.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.Api.DTOs.Patients;

public class CreatePatientDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }


    [Required]
    [MaxLength(254)]
    [EmailAddress]
    public required string Email { get; set; }
}
