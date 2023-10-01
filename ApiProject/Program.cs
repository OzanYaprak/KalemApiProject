using BusinessLayer.Repositories;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            builder.Services.AddDbContext<ApiProjectDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));



            //JWT ���N YAZILDI --- BA�LANGI�
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true, //TOKEN SA�LAYICI URL'N�N DO�RULANMASI
            //        ValidateAudience = true, //K�ML��� KULLANACAK OLAN F�RMA ADININ DO�RULANMASI
            //        ValidateLifetime = true, //TOKEN GE�ERL�L�K S�RES� DO�RULAMASI
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "http://localhost:5280", //TOKEN SA�LAYICI URL
            //        ValidAudience = "kalemyazilim", //TOKEN K�ME VER�L�YOR
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benim�zelkeybilgisi"))
            //    };
            //});



            builder.Services.AddEndpointsApiExplorer();

            //A�A�IDA SWAGGER FRONTEND D�ZENLEMES� ���N D�ZENLENM�� OLAN KODLAR BULUNMAKTADIR ORJ�NAL HAL� " builder.Services.AddSwaggerGen(); " �EKL�NDED�R.
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kalem Yaz�l�m ��e Al�m Case",
                    Description = "Bu proje test ama�l� haz�rlanm��t�r",
                    Contact = new OpenApiContact { Name = "OzanYaprak", Email = "oznyprk@gmail.com", Url = new Uri("https://github.com/OzanYaprak") },
                });
                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml")); //<summary> KISMINI KULLANAB�LMEM�Z ���N YAZMAMIZ GEREKEN SATIR
            });


            //CUSTOM
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("KalemApiCors", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //CUSTOM
            app.UseRouting();
            //CUSTOM
            app.UseCors("KalemApiCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}