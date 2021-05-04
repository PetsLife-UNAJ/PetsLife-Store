using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AccessData;
using FluentValidation.AspNetCore;
using FluentValidation;
using Domain.Entities;
using AccessData.Validation;
using AccessData.Commands.Repository;
using AccessData.Commands;
using Application.Services;
using Domain.Interfaces;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;
using Domain.Interfaces.Queries;
using AccessData.Queries;

namespace PetsLife_Store.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConn = Configuration.GetConnectionString("SQLConnection");

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(sqlConn));

            services.AddControllers().AddFluentValidation();
            //SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(sqlConn);
            });

            services.AddTransient<IProductoQuery, ProductoQuery>();

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ICarritoService, CarritoService>();

            services.AddSwaggerGen();

            services.AddTransient<IValidator<Carrito>, CarritoValidator>();
            services.AddTransient<IValidator<Comprador>, CompradorValidator>();
            services.AddTransient<IValidator<Producto>, ProductoValidator>();
            services.AddTransient<IValidator<ProductoPedido>, ProductoPedidoValidator>();
            services.AddTransient<IValidator<Tienda>, TiendaValidator>();
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
