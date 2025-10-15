using Lms.Api.Base;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Features.Students.Queries.Models;
using Lms.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {
        public StudentController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediatR.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery]GetStudentPaginatedListQuery query)
        {
            var response = await _mediatR.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var response = await _mediatR.Send(new GetStudentByIDQuery(Id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]

        public async Task<IActionResult> Create([FromBody] AddStudentCommand command )
        {
            var response = await _mediatR.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await _mediatR.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _mediatR.Send(new DeleteStudentCommand(Id));
            return NewResult(response);
        }

    }
}
