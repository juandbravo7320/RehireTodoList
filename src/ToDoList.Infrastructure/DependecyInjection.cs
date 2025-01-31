using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Application.Abstractions.Authorization;
using ToDoList.Application.Abstractions.Data;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;
using ToDoList.Infrastructure.Authentication;
using ToDoList.Infrastructure.Authorization;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repository;

namespace ToDoList.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        
        AddPersistence(services, configuration);
        AddAuthentication(services, configuration);
        AddAuthorization(services);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        Env.Load();
        
        var authenticationSettings = configuration.GetSection("Authentication").Get<AuthenticationOptions>() ??
                                     throw new ApplicationException("authentication settings are unavailable");
        
        authenticationSettings.Secret = Env.GetString("JWT_SECRET") ?? 
                                        throw new ApplicationException("jwt secret is unavailable");
        
        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authenticationSettings.Issuer,
                ValidAudience = authenticationSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.Secret))
            };
        });
        
        services.AddHttpContextAccessor();
        
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    private static void AddAuthorization(IServiceCollection services)
    {
        services.AddScoped<IPermissionService, PermissionService>();
    }
}