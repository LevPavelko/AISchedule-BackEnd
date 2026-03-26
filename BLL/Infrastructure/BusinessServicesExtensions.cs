using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AIScheduleUI5.BLL.Infrastructure;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUniversityService, UniversityService>();
        services.AddScoped<IMajorService, MajorService>();
        services.AddScoped<IStudyDataService, StudyDataService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ISecureService, SecureService>();

        return services;
    }
}

