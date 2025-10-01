using Lms.Core.Features.Departments.Queries.Respones;
using Lms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIDMapping()
        {
            CreateMap<Department, GetDepartmentByIDResponse>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.localize(src.DNameAr, src.DNameEn)))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                 .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                 .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                 //.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students)) 
                 .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmetSubject, SubjectResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.localize(src.Subject.SubjectNameAr, src.Subject.SubjectName)));

            //CreateMap<Student, StudentResponse>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.localize(src.NameAr, src.Name)));

            CreateMap<Instructor, InstructorResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.localize(src.ENameAr, src.ENameEn)));
        }
    }
}
