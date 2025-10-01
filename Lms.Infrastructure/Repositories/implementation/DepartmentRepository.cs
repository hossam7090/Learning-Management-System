using Lms.Data.Entities;
using Lms.Infrastructure.Data;
using Lms.Infrastructure.InfrastructureBases;
using Lms.Infrastructure.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Repositories.implementation
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Feilds
        private DbSet<Department> Departments;
        #endregion

        #region Constructor(s)
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            Departments = dbContext.Set<Department>();
        }
        #endregion

        #region Handle Functions
      
        #endregion

    }
}
