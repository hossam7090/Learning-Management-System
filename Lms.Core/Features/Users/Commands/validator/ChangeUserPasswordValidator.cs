using FluentValidation;
using Lms.Core.Features.Users.Commands.Models;
using Lms.Core.Resources;
using Lms.Data.Entities.Identity;
using Lms.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Users.Commands.validator
{
    internal class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        public ChangeUserPasswordValidator(UserManager<User> userManager
                                    , IStringLocalizer<SharedResources> localizer
                                    , IDepartmentService departmentService)
        {
            _localizer = localizer;
            _userManager = userManager;
            ApplyValidationRules();

        }

        public void ApplyValidationRules()
        {
            
            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);
                    
            RuleFor(x => x.NewPassword)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);
            RuleFor(x => x.CurrentPassword)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);
            RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.NewPassword).WithMessage(_localizer[SharedResourcesKeys.passwordMustMatch])
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);

        }
    }
    
}
