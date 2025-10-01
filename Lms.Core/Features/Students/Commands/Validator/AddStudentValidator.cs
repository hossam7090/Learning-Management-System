using FluentValidation;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Resources;
using Lms.Services.Abstracts;
using Lms.Services.implementations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Commands.Validator
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public AddStudentValidator(IStudentService studentService
                                    , IStringLocalizer<SharedResources> localizer
                                    , IDepartmentService departmentService) 
        {
            _localizer = localizer;
            _studentService = studentService;
            _departmentService = departmentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name " + _localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage("Name " + _localizer[SharedResourcesKeys.nameRequired])
                    .MinimumLength(3).WithMessage("Name " + _localizer[SharedResourcesKeys.name3Size]);
            RuleFor(x => x.Address)
                    .NotEmpty().WithMessage("Address " + _localizer[SharedResourcesKeys.nameRequired])
                    .NotNull().WithMessage("Address " + _localizer[SharedResourcesKeys.nameRequired])
                    .MinimumLength(4).WithMessage("Address " + _localizer[SharedResourcesKeys.name4Size]);

        }
        public async Task ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.nameExist]);

            RuleFor(x => x.DepartmementId)
           .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExist(key))
           .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }

    }
}
