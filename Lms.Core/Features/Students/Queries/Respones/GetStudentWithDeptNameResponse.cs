using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Respones
{
    public class GetStudentWithDeptNameResponse
    {
        
        public int StudID { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
        
    }
}
