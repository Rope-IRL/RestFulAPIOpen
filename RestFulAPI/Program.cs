
using Microsoft.EntityFrameworkCore;
using RestFulAPI.Services;

namespace RestFulAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var CorsName = "AllowFrontOrigin";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CorsName,
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1:8000")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                    );
            });
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddMemoryCache();


            builder.Services.AddDbContext<RealestaterentalContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<FlatsContractService>();
            builder.Services.AddScoped<FlatsService>();
            builder.Services.AddScoped<HotelService>();
            builder.Services.AddScoped<HotelsRoomsService>();
            builder.Services.AddScoped<RoomsContractService>();
            builder.Services.AddScoped<HouseService>();
            builder.Services.AddScoped<HouseContractService>();
            builder.Services.AddScoped<LesseeService>();
            builder.Services.AddScoped<LesseeAdditionalInfoService>();
            builder.Services.AddScoped<LandLordService>();
            builder.Services.AddScoped<LandLordsAdditionalInfoService>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.MapType<DateOnly>(() => new Microsoft.OpenApi.Models.OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
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

            app.UseCors(CorsName);
            app.MapControllers();

            app.Run();
        }
    }
}
