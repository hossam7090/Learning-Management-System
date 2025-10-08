using Lms.Core.Bases;
using Lms.Core.Features.Users.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
