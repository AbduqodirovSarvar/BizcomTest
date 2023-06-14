using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Mapper;
using Bizcom.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application
{
    public static class DepencyInjection
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection _services)
        {
            _services.AddScoped<ICurrentUserService, CurrentUserService>();
            _services.AddScoped<ITokenService, TokenService>();

            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Mapping());
            });

            IMapper mapper = mappingconfig.CreateMapper();
            _services.AddSingleton(mapper);
            _services.AddMediatR(typeof(DepencyInjection).Assembly);

            return _services;
        }
    }
}
