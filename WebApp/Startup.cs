using AutoMapper;
using ComplaintLoggingSystem.Helpers;
using ComplaintLoggingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using AppContext = ComplaintLoggingSystem.Helpers.AppContext;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;


namespace ComplaintLoggingSystem
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
            services.AddDistributedMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 
            
            services.AddOptions();


            //services.AddAuthentication(sharedOptions =>
            //{
            //    sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //})
            //.AddAzureAd(options => Configuration.Bind("AzureAd", options))
            //.AddCookie();

            services.AddMicrosoftIdentityPlatformAuthentication(Configuration)
            .AddMsal(Configuration,new string[] { Configuration["TodoList:TodoListScope"] })
            .AddInMemoryTokenCaches();

            //services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            //    .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //})

            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add APIs
            services.AddTodoListService(Configuration);

            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          

            services.AddHttpClient(UserConstants.CORELIBRARYHTTPCLIENT, client =>
            {
                client.BaseAddress = new Uri(Configuration["appSettings:CoreLibraryUrl"]);

            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IComplaintDetailsSystem, ComplaintDetailsSystem>();
            //services.AddMvc();
            //services.AddControllersWithViews(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            AppContext.Configure(app.ApplicationServices
               .GetRequiredService<IHttpContextAccessor>());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
