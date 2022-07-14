﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestApi.Query.Users.DTOs;

namespace TestApi.Api.Infrastructure.JWT;
public class JWTTokenBuilder
{
    public static string BuildToken(UserDTO user, IConfiguration configuration)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]));
        var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["JwtConfig:Issuer"],
            audience: configuration["JwtConfig:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credential);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}