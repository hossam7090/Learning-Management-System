using Lms.Api.Base;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Features.Users.Commands.Models;
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
    }
}
