
using Microsoft.AspNetCore.Http.Features;
using WebFileManagement.Service.Services;
using WebFileManagement.StorageBroker.Services;

namespace WebFileManagement.Server
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

            builder.Services.AddScoped<IStorageService, StorageService>(); // AddScopend creates new object for every user
            builder.Services.AddSingleton<IStorageBrokerService, LocalStorageBrokerService>(); // AddSingletone creates one object for the whole period of program existence

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue; // Set to 50MB
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MinValue;
                options.MultipartBodyLengthLimit = 5242880000; // Set to 50MB
            });

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
