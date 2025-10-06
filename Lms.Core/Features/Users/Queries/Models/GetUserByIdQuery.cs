using Lms.Core.Bases;
using Lms.Core.Features.Users.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery :IRequest<Response<GetUserByIdResponse>>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
