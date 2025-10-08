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
    internal class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        public EditUserValidator(UserManager<User> userManager
                                    , IStringLocalizer<SharedResources> localizer
                                    , IDepartmentService departmentService)
        {
            _localizer = localizer;
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
                    .MinimumLength(3).WithMessage(_localizer[SharedResourcesKeys.name3Size]);
            RuleFor(x => x.FullName)
                    .MinimumLength(4).WithMessage(_localizer[SharedResourcesKeys.name4Size]);
            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);

        }
        public async Task ApplyCustomValidationRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (email, cancellation) =>
                    await _userManager.FindByEmailAsync(email) == null)
                .WithMessage(_localizer[SharedResourcesKeys.emailExist]);
            RuleFor(x => x.UserName)
                .MustAsync(async (userName, cancellation) =>
                    await _userManager.FindByNameAsync(userName) == null)
                .WithMessage(_localizer[SharedResourcesKeys.userNameExist]);

        }
    }
}
