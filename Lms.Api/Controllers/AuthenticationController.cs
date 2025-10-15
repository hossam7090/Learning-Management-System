using Lms.Api.Base;
using Lms.Core.Features.Authentication.Commands.Models;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        public AuthenticationController(IMediator mediatR) : base(mediatR)
        {
        }
        [HttpPost(Router.Authentication.SignIn)]

        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await _mediatR.Send(command);
            return NewResult(response);
        }
    }
}
