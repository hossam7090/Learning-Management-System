using Lms.Data.Helpers;
using Lms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);
        public IQueryable<Student> GetStudentQuerable(string? search, StudentOrderingEnum? Order);
        public Task<Student> GetStudentsByIDAsync(int Id);
        public Task<Student> GetStudentsByIdIncludeDeptAsync(int Id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name,int Id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);

    }
}
