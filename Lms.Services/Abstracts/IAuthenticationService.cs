using Lms.Data.Entities.Identity;
using Lms.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Services.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GenerateJwtToken(User user);
        public Task<JwtAuthResult> GetRefreshToken(string accessToken, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
    } 
}
