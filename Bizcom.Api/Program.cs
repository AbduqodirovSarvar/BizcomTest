using Bizcom.Application;
using Bizcom.Infrastucture;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.ApplicationServices();
builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Bizcom",
        Description = "Bizcom Test Task"
    });

    options.AddSecurityDefinition("Beareer", new OpenApiSecurityScheme()
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Authorization",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Id = "Beareer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }

    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Bizcom API");
    });
} 

app.UseHttpsRedirection();
app.UseAuthentication();

// Add CORS configuration
app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    // or configure specific origins, methods, and headers
});


app.UseAuthorization();

app.MapControllers();

app.Run();
