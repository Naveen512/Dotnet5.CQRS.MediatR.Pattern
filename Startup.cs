using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.CQRS.Sample.Contracts.CommandHandlers;
using API.CQRS.Sample.Contracts.QueryHandlers;
using API.CQRS.Sample.Data;
using API.CQRS.Sample.Handlers.CommandsHandlers;
using API.CQRS.Sample.Handlers.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API.CQRS.Sample
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.CQRS.Sample", Version = "v1" });
            });

            services.AddDbContext<MyWorldDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyWorldDbConnection"));
            });

            //services.AddScoped<ISaveProductCommandHandler, SaveProductCommandHandler>();
            //services.AddScoped<IAllProductsQueryHandler,AllProductsQueryHandler>();
            //services.AddScoped<IPriceRangeProductsQueryHandler, PriceRangeProductsQueryHandler>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.CQRS.Sample v1"));
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
