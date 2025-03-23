using FluentValidation.AspNetCore;
using LogiCommerce.Application;
using LogiCommerce.Application.Common.Mappings;
using LogiCommerce.Application.Product.Commands.CreateProduct;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
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

//Add MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

//Add FluentValidation
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(ProductProfile));

//Add Inmemory Db
builder.Services.AddDbContext<LogiCommerceDbContext>(options =>
    options.UseInMemoryDatabase("LogiCommerceDb"));

//DI Injections
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//Seed sample data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LogiCommerceDbContext>();
    
    context.Database.EnsureCreated(); 
    context.Seed(); 
}

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