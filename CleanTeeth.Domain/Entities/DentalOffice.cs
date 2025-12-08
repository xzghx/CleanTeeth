using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get; private set; }

    //It is initialized with null but with a null-forgiving operator, indicating that the developer ensures it will be assigned a non-null value before use.
    public string Name { get; private set; } = null!;//null-forgiving operator


    public DentalOffice(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} isRequired.");
        }

        Name = name;
        Id = Guid.CreateVersion7();
    }
}
