using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TestApi.Api.Infrastructure.JWT;
using TestApi.Api.Utilities;
using TestApi.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddApiVersioning(option =>
{
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(option =>
{
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;
});

var connectionString = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.RegisterDependency(connectionString);

builder.Services.AddJwtAuthentication(builder.Configuration);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(option =>
{
    var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

    foreach (var item in service.ApiVersionDescriptions)
    {
        option.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName.ToString());
    }
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
