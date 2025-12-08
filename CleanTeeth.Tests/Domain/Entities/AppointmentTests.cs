using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities;

[TestClass]
public class AppointmentTests
{
    private Guid _patientId = new Guid();
    private Guid _dentistId = new Guid();
    private Guid _dentalOfficeId = new Guid();
    private TimeInterval _timeInterval =
        new TimeInterval(
            DateTime.UtcNow.AddDays(1),
            DateTime.UtcNow.AddDays(2)
        );

    [TestMethod]
    public void Constructor_ValidAppointment_StatusIsScheduled()
    {
        var appointment = new Appointment(
                  patientId: _patientId,
                  dentistId: _dentistId,
                  dentalOfficeId: _dentalOfficeId,
                  timeInterval: _timeInterval
            );

        Assert.AreEqual(_patientId, appointment.PatientId);
        Assert.AreEqual(_dentistId, appointment.DentistId);
        Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
        Assert.AreEqual(_timeInterval, appointment.TimeInterval);
        Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
        Assert.AreNotEqual(Guid.Empty, appointment.Id);

    }


    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Constructor_StartTimeInThePAst_Throws()
    {
        var interval = new TimeInterval(
                                DateTime.UtcNow.AddDays(-1),
                                DateTime.UtcNow.AddDays(2)
                            );
        new Appointment(
                         _patientId,
                         _dentistId,
                         _dentalOfficeId,
                          interval
                   );

    }

    [TestMethod]
    public void Cancel_CancelingAppointment_ChangesStatusToCancel()
    {

        var appointment = new Appointment(
                           _patientId,
                           _dentistId,
                           _dentalOfficeId,
                           _timeInterval
                     );
        appointment.Cancel();

        Assert.AreEqual(AppointmentStatus.Canceled, appointment.Status);

    }

    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Cancel_CancelingAppointment_ThrowsIfStatusIsNotEcheduled()
    {

        var appointment = new Appointment(
                           _patientId,
                           _dentistId,
                           _dentalOfficeId,
                           _timeInterval
                     );
        appointment.Cancel();
        appointment.Cancel();
    }

    [TestMethod]
    public void Complete_CompletingAppointment_ChangeSatusToCompletd()
    {

        var appointment = new Appointment(
                           _patientId,
                           _dentistId,
                           _dentalOfficeId,
                           _timeInterval
                     );
        appointment.Complete();
        Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);

    }

    [TestMethod]
    [ExpectedException(typeof(BusinessRuleException))]
    public void Complete_CompletingAppointment_ThrowsIfStatusIsNotEcheduled()
    {

        var appointment = new Appointment(
                           _patientId,
                           _dentistId,
                           _dentalOfficeId,
                           _timeInterval
                     );
        appointment.Cancel();
        appointment.Complete();
    }
}
