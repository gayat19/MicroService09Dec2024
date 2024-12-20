
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductMicroService.Contexts;
using ProductMicroService.Filters;
using ProductMicroService.Interfaces;
using ProductMicroService.Models;
using ProductMicroService.Repositories;
using ProductMicroService.Services;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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

            #region AuthenticationFilter
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Keys:TokenKey"] ?? "")),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
            #endregion

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
