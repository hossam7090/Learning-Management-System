using Lms.Core.Bases;
using Lms.Core.Features.Students.Queries.Respones;
using Lms.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentWithDeptNameResponse>>>
    {
       
    }
}
