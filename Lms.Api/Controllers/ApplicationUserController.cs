using Lms.Api.Base;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Features.Students.Queries.Models;
using Lms.Core.Features.Users.Commands.Models;
using Lms.Core.Features.Users.Queries.Models;
using Lms.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Api.Controllers
{

    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        public ApplicationUserController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediatR.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetPaginationUserQuery query)
        {
            var response = await _mediatR.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetStudentById(Guid Id)
        {
            var response = await _mediatR.Send(new GetUserByIdQuery(Id));
            return NewResult(response);
        }
    }
}
