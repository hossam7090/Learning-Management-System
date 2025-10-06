using AutoMapper;
using Lms.Core.Bases;
using Lms.Core.Features.Students.Queries.Models;
using Lms.Core.Features.Students.Queries.Respones;
using Lms.Core.Features.Users.Queries.Models;
using Lms.Core.Features.Users.Queries.Responses;
using Lms.Core.Resources;
using Lms.Core.Wrappers;
using Lms.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler
                                        , IRequestHandler<GetPaginationUserQuery, PaginatedResult<GetPaginationUserResponse>>
                                        , IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {

        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public UserQueryHandler(IStringLocalizer<SharedResources> localizer,
                                    UserManager<User> userManager,
                                    IMapper mapper) : base(localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetPaginationUserResponse>> Handle(GetPaginationUserQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var PaginatedList = await _mapper.ProjectTo<GetPaginationUserResponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber,request.PageSize);
            return PaginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<GetUserByIdResponse>(_localizer[SharedResourcesKeys.notFound]);
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
    }
}
