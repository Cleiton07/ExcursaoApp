using ExcursaoApp.Api.Authentication.Configuration;
using ExcursaoApp.Api.Authentication.Service;
using ExcursaoApp.Api.ViewModels;
using ExcursaoApp.Application.Abstractions.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace ExcursaoApp.Api.Authentication;

public static class AuthenticationBootstrapper
{
    public static IServiceCollection AddApiAuthentication(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<IAuthenticationConfig, AuthenticationConfig>();
        services.AddScoped<IAuthenticationProvider, AuthenticationProvider>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        using var serciceProvider = services.BuildServiceProvider();
        var authConfig = serciceProvider.GetRequiredService<IAuthenticationConfig>();
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authConfig.EncryptKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            x.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.Response.OnStarting(async () =>
                    {
                        var response = new ViewModel(null);
                        response.AddError("Sem permissão para acessar essa rota");

                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsJsonAsync(response);
                    });

                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }

    public static IApplicationBuilder StartAuthentication(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}