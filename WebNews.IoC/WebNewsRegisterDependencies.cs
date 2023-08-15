using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    private static IConfiguration _configuration;
    public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
    {
       
        AddAutoMapper(services);        
        AddDbContext(services);
        AddIdentity(services);
        AddInfraEstructureDependencies(services);
        AddServicesDependencies(services);
        AddApplicationDependencies(services);
        Configuration(configuration);
    }

    private static void Configuration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlServer(GetConnectionStringIdentity(_configuration));
        });
        services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<NewsDbContext>(options =>
        {
            options.UseSqlServer(GetConnectionStringNews(_configuration));
        });
        services.AddScoped<NewsDbContext>();
    }

    private static string GetConnectionStringNews(IConfiguration configuration)
    {
        if (!bool.Parse(configuration["FeatureFlags:enable_connection_local_db"]!))
        {
            return configuration["ConnectionStrings:newsDB_remote"]!;
        }
        return configuration["ConnectionStrings:newsDB_local"]!;
    }

    private static string GetConnectionStringIdentity(IConfiguration configuration)
    {

        if (!bool.Parse(configuration["FeatureFlags:enable_connection_local_db"]!))
        {
            return configuration["ConnectionStrings:newsDB_remote_identity"]!;
        }
        return configuration["ConnectionStrings:newsDB_local_identity"]!;
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