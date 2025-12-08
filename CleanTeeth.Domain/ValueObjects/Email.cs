using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.ValueObjects;

public class Email
{
    public string Value { get; } = null!;
    public Email(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new BusinessRuleException($"The {nameof(email)} isRequired.");
        }
        if (!email.Contains("@"))
        {
            throw new BusinessRuleException($"The {nameof(email)} is not valid email address..");
        }
        Value = email;
    }
}
