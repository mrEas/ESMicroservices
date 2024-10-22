using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using OrderService.Modules.Common;
using OrderService.Modules.Orders.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var IsProduction = builder.Environment.IsProduction();
IsProduction = false;
builder.Services.RegisterModules(builder.Configuration, IsProduction);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Order service API", Version = "v1" });
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30);
});

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseOutputCache();
app.SeedData(IsProduction);
app.MapEndpoints();

app.Run();
