using Lms.Core.Features.Students.Commands.Models;
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
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt
                .MapFrom(src => src.DepartmementId));
            
        }
    }
}
