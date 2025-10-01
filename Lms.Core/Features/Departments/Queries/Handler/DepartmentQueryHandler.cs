using AutoMapper;
using Lms.Core.Bases;
using Lms.Core.Features.Departments.Queries.Models;
using Lms.Core.Features.Departments.Queries.Respones;
using Lms.Core.Features.Students.Queries.Respones;
using Lms.Core.Resources;
using Lms.Core.Wrappers;
using Lms.Data.Entities;
using Lms.Services.Abstracts;
using Lms.Services.implementations;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Departments.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler
                                         ,IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IStudentService _studentService;
        #endregion
        #region Constractor
        public DepartmentQueryHandler(IStudentService studentService
                                    , IMapper mapper
                                    , IStringLocalizer<SharedResources> localizer
                                    , IDepartmentService departmentService) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _departmentService = departmentService;
            _studentService = studentService;
        }

        public async Task<Response<GetDepartmentByIDResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            //service Get By Id include St sub ins
            var response = await _departmentService.GetDepartmentById(request.Id);
            //check Is Not exist
            if (response == null) return NotFound<GetDepartmentByIDResponse>(_localizer[SharedResourcesKeys.notFound]);
            //mapping 
            var mapper = _mapper.Map<GetDepartmentByIDResponse>(response);

            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.localize(e.NameAr, e.Name));
            var studentQuerable = _studentService.GetStudentsByDepartmentIDQuerable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaginatedList;

            // Log.Information($"Get Department By Id {request.Id}!");
            //return response
            return Success(mapper);
        }
        #endregion

    }
}
