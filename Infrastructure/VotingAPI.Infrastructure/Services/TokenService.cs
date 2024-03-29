﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Exceptions;
//using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        //private readonly UserManager<AppUser> _userManager;


        public TokenService(IConfiguration configuration /*UserManager<AppUser> userManager*/)
        {
            //_userManager = userManager;
            _configuration = configuration;
        }

        public TokenResponse CreateAccessToken(int minute, List<Claim> claims = null)
        {
            TokenResponse tokenResponse = new TokenResponse();

            if (claims == null)
            {
                claims = new List<Claim>();
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenResponse.ExpirationDate = DateTime.UtcNow.AddMinutes(minute);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: claims,
                expires: tokenResponse.ExpirationDate,
                signingCredentials: signingCredentials,
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                notBefore: DateTime.UtcNow
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenResponse.AccessToken = tokenHandler.WriteToken(securityToken);

            tokenResponse.RefreshToken = CreateRefreshToken();

            return tokenResponse;
        }


        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        //public async Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken)
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(x )
        //}

        //public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute)
        //{
        //    if (user != null)
        //    {
        //        user.RefreshToken = refreshToken;
        //        user.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTimeMinute);
        //        await _userManager.UpdateAsync(user);
        //    }
        //    else
        //        throw new UserNotFoundException(user.UserName);
        //}
    }
}