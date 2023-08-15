using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebNews.Application.AppService;
using WebNews.Application.Interface;
using WebNews.Infrastructure.IdentityContext;
using WebNews.Infrastructure.NewsContext;
using WebNews.Infrastructure.Repositories;
using WebNews.Infrastructure.Repositories.Interface;
using WebNews.Service.Interfaces;
using WebNews.Service.Services;

namespace WebNews.IoC;

public static class WebNewsRegisterDependencies
{
    public static void ConfigureDI(this IServiceCollection services)
    {
        AddAutoMapper(services);        
        AddDbContext(services);
        AddIdentity(services);
        AddInfraEstructureDependencies(services);
        AddServicesDependencies(services);
        AddApplicationDependencies(services);     
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NewsDBIdentity;Integrated Security=SSPI;Persist Security Info=False;");
        });
        services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<NewsDbContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NewsDB;Integrated Security=SSPI;Persist Security Info=False;");
        });
        services.AddScoped<NewsDbContext>();
    }

    private static void AddInfraEstructureDependencies(IServiceCollection services)
    {
        services.AddScoped<INewsRepository, NewsRepoistory>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static void AddServicesDependencies(IServiceCollection services)
    {
        services.AddScoped<INewsService, NewsService>();
    }

    private static void AddApplicationDependencies(IServiceCollection services)
    {
        services.AddScoped<INewsAppService, NewsAppService>();
    }
}