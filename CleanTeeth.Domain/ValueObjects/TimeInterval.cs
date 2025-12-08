using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.ValueObjects;

public class TimeInterval
{
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }


    public TimeInterval(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new BusinessRuleException($"The startTime must be before endTime." +
                $"the given startTime is {start} and the give endTime is {end}");
        }

        StartTime = start;
        EndTime = end;
    }
}
