using Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BenjiAPI
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //services.AddCors();
            services.AddControllers();
            services.AddScoped<DogManager>();
            services.AddScoped<DocumentManager>();
            services.AddScoped<FolderManager>();
            services.AddScoped<HealthManager>();
            services.AddScoped<IncidentManager>();
            services.AddScoped<BoardingManager>();
            services.AddScoped<FoodManager>();
            services.AddScoped<VaccineManager>();
            //services.AddCors(c => c.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseCors(policy =>
            //    policy.AllowAnyOrigin()
            //    //policy.WithOrigins("http://localhost:64360/", "http://localhost:59006/")
            //    .AllowAnyMethod());
            //    //.WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
            //    //.AllowCredentials());
        }
    }
}