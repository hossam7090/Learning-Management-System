using AutoMapper;
using Lms.Core.Bases;
using Lms.Core.Features.Students.Commands.Models;
using Lms.Core.Resources;
using Lms.Data.Entities;
using Lms.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler
                                       , IRequestHandler<AddStudentCommand, Response<string>>
                                       , IRequestHandler<EditStudentCommand, Response<string>>
                                       , IRequestHandler<DeleteStudentCommand, Response<string>>
    {


        #region fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region constractor
        public StudentCommandHandler(IStudentService studentService,IMapper mapper, IStringLocalizer<SharedResources> localizer) :base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);
            
            if (result == "Success") return Created<string>("Added Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentService.GetStudentsByIDAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //mapping Between request and student
            var studentmapper = _mapper.Map(request, student);
            //Call service that make Edit
            var result = await _studentService.EditAsync(studentmapper);
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Success]);
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIDAsync(request.Id);
            if (student == null) return NotFound<string>();
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>($"Deleted Successfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion



    }
}
