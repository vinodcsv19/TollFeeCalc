using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Toll.Fees.Calculator.Api.Interfaces;
using Toll.Fees.Calculator.Api.Model;
using Toll.Fees.Calculator.Api.Services;
using Toll.Fees.Calculator.Lib;

namespace Toll.Fees.Calculator.Api
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


            services.AddSingleton<ITollFeeCalculatorService, TollFeeCalculatorService>();
            services.AddSingleton<ITollFeeCalculator, TollFeeCalculator>();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Toll fee Calculator Api",
                    Version = "v1",
                    Description = "Toll Fee rules",
                    Contact = new OpenApiContact
                    {
                        Name = "Toll Tax Calculator Api",
                        Email = "supportcongestiontax@transportstyrelsen.com"
                    }
                });
            });
            services.AddMvc(option => { option.Filters.Add(new ValidationFilter()); })
                .AddFluentValidation(option => { option.RegisterValidatorsFromAssemblyContaining<Startup>(); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller= Home}/{action=Index}/{id?}");
            });
            app.UseSwagger(c => { c.SerializeAsV2 = true; });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Congestion tax rules");

                c.RoutePrefix = string.Empty;
            });

        }
    }
}
