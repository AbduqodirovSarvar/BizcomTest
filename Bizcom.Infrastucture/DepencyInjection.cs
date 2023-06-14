using Bizcom.Application.Abstractions;
using Bizcom.Infrastucture.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Infrastucture
{
    public static class DepencyInjection
    {
        public static IServiceCollection InfrastructureServices (this IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddDbContext<AppDbContext>(options
                => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            _services.AddScoped<IAppDbContext, AppDbContext>();

            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false
                    };
                });

            _services.AddAuthorization(option =>
            {
                option.AddPolicy("TeacherActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Teacher");
                });

                option.AddPolicy("StudentActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Student");
                });
            });

            return _services;
        }
    }
}
