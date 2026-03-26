using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIScheduleUI5.DAL.Interfaces;
using AIScheduleUI5.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AIScheduleUI5.BLL.Infrastructure
{
    public static class UnitOfWorkServiceExtensions
    {
        public static void AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
