using Lms.Data.Entities;
using Lms.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Repositories.Abstracts
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
    }
}
