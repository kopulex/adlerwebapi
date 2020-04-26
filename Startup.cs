using AdlerCatalogueWebApi.Auth;
using AdlerCatalogueWebApi.DAL;
using AdlerCatalogueWebApi.Helper;
using AdlerCatalogueWebApi.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdlerCatalogueWebApi
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
            var config = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(config));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            // registed movie service
            services.AddScoped<IMovieService, MovieService>();

            services.AddOpenApiDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
