using AutoMapper;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Reflection;

namespace CourseLibrary.API
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
            services.AddProtectedWebApi(Configuration)
            .AddInMemoryTokenCaches();

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

            }).AddNewtonsoftJson(setupAction =>
             {
                 setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
             })
             .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = "https://courselibrary.com/modelvalidationproblem",
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });

            #region OpenAPI Spec
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenApi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Compliant Details API",
                        Version = "1.0",
                        Description = "CRUD API for Compliant System"
                    });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
            #endregion


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IComplaintDetailRepository, ComplaintDetailRepository>();

            services.AddDbContext<CourseLibraryContext>(options =>
            {
                options.UseSqlServer(
                    @"Data Source=IN46TAALKQJL;Initial Catalog=CoreLibraryDB;Integrated Security=True"
                    );

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            #region OpenAPI Spec
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/OpenApi/swagger.json",
                    "Compliant Details API");
                setupAction.RoutePrefix = "";
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
