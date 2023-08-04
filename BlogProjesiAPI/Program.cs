using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependecyResolvers.Autofac;
using CoreL.DataAccess;
using CoreL.DataAccess.EntityFramework;
using CoreL.DependencyResolvers;
using CoreL.Extensions;
using CoreL.UnitOfWorks;
using CoreL.Utilities.IoC;
using CoreL.Utilities.Security.Encyrption;
using CoreL.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;




namespace BlogProjesiAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                });
            builder.Services.AddDependencyResolvers(new ICoreModule[] //ister array yap ister params yap ister koleksiyon olaray yap
            {
                new CoreModule()
            });

            










            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddScoped<IUnitOfWorks, IUnitOfWorks>();
            //builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            //builder.Services.AddDbContext<LocalContext>(x =>
            //{
            //    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
            //    {
            //        option.MigrationsAssembly(Assembly.GetAssembly(typeof(LocalContext)).GetName().Name);
            //    });



            //});

            //Autofac kullandýk
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(options => 
            {

                options.RegisterModule(new AutofacBusinessModule());
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
