
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using ProductMicroService.Contexts;
using ProductMicroService.Filters;
using ProductMicroService.Interfaces;
using ProductMicroService.Models;
using ProductMicroService.Repositories;
using ProductMicroService.Services;
using System.Diagnostics.CodeAnalysis;

namespace ProductMicroService
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region context
            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region repositories
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<IProductSupplerService, ProductSupplierService>();
            builder.Services.AddScoped<IAuditLogService, AuditLogService>();

            #endregion

            #region Filters
            builder.Services.AddScoped<CustomExceptionFilter>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
