using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.ValueObjects;

[TestClass]
public class TimeIntervalTests
{
    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Constructor_StartIsAfterEnd_Throws()
    {
        new TimeInterval(
                start: DateTime.UtcNow,
                end: DateTime.UtcNow.AddDays(-1)
            );
    }

    [TestMethod]
    public void Constructor_NoException()
    {
        new TimeInterval(DateTime.UtcNow, DateTime.UtcNow.AddHours(1));
    }


}
