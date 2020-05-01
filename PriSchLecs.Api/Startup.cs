using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
using PriSchLecs.Api.Dtos;
using PriSchLecs.Api.Infrastructures.Data;
using PriSchLecs.Api.Infrastructures.Repositories;
using PriSchLecs.Api.Infrastructures.Services.Categories;
using PriSchLecs.Api.Infrastructures.Services.Lectures;

namespace PriSchLecs.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DbContext
            services.AddDbContext<PriSchLecsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Services
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });

                //c.IncludeXmlComments("/swagger/v1/swagger.json", true);
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            AutoMapperConfig.Init();
        }
    }
}
