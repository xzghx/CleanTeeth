using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities;

[TestClass]
public class PatientTests
{

    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Constructor_NullName_Throws()
    {
        var email = new Email("abc@gmail.com");
        new Patient(null!, email);
    }

    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Constructor_NullEmail_Throws()
    {
        new Patient("jackson", null!);
    }

    [TestMethod]
    public void Constructor_NoException()
    {
        var email = new Email("abc@gmail.com");
        new Patient("jackson", email);
    }
}
