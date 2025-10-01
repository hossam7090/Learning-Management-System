using Lms.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        [Required]
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? DepartmentId { get; set; }
    }
}
