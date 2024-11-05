using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using CustomApi.Data;
using CustomApi.Models;
using CustomApi.Validators;
using CustomApi.Mappings;
using CustomApi.Services;
using CustomApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(AuthorProfile), typeof(ProductProfile));

// Register services
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Add FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>());

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:3000") // Adjust this URL if needed
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    // Add the custom schema filter
    //c.SchemaFilter<ExcludeSchemasFilter>();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //c.DocumentFilter<RemoveSchemasDocumentFilter>();
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowReactApp");

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-custom.css");  // Inject custom CSS
    });
}

//else
//{
//   app.UseHttpsRedirection(); // Ensure HTTPS redirection is used in production
//}
// Ensure the app uses static files (for the custom CSS)
app.UseStaticFiles();

// Middleware
app.UseAuthorization();
app.MapControllers();

app.Run();


