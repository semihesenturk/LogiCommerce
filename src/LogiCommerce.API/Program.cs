using LogiCommerce.Application;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.Generics;
using LogiCommerce.Infrastructure.EFCore;
using LogiCommerce.Infrastructure.EFCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Layer Registration
builder.Services.AddApplicationServices();

//Add Swagger
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

builder.Services.AddMediatR(typeof(Program).Assembly);

//Add Inmemory Db
builder.Services.AddDbContext<LogiCommerceDbContext>(options =>
    options.UseInMemoryDatabase("LogiCommerceDb"));

//DI Injections
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogiCommerce API v1");
        c.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();