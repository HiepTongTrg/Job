using AutoMapper;
using Job.Application.Mapping;
using Job.Application.Services;
using Job.Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services.AddInfrastructureModules();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ICongViecService, CongViecService>();
            services.AddScoped<INhaTuyenDungService, NhaTuyenDungService>();
            services.AddScoped<IUngViecService, UngVienService>();
            services.AddScoped<IXinViecService, XinViecService>();
            return services;
        }
    }
}
