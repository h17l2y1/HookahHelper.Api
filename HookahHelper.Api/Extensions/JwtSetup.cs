using System.Text;
using HookahHelper.Api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace HookahHelper.Api.Extensions;

public static class JwtSetup
{
    public static void ConfigureServices(IServiceCollection services,ConfigurationManager configuration )
    {
        var configureSection = configuration.GetSection(JwtSettings.Key);
        var section = configureSection.Get<JwtSettings>();
        
        services.Configure<JwtSettings>(configureSection);
        services
            .AddAuthentication(AddAuthentication)
            .AddJwtBearer(options => AddJwtBearer(section, options));
    }
    
    private static void AddAuthentication(AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    
    private static void AddJwtBearer(JwtSettings? jwtSection ,JwtBearerOptions options)
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = jwtSection?.ValidAudience,
            ValidIssuer = jwtSection?.ValidIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection?.Secret))
        };
    }
}
