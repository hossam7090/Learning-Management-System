using AutoMapper;
using Lms.Core.Bases;
using Lms.Core.Features.Students.Queries.Models;
using Lms.Core.Features.Students.Queries.Respones;
using Lms.Core.Resources;
using Lms.Core.Wrappers;
using Lms.Data.Entities;
using Lms.Infrastructure.Repositories.Abstracts;
using Lms.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Handler
{
    public class StudentQueryHandler :ResponseHandler
                                     ,IRequestHandler<GetStudentListQuery, Response<List<GetStudentWithDeptNameResponse>>>
                                     ,IRequestHandler<GetStudentByIDQuery, Response<GetStudentWithDeptNameResponse>>
                                     ,IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentWithDeptNamePagesResponse>>
    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion


        #region Constractor
        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer):base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion


        #region Handle Functions
        public async Task<Response<List<GetStudentWithDeptNameResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentWithDeptNameResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new {Count = studentList.Count()};
            return result;
        }

        public async Task<Response<GetStudentWithDeptNameResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdIncludeDeptAsync(request.Id);
            if (student == null) return NotFound<GetStudentWithDeptNameResponse>(_localizer[SharedResourcesKeys.notFound]);
            var result = _mapper.Map<GetStudentWithDeptNameResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentWithDeptNamePagesResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentWithDeptNamePagesResponse>> expression = e => new GetStudentWithDeptNamePagesResponse(e.StudID, e.localize(e.NameAr,e.Name), e.Address, e.Department.localize(e.Department.DNameAr, e.Department.DNameEn)) ;
            var querable = _studentService.GetStudentQuerable(request.Search , request.OrderBy);
            var PaginatedList = await querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = PaginatedList.Data.Count();
            return PaginatedList;
        }
        #endregion
    }
}
