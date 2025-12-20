using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(CleanTeethDbContext dbContext) : base(dbContext)
    {
    }
}
