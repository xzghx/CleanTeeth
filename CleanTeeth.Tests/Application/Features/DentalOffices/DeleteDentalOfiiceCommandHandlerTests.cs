using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
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
public class DeleteDentalOfiiceCommandHandlerTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private DeleteDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new DeleteDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExits_DeleteAndCommitAreCalled()
    {
        var dentalOffice = new DentalOffice("DentalOffice perfect");
        var id = dentalOffice.Id;

        repository.GetById(id).Returns(dentalOffice);
        var command = new DeleteDentalOfficeCommand() { Id = id };

        await handler.Handle(command);


        await repository.Received(1).Delete(dentalOffice);
        await unitOfWork.Received(1).Commit();

    }


    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Handle_WhenDentalOfficeNotExists_Throws()
    {
        var id = new Guid();

        var command = new DeleteDentalOfficeCommand() { Id = id };
        repository.GetById(id).ReturnsNull();

        await handler.Handle(command);
    }


    [TestMethod]
    public async Task Handle_WhenIdNotExists_RollBackIsCalled()
    {
        var dentalOffice = new DentalOffice("DentalOffice perfect");
        var id = dentalOffice.Id;

        repository.GetById(id).Returns(dentalOffice);
        repository.Delete(dentalOffice).Throws(new InvalidOperationException("Exception here"));

        var command = new DeleteDentalOfficeCommand() { Id = id };

        await Assert.ThrowsExceptionAsync<InvalidOperationException>
            (
              () => handler.Handle(command)
            );

        await unitOfWork.Received(1).RollBack();
    }
}
