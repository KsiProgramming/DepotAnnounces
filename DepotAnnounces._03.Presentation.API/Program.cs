using DepotAnnounces._01.Data;
using DepotAnnounces._02.Application.Models.APIAddresseGouv;
using DepotAnnounces._02.Application.Repositories;
using DepotAnnounces._02.Application.Services.GouvAPIAddress;
using DepotAnnounces._02.Application.Services.Interfaces;
using DepotAnnounces._02.Application.Services.OpenMeteo;
using DepotAnnounces._02.Application.Services.SeLogerAddress;
using Microsoft.EntityFrameworkCore;
namespace DepotAnnounces._03.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AnnouncesContext>(Options =>
            {                
                Options.UseInMemoryDatabase("AnnouncesContext");
            });
            builder.Services.AddHttpClient<IOpenMeteoService, OpenMeteoService>();
            builder.Services.AddHttpClient<IAddressDataService, GouvAPIAddressService>();
            builder.Services.AddScoped<IAnnouncesRepository, AnnouncesRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                using var scope = app.Services.CreateScope();
                AnnouncesContext context = scope.ServiceProvider.GetRequiredService<AnnouncesContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}