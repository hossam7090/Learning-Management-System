using FluentValidation;
using Lms.Core.Features.Authentication.Commands.Models;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Resources;
using Lms.Services.Abstracts;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Authentication.Commands.Validator
{
    internal class SignInValidator : AbstractValidator<SignInCommand>
    {

        private readonly IStringLocalizer<SharedResources> _localizer;
        public SignInValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage( _localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);
            RuleFor(x => x.Password)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.nameRequired]);

        }
        public async Task ApplyCustomValidationRules()
        {
            
        }

    }
}