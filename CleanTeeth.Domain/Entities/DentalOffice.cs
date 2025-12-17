using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get; private set; }

    //It is initialized with null but with a null-forgiving operator, indicating that the developer ensures it will be assigned a non-null value before use.
    public string Name { get; private set; } = null!;//null-forgiving operator


    public DentalOffice(string name)
    {
        CheckValidationRules(name);

        Name = name;
        Id = Guid.CreateVersion7();
    }

    public void UpdateName(string name)
    {
        CheckValidationRules(name);

        Name = name;

    }
    void CheckValidationRules(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} isRequired.");
        }
    }
}
