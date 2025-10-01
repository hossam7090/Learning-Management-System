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
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Feilds
        private DbSet<Subject> Subjects;
        #endregion

        #region Constructor(s)
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            Subjects = dbContext.Set<Subject>(); 
        }
        #endregion

        #region Handle Functions
       
        #endregion

    }
}
