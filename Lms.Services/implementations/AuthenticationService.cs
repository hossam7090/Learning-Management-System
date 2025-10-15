using Lms.Data.Entities.Identity;
using Lms.Data.Helpers;
using Lms.Infrastructure.Repositories.Abstracts;
using Lms.Services.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Services.implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Feilds
        private readonly JwtSettings _jwtSettings;
        private readonly ConcurrentDictionary<string,RefreshToken> _userRefreshToken;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        #endregion

        #region Constractors
        public AuthenticationService(JwtSettings jwtSettings,
                                     IRefreshTokenRepository refreshTokenRepository)
        {
            _jwtSettings = jwtSettings;
            _userRefreshToken = new ConcurrentDictionary<string,RefreshToken>();
            _refreshTokenRepository = refreshTokenRepository;
        }
        #endregion

        #region Handle Functions
        public async Task<JwtAuthResult> GenerateJwtToken(User user)
        {
            var (jwtToken, accessToken) = await GenerateJWTToken(user);
            var refreshToken = GetRefreshToken(user.UserName);

            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = accessToken,
                UserId = user.Id
            };
            await _refreshTokenRepository.AddAsync(userRefreshToken);
            return new JwtAuthResult
            {
                AccessToken = accessToken,
                refreshToken = refreshToken
            };
        }
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString(); // Simple Guid as refresh token
        }
        public async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimsModel.Id), user.Id),
                new Claim(nameof(UserClaimsModel.UserName), user.UserName),
                new Claim(nameof(UserClaimsModel.Email), user.Email),
            };
            return claims;
        }
        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };
            _userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);
            return refreshToken;
        }
        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
        #endregion
    }
}
