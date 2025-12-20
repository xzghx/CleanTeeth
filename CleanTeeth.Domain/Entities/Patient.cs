using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;


    private Patient() { }


    public Patient(string name, Email email)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} isRequired.");
        }
        if (email is null)
        {
            throw new BusinessRuleException($"The {nameof(name)} isRequired.");
        }


        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }
}
