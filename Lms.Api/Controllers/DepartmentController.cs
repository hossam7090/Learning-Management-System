using Lms.Api.Base;
using Lms.Core.Features.Departments.Queries.Models;
using Lms.Core.Features.Students.Queries.Models;
using Lms.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Api.Controllers
{
    
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        public DepartmentController(IMediator mediatR) : base(mediatR)
        {
        }
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIDQuery query )
        {
            var response = await _mediatR.Send(query);
            return NewResult(response);
        }
    }
}
