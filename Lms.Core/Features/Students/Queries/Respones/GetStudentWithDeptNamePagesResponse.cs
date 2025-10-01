using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Features.Students.Queries.Respones
{
    public class GetStudentWithDeptNamePagesResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
        public GetStudentWithDeptNamePagesResponse(int studID, string name, string? address, string? departmentName)
        {
            StudID = studID;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }
    }
}
