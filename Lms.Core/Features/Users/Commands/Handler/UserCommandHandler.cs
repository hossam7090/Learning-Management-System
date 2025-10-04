using AutoMapper;
using Lms.Core.Bases;
using Lms.Core.Features.Users.Commands.Models;
using Lms.Core.Resources;
using Lms.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler
                                       , IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public UserCommandHandler(IStringLocalizer<SharedResources> localizer,
                                    UserManager<User> userManager,
                                    IMapper mapper) : base(localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            var createdUser = await _userManager.CreateAsync(identityUser,request.Password);
            if (!createdUser.Succeeded) return BadRequest<string>(createdUser.Errors.FirstOrDefault().Description);
            return Created("");

        }
    }
}
