using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.Patients;


[TestClass]
public class GetPatientsListQueryHandlerTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IPatientRepository repository;
    private GetPatientsListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IPatientRepository>();
        handler = new GetPatientsListQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_ValidQuery_ReturnsPaginatedPatients()
    {
        int page = 1;
        int pageSize = 2;
        PaginationFilter paginationFilter = new PaginationFilter(page, pageSize);

        Patient p1 = new("a", new CleanTeeth.Domain.ValueObjects.Email("a@example.com"));
        Patient p2 = new("b", new CleanTeeth.Domain.ValueObjects.Email("b@example.com"));

        IEnumerable<Patient> patients = [p1, p2];

        repository.GetPatientsPaginated(Arg.Any<PaginationFilter>()).Returns(Task.FromResult(patients));
        repository.GetTotalAmountOfRecords().Returns(Task.FromResult(10));


        GetPatientsListQuery query = new()
        {
            Page = paginationFilter.Page,
            PageSize = paginationFilter.PageSize
        };
        var result = await handler.Handle(query);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.TotalCount, 10);
        Assert.AreEqual(result.Enitites.Count, pageSize);

    }
}
