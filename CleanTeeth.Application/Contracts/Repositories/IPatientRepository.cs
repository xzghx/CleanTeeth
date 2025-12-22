using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Contracts.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    public Task<IEnumerable<Patient>> GetPatientsPaginated(PaginationFilter paginationParams);
}
