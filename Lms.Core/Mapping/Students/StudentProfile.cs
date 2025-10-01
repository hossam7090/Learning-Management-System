using AutoMapper;
using Lms.Core.Features.Students.Queries.Respones;
using Lms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentWithDeptNameMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
