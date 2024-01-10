namespace HookahHelper.Api.Extensions;

public class CorsExtension
{
    public static void Add(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Angular",
                b => b.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }
}