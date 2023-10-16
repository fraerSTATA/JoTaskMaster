
using JoTaskMaster.Persistence.RelationalDB.Extensions;
using JoTaskMaster.Application;
using JoTaskMaster.Infrastructure.Services.Extenstions;
using JoTaskMaster.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAplicationLayer();
builder.Services.AddInfrasctructureLayer();
builder.Services.AddPersistanceLayer(builder.Configuration);
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddSwaggerGen(options =>{
        


});

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "private api");
});
app.Run();
