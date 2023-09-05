using HookahHelper.Api.Extensions;
using HookahHelper.Api.Middleware;
using HookahHelper.BLL.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
CorsExtension.Add(builder.Services);
JwtSetup.ConfigureServices(builder.Services, builder.Configuration);

builder.Services.InjectBusinessLogicDependency(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Angular");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();