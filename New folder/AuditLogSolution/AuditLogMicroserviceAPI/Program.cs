
using AuditLogMicroserviceAPI.Contexts;
using AuditLogMicroserviceAPI.Interfaces;
using AuditLogMicroserviceAPI.Models;
using AuditLogMicroserviceAPI.Repositories;
using AuditLogMicroserviceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AuditLogMicroserviceAPI
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

            #region Contexts
            builder.Services.AddDbContext<AuditContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<AuditLog, int>, AuditLogRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IAuditLogService, AutidLogService>();
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
