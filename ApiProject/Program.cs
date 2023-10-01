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



            //JWT ÝÇÝN YAZILDI --- BAÞLANGIÇ
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true, //TOKEN SAÐLAYICI URL'NÝN DOÐRULANMASI
            //        ValidateAudience = true, //KÝMLÝÐÝ KULLANACAK OLAN FÝRMA ADININ DOÐRULANMASI
            //        ValidateLifetime = true, //TOKEN GEÇERLÝLÝK SÜRESÝ DOÐRULAMASI
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "http://localhost:5280", //TOKEN SAÐLAYICI URL
            //        ValidAudience = "kalemyazilim", //TOKEN KÝME VERÝLÝYOR
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benimözelkeybilgisi"))
            //    };
            //});



            builder.Services.AddEndpointsApiExplorer();

            //AÞAÐIDA SWAGGER FRONTEND DÜZENLEMESÝ ÝÇÝN DÜZENLENMÝÞ OLAN KODLAR BULUNMAKTADIR ORJÝNAL HALÝ " builder.Services.AddSwaggerGen(); " ÞEKLÝNDEDÝR.
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kalem Yazýlým Ýþe Alým Case",
                    Description = "Bu proje test amaçlý hazýrlanmýþtýr",
                    Contact = new OpenApiContact { Name = "OzanYaprak", Email = "oznyprk@gmail.com", Url = new Uri("https://github.com/OzanYaprak") },
                });
                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml")); //<summary> KISMINI KULLANABÝLMEMÝZ ÝÇÝN YAZMAMIZ GEREKEN SATIR
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