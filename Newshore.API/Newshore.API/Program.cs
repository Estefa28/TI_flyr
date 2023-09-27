using Newshore.API.Extensions;
using Newshore.Business.Interfaces;
using Newshore.Business.Managers;
using Newshore.DataAccess.API;
using Newshore.DataAccess.Interfaces;
using Newshore.EF.Interfaces;
using Newshore.EF.Repositories;

namespace Newshore.API
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
            builder.Services.ConfigureEF(builder.Configuration);

            builder.Services.AddTransient<ISearchRegistryRepository, SearchRegistryRepository>();
            builder.Services.AddTransient<INewshoreAPI, NewshoreAPI>();
            builder.Services.AddTransient<IFlightManager, FlightManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}