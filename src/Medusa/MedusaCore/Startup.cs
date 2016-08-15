using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Claims;
using Softcraftng.Medusa.MedusaCore.Services;
using Microsoft.Extensions.Localization;
using Softcraftng.Medusa.MedusaCore.Localization;
using Softcraftng.Medusa.MedusaCore.Data;
using Softcraftng.Medusa.MedusaCore;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNetCore.Http;
using Softcraftng.Medusa.MedusaCore.Models;
using Softcraftng.Medusa.MedusaCore.Medusa;

namespace Softcraftng.Medusa.MedusaCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            Startup.ConfigurationStatic = Configuration;//TODO: refactor; used to pass config to DataContext. There should be a better way
            MappingConfig.RegisterMaps();
        }

        public IConfigurationRoot Configuration { get; }
        public static IConfigurationRoot ConfigurationStatic { get; set; } //TODO: refactor

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            //authorization
            services.AddAuthorization(configure =>
            {
                configure.AddPolicy("admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Name, new string[] { "dapo.onawole@gmail.com" });
                });
            });


            //configure MVC
            services.Configure<MvcOptions>(options =>
            {
                options.MaxModelValidationErrors = 50;
            });

            // Add application services.
            //services.Configure<AppKeyConfig>(Configuration.GetSection("AppKeys"));// for user secrets

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<ICache, CacheServices>();
            services.AddScoped<IMedusa, Medusa.Medusa>();
            //services.AddScoped<IStringLocalizerFactory, JsonStringLocalizerFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            app.UseApplicationInsightsRequestTelemetry();

            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            env.ConfigureNLog("nlog.config");

            //https
            //var pfxFile = Path.Combine(appEnv.ApplicationBasePath, "himvc.pfx");
            //TODO: Change to secret file
            //X509Certificate2 certificate = new X509Certificate2(pfxFile, "password");
            //app.Use(ChangeContextToHttps);
            //app.UseKestrelHttps(certificate);

            //app.UseDeveloperExceptionPage();
            //app.UseMvcWithDefaultRoute();

            // intitiaize database witht data

            //SeedData.Initialize(app.ApplicationServices);
        }

        private static RequestDelegate ChangeContextToHttps(RequestDelegate next)
        {
            return async context =>
            {
                context.Request.Scheme = "https";
                await next(context);
            };
        }
    }
}
