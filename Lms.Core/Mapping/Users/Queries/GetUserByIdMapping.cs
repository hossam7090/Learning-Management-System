using Lms.Core.Features.Users.Queries.Responses;
using Lms.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping() 
        { 
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
