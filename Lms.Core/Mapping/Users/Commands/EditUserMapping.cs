using Lms.Core.Features.Users.Commands.Models;
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
        public void EditUserMapping() 
        {
            CreateMap<EditUserCommand, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
