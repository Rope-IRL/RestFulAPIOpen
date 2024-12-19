using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Application.Services;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using RestFulAPI.DataAccess;
using RestFulAPI.DataAccess.Repositories;
using RestFulAPI.Helpers;


namespace RestFulAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var corsName = "AllowFrontOrigin";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsName,
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1:8000")
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader();

                    }
                    );
            });
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<RentDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddScoped<IFlat, FlatRepository>();
            builder.Services.AddScoped<IFlatContract, FlatContractRepository>();
            builder.Services.AddScoped<IHotel, HotelRepository>();
            builder.Services.AddScoped<IHouse, HouseRepository>();
            builder.Services.AddScoped<IRoom, RoomRepository>();
            builder.Services.AddScoped<IRoomContract, RoomContractRepository>();
            builder.Services.AddScoped<IHouseContract, HouseContractRepository>();
            builder.Services.AddScoped<ILessee, LesseeRepository>();
            builder.Services.AddScoped<ILesseeAdditionalInfo, LesseeAdditionalInfoRepository>();
            builder.Services.AddScoped<ILandlord, LandlordRepository>();
            builder.Services.AddScoped<ILandlordAdditionalInfo, LandlordAdditionalInfoRepository>();
            builder.Services.AddScoped<IFlatImage, FlatImageRepository>();
            builder.Services.AddScoped<IHouseImage, HouseImageRepository>();
            builder.Services.AddScoped<IRoomImage, RoomImageRepository>();

            builder.Services.AddScoped<IFlatService, FlatService>();
            builder.Services.AddScoped<IFlatContractService, FlatContractService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IHouseService, HouseService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IRoomContractService, RoomContractService>();
            builder.Services.AddScoped<IHouseContractService, HouseContractService>();
            builder.Services.AddScoped<ILesseeService, LesseeService>();
            builder.Services.AddScoped<ILesseeAdditionalInfoService, LesseeAdditionalInfoService>();
            builder.Services.AddScoped<ILandlordService, LandlordService>();
            builder.Services.AddScoped<ILandlordAdditionalInfoService, LandlordAdditionalInfoService>();
            builder.Services.AddScoped<IFlatImageService, FlatImageService>();
            builder.Services.AddScoped<IHouseImageService, HouseImageService>();
            builder.Services.AddScoped<IRoomImageService, RoomImageService>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Authenticate.ISSUER,
                        ValidAudience = Authenticate.AUDIENCE,
                        IssuerSigningKey = Authenticate.GetSymmetricKey(),
                    };
                });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthorization();
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

            // app.UseCookiePolicy(new CookiePolicyOptions()
            // {
            //     MinimumSameSitePolicy = SameSiteMode.Strict,
            //     MinimumSameSitePolicy = SameSiteMode.Strict,
            //     HttpOnly = HttpOnlyPolicy.Always,
            //     Secure = CookieSecurePolicy.Always
            // });
            
            app.UseCheckIfAuth();
            app.UseRouting();
            
            // app.UseHttpsRedirection();
            app.UseCors(corsName);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
