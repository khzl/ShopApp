using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application;
using Shop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add Layers from different projects 
// Add Modular 
builder.Services.AddDataLayer(builder.Configuration); // Add DataStartup.cs
builder.Services.AddBusinessLayer(); // Add BusinessStartup.cs


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 1. تعريف السياسة
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// 2. تفعيل السياسة (يجب أن تكون قبل UseAuthorization)
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
// Enable Swagger/OpenAPI for testing (available in browser at /swagger)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.Api v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
