using CupMovies.Data.Repository;
using CupMovies.Domain.Interface.Repository;
using CupMovies.Domain.Interface.Service;
using CupMovies.Domain.Models;
using CupMovies.Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CupMovies.API.Movies
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<ToolServices>(Configuration)
                .AddSingleton(sp => sp.GetRequiredService<IOptions<ToolServices>>().Value);

            Mapping(services);

            services.AddControllers();
            services.AddCors();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Cup Movies",
                        Version = "v1",
                        Description = "Cup Movies API"
                    });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("swagger/v1/swagger.json", "Cup Movies");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void Mapping(IServiceCollection services)
        {
            // Services
            services.AddTransient<IMoviesService, MoviesService>();

            // Repositories
            services.AddTransient<IMoviesRepository, MoviesRepository>();
        }
    }
}
