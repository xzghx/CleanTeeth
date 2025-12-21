using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.Patients;

[TestClass]
public class CreatePatientCommandHandlerTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IPatientRepository repository;
    private IUnitOfWork unitOfWork;
    private CreatePatientCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IPatientRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new CreatePatientCommandHandler(repository, unitOfWork);
    }


    [TestMethod]
    public async Task Handle_ValidCommand_ReturnsPatientId()
    {
        Patient entity = new Patient("Zahra", new Email("z@example.com"));

        var command = new CreatePatientCommand()
        { Name = "Zahra", Email = "z@example.com" };

        repository.Add(Arg.Any<Patient>()).Returns(entity);

        Guid id = await handler.Handle(command);

        await repository.Received(1).Add(Arg.Any<Patient>());
        await unitOfWork.Received(1).Commit();
        Assert.AreEqual(entity.Id, id);
    }


    [TestMethod]
    public async Task Handle_WhenThereIsAnError_WeRollback()
    {
        var command = new CreatePatientCommand() { Name = "Zahra", Email = "z@example.com" };

        repository.Add(Arg.Any<Patient>()).Throws<Exception>();

        await Assert.ThrowsExceptionAsync<Exception>(
            async () => await handler.Handle(command)
        );


        await repository.Received(1).Add(Arg.Any<Patient>());
        await unitOfWork.Received(1).RollBack();
    }
}
