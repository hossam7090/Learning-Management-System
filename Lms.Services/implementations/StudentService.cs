using Azure.Core;
using Lms.Data.Entities;
using Lms.Data.Helpers;
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
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion


        #region Constractor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion


        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentsByIDAsync(int Id)
        {
            return await _studentRepository.GetByIdAsync(Id);

        }

        public async Task<string> AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return "Success";

        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = _studentRepository.GetTableNoTracking().Where(s => s.Name.Equals(name)).FirstOrDefault();
            if (student == null)
            {
                return false;

            }
            else
            {

                return true;
            }
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int Id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(s => s.Name.Equals(name) & !s.StudID.Equals(Id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);
            return "Success";
        }

        public async Task<Student> GetStudentsByIdIncludeDeptAsync(int Id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(s => s.Department)
                                            .Where(s => s.StudID == Id)
                                            .FirstOrDefault();
            return student;
        }

        public IQueryable<Student> GetStudentQuerable(string? s, StudentOrderingEnum? orderingEnum)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            if (s != null)
            {
                querable = querable.Where(x => x.Name == s || x.Address == s);
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.Name);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DeptId:
                    querable = querable.OrderBy(x => x.DID);
                    break;
                default
                    :
                    return querable;
            }
            return querable;


        }
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();
        }
        #endregion
    }
}
