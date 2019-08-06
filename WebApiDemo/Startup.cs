using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.core;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace WebApiDemo
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
            services.AddDbContextPool<StudentdbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Studentdb"));
            });
            services.AddTransient<Istudent, InRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Student Api Test",
                    Version = "v1",
                    Description = "",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Gaurav", Email = "xyz@gmail.com", Url = "www.example.com" },
                    License = new License() { Name = "License Terms", Url = "www.example.com" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Serves the Swagger UI
            app.UseSwaggerUI(c =>
            {
                // specifying the Swagger JSON endpoint.
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
                c.RoutePrefix = string.Empty;
            });
          
            app.UseMvc();
        }
    }
}
