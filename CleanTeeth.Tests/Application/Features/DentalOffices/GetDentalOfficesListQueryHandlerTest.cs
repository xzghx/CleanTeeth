using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficesListQueryHandlerTest
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    IDentalOfficeRepository repository;
    GetDentalOfficesListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        handler = new GetDentalOfficesListQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_WhenThereAreDentalOffices_ReturnsThem()
    {
        List<DentalOffice> dentalOfices = [
                            new DentalOffice("DentalOffice 1"),
                            new DentalOffice("DentalOffice 2"),
                            new DentalOffice("DentalOffice 3"),
                          ];

        repository.GetAll().Returns(dentalOfices);

        List<DentalOfficesListDto> expected = dentalOfices.Select(e => new DentalOfficesListDto()
        {
            Id = e.Id,
            Name = e.Name
        }).ToList();

        var query = new GetDentalOfficesListQuery();
        var result = await handler.Handle(query);

        Assert.AreEqual(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i].Id, result[i].Id);
            Assert.AreEqual(expected[i].Name, result[i].Name);
        }
    }

    [TestMethod]
    public async Task Handle_WhenThereIsNoDentalOffice_ReturnsEmptyList()
    {

        var dentalOffices = new List<DentalOffice>();
        repository.GetAll().Returns(dentalOffices);

        var query = new GetDentalOfficesListQuery();
        var result = await handler.Handle(query);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Count, 0);

    }
}
