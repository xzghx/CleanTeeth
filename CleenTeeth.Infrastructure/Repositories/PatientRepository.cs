using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly CleanTeethDbContext dbContext;

    public PatientRepository(CleanTeethDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Patient>> GetPatientsPaginated(PaginationFilter paginationParams)
    {
        var patients = await dbContext.Patients
            .OrderBy(p => p.Name)
            .Paginate<Patient>(paginationParams.Page, paginationParams.PageSize)
            .ToListAsync();
        return patients;
    }
}
