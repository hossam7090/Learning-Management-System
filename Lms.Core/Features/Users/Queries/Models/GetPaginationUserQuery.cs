using Lms.Core.Features.Users.Queries.Responses;
using Lms.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Queries.Models
{
    public class GetPaginationUserQuery: IRequest<PaginatedResult<GetPaginationUserResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
