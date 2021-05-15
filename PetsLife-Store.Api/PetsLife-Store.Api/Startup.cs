using AccessData;
using AccessData.Commands;
using AccessData.Commands.Repository;
using AccessData.Queries;
using AccessData.Validation;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

namespace PetsLife_Store.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConn = Configuration.GetConnectionString("SQLConnection");

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(sqlConn));

            services.AddControllers().AddFluentValidation();

            // SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(sqlConn);
            });

            services.AddTransient<IProductoQuery, ProductoQuery>();
            services.AddTransient<ICarritoQuery, CarritoQuery>();

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ICarritoService, CarritoService>();


            // Fluent Validator services
            services.AddTransient<IValidator<Carrito>, CarritoValidator>();
            services.AddTransient<IValidator<Comprador>, CompradorValidator>();
            services.AddTransient<IValidator<Producto>, ProductoValidator>();
            services.AddTransient<IValidator<ProductoPedido>, ProductoPedidoValidator>();
            services.AddTransient<IValidator<AddProductoDTO>, ProductoDtoValidator>();
            services.AddTransient<IValidator<AddProductoPedidoDTO>, ProductoPedidoDtoValidator>();

            services.AddSwaggerGen();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetsLife Store API");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
