using Job.Domain.Entities;
using Job.Domain.Repositories;
using Job.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Infrastructure.Modules
{
    public static class InfrastructureModules
    {
        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            services.AddScoped<ICongViecRepo, CongViecRepo>();
            services.AddScoped<INhaTuyenDungRepo, NhaTuyenDungRepo>();
            services.AddScoped<IUngVienRepo, UngVienRepo>();
            services.AddScoped<IXinViecRepo, XinViecRepo>();
            return services;
        }
    }
}
