using AutoMapper;
using Bizcom.Application.Mapper;
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
        public static IServiceCollection Services(this IServiceCollection _services)
        {
            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Mapping());
            });
            IMapper mapper = mappingconfig.CreateMapper();
            _services.AddSingleton<IMapper>(mapper);

            return _services;
        }
    }
}
