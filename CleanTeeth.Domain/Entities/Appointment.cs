using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DentistId { get; private set; }
    public Guid DentalOfficeId { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public TimeInterval TimeInterval { get; private set; }
    public DateTime EndTime { get; private set; }
    public Patient? Patient { get; private set; }
    public Dentist? dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    public Appointment(
        Guid patientId,
        Guid dentistId,
        Guid dentalOfficeId,
        TimeInterval timeInterval
    )
    {
        if (timeInterval.StartTime < DateTime.UtcNow)
        {
            throw new BusinessRuleException($"The startTime can not be in the past." +
                $" the given startTime is {timeInterval.StartTime}");
        }


        PatientId = patientId;
        DentistId = dentistId;
        DentalOfficeId = dentalOfficeId;
        TimeInterval = timeInterval;
        Status = AppointmentStatus.Scheduled;
        Id = Guid.CreateVersion7();
    }


    public void Cancel()
    {
        if (Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Only scheduled apointments can get cancled. current status is{Status}");

        }
        Status = AppointmentStatus.Canceled;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Only scheduled apointments can get completed. current status is{Status}");

        }
        Status = AppointmentStatus.Completed;
    }
}
