using AA.CommoditiesDashboard.Api.Config;
using AA.CommoditiesDashboard.Domain.Service;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using AA.CommoditiesDashboard.Infrastructure.Data.Contexts;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AA.CommoditiesDashboard.Api
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
            services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", p => p.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddControllers();
            services.AddDbContext<CommoditiesDashboardDbContext>(
               options =>
                   options
                       .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddSwagger();
            services.AddTransient<ICommodityProviderService, CommodityProviderService>();
            services.AddTransient<ICommodityDataRepository, CommodityDataRepository>();
            services.AddTransient<IKeyMetricsProviderService, KeyMetricsProviderService>();
            services.AddTransient<IHistoricalTrendsService, HistoricalTrendsService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
