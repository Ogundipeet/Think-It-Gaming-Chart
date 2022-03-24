using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Think_It_Gaming_Chart.Application;
using Think_It_Gaming_Chart.Core.Repositories.Queries;
using Think_It_Gaming_Chart.Core.Repositories.Queries.Base;
using Think_It_Gaming_Chart.Infrastructure;
using Think_It_Gaming_Chart.Infrastructure.Repositories.Queries;
using Think_It_Gaming_Chart.Infrastructure.Repositories.Queries.Base;

namespace Think_It_Gaming_Chart.API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddInfrastructure();
            services.AddControllers();
            services.AddMediatR(typeof(ThinkItGamingChartEntryPoint).Assembly);

            services.AddAutoMapper(typeof(ThinkItGamingChartEntryPoint).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin());
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
