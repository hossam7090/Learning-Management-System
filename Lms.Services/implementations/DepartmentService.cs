using Lms.Data.Entities;
using Lms.Infrastructure.Repositories.Abstracts;
using Lms.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Services.implementations
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion


        #region Constractor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        #endregion


        #region Handle Functions

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                 .Include(x => x.DepartmentSubjects).ThenInclude(x=>x.Subject)
                                                 .Include(x => x.Instructors)
                                                 .Include(x => x.Instructor).FirstOrDefaultAsync();
        }
        #endregion
    }
}
