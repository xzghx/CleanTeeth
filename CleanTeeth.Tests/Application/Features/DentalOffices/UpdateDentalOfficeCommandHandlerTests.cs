using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class UpdateDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private UpdateDentalOfficeCommandHandler handler;


    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
    {
        var dentalOffice = new DentalOffice("DentalOffice AA");

        repository.GetById(dentalOffice.Id).Returns(dentalOffice);

        var command = new UpdateDentalOfficeCommand { Id = dentalOffice.Id, Name = "Dental Office AA Updated" };

        await handler.Handle(command);


        await repository.Received(1).Update(dentalOffice);
        await unitOfWork.Received(1).Commit();

    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Handle_WhenDentalOfficeNotExists_Throws()
    {
        var command = new UpdateDentalOfficeCommand { Id = new Guid(), Name = "some name" };
        repository.GetById(command.Id).ReturnsNull();

        await handler.Handle(command);

    }

    [TestMethod]
    public async Task Handle_WhenThereIsExceptionInUpdating_RollbackIsCalled()
    {
        var dentalOffice = new DentalOffice("Office A");
        var command = new UpdateDentalOfficeCommand { Id = dentalOffice.Id, Name = "New name" };
        repository.GetById(command.Id).Returns(dentalOffice);
        repository.Update(dentalOffice).Throws(new InvalidOperationException("TestException"));

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
            handler.Handle(command)
        );
        await unitOfWork.Received(1).RollBack();

    }

}
