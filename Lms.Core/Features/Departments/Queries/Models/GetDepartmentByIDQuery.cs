using Lms.Core.Bases;
using Lms.Core.Features.Departments.Queries.Respones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIDQuery : IRequest<Response<GetDepartmentByIDResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}
