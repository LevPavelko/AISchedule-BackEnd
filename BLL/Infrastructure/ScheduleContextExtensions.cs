using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIScheduleUI5.DAL.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.BLL.Infrastructure
{
    public static class ScheduleContextExtensions
    {
        public static void AddAIScheduleUI5Context(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ScheduleContext>(options => options.UseLazyLoadingProxies().UseMySql(connection, ServerVersion.AutoDetect(connection)));
        }
    }
}
