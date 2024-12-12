
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Contexts;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Repositories;
using ShoppingAPI.Services;

namespace ShoppingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ShoppingContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddScoped<IRepository<Product, int>, ProductRepository>();//Injected the Repository
            builder.Services.AddScoped<IRepository<Product, int>, ProductRepositoryV2>();//Injected the Repository
            builder.Services.AddScoped<IRepository<AuditLog, int>, AuditLogRepository>();//Injected the Repository

            builder.Services.AddScoped<IProductGeneralService, ProductCustomerService>();//Injected the Service
            builder.Services.AddScoped<IProductSupplierService, ProductSupplierService>();
            //builder.Services.AddScoped<IAuditLogService, AuditLogService>();
            builder.Services.AddScoped<IAuditLogService, AutidLogServiceV2>();

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
