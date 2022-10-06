using University.ApplicationCore.Interfaces.Services;
using University.Services;

namespace University.Web.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICoursesService, CoursesService>();
        services.AddScoped<IGroupsService, GroupsService>();
        services.AddScoped<IStudentsService, StudentsService>();

        return services;
    }
}
