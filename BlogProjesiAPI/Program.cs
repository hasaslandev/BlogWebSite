using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependecyResolvers.Autofac;
using CoreL.DataAccess;
using CoreL.DataAccess.EntityFramework;
using CoreL.UnitOfWorks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
