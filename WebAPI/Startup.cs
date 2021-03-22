using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
///AOP
///Autofac, Ninject, CastleWindsor, StructtureMap, LightInject, DryInject--> IoC Container
///microsoft IoC Container bunu tercih etmiyoruz! Performans sorunu nedeniyle... 
///services.AddSingleton<*>(); syntax ile tanýmlanýr...
///services.AddSingleton<ICarService, CarManager>();
///services.AddSingleton<ICarDal, EfCarDal>();
///services.AddControllers();

/// </summary>
namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //Lesson-17: added-services.AddCors();
            services.AddCors();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                }); // response headerlara neleri koyacaðýmýzý yazacaðýz.
                    //deleted: ServiceTool.Create(services);


            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()

            });

        }

        

        // this method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Middleware in ASP NET Core- yaþam döngüsü
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Lesson17:added code2: app.UseCors(builder=>builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyOrigin());
            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyOrigin());

            app.UseHttpsRedirection();

            //Lesson18: Image Gösterme Sorunu için -->  app.UseStaticFiles(); ekle.
            //The default web app templates call the UseStaticFiles method in Startup.Configure
            //The parameterless UseStaticFiles method overload marks the files in web root as servable. The following markup references wwwroot/images/MyImage.jpg:
            app.UseStaticFiles();

            app.UseRouting();

            //Token Almak için- kullaným yetkilendirmesi kulllan...
            app.UseAuthorization();

            //finally- authentication token almak için- kimlik doðrulamasý kullan...
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

