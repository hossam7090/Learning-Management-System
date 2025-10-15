using Lms.Core.Bases;
using Lms.Core.Features.Authentication.Commands.Models;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Resources;
using Lms.Data.Entities.Identity;
using Lms.Data.Helpers;
using Lms.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler
                                       , IRequestHandler<SignInCommand, Response<JwtAuthResult>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> localizer,
                                            UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationService authenticationService) : base(localizer)
        {
            _localizer = localizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }

        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return BadRequest<JwtAuthResult>(_localizer[SharedResourcesKeys.UserNameOrPasswordFail]);
            var signInResult =  _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if(!signInResult.IsCompletedSuccessfully) return BadRequest<JwtAuthResult>(_localizer[SharedResourcesKeys.UserNameOrPasswordFail]);
            var accessToken =await _authenticationService.GenerateJwtToken(user);
            return Success(accessToken);

        }
    }
}
