using System.Text;
using HookahHelper.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace HookahHelper.Api.Extensions;

public static class JwtSetup
{
    public static void ConfigureServices(IServiceCollection services,ConfigurationManager configuration )
    {
        var configureSection = configuration.GetSection(JwtSettings.Key);
        // GetSection(JwtSettings.Key)
        var section = configuration.Get<JwtSettings>();
        services.Configure<JwtSettings>(configureSection);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = section?.ValidIssuer,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section?.Secret)),
                };
            });
    }
}
