using Lms.Core.Features.Students.Queries.Respones;
using Lms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentWithDeptNameMapping()
        {
            CreateMap<Student, GetStudentWithDeptNameResponse>()
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.localize(src.NameAr, src.Name)))
                .ForMember(dest => dest.DepartmentName, opt => opt
                .MapFrom(src => src.Department.localize(src.Department.DNameAr,src.Department.DNameEn)));
                

            
        }
    }
}
