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
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Feilds
        private DbSet<Instructor> Instructors;
        #endregion

        #region Constructor(s)
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            Instructors = dbContext.Set<Instructor>();
        }
        #endregion

        #region Handle Functions
        
        #endregion

    }
}
