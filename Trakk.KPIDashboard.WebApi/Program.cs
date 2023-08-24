using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Trakk.Configuration;
using Trakk.KPIDashboard.WebApi.Services;
using Trakk.Minimal.Api.Extensions;
using Trakk.WebApi.DatabaseModels.Models;



ConfigManager.Setup(ProjectConfig.Api);
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabases(builder.Configuration);

builder.Services.AddScoped<KPIDashboardService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Trakk KPI api", Version = "v1" });

});



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        b =>
        {
            b.AllowAnyOrigin();
            b.AllowAnyHeader();
            b.AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.MapControllers();

app.Run();