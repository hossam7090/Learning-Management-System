using Lms.Core.Bases;
using Lms.Core.Features.Students.Queries.Respones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Models
{
    public class GetStudentByIDQuery : IRequest<Response<GetStudentWithDeptNameResponse>>
    {
        public int Id { get; set; }

        public GetStudentByIDQuery(int id)
        {
            Id = id;
        }
    }
}
