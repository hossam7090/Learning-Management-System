using Lms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Services.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
