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
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Feilds
        private DbSet<Student> Students;
        #endregion

        #region Constructor(s)
        public StudentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
           Students = dbContext.Set<Student>();
        }
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dbContext.students.Include(d=>d.Department).ToListAsync();
        }
        #endregion

    }
}
