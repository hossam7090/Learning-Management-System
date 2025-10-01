using Lms.Core.Features.Students.Queries.Respones;
using Lms.Data.Helpers;
using Lms.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery:IRequest<PaginatedResult<GetStudentWithDeptNamePagesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum? OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
