using HealthcareManagement.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using HealthcareManagement.Models;
using Microsoft.EntityFrameworkCore;





namespace HealthcareManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthcareManagement v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();
        
           

   
            

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IBillingRepository, BillingRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IViewRepository, ViewRepository>();
            services.AddScoped<IMySessionRepository, MySessionRepository>();
            





            services.AddControllers();
            services.AddSwaggerGen();

           
           

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
        }
    }

    internal class UserRepository
    {
    }

    internal interface IMySessionsRepository
    {
    }
}
