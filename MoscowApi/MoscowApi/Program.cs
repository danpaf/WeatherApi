using Microsoft.OpenApi.Models;
using MoscowApi.Database;
using MoscowApi.Handlers;
using MoscowApi.Logic;
using MoscowApi.Options;
using MoscowApi.Services;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ApplicationContext>();
builder.Services.AddScoped<WeatherApiLogic>();
builder.Services.AddScoped<WeatherLogic>();
builder.Services.AddScoped<UserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "WeatherApi", Version = "v1"});
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authentication"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "basic"}
            },
            new string[] { }
        }
    });
});
builder.Services.AddOptions<BasicAuthenticationOptions>();
builder.Services.AddLogging();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<BasicAuthenticationOptions, BasicAuthHandler>("BasicAuthentication", options =>
    {
        options.Realm = "Realm";
        options.UnauthorizedMessage = "Unauthorized";
    });

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
    c.DocExpansion(DocExpansion.None);
    c.DefaultModelRendering(ModelRendering.Model);
    c.DisplayRequestDuration();
    c.EnableFilter();
});


app.MapControllers();

app.Run();