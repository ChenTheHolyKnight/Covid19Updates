using Covid19Backend.Models;
using Covid19Backend.Models.Database;
using Covid19Backend.Repositories;
using Covid19Backend.Services;
using Covid19Backend.Services.Common;
using Covid19Backend.Services.EmailServices.Helpers;
using Covid19Backend.Services.ExcelService;
using Covid19Backend.Services.ExcelService.Helper;
using Covid19Backend.Services.Formatter;
using Covid19Backend.Services.GitHubDataAcquiringService;
using Covid19Backend.Services.GitHubDataAcquiringService.Helpers;
using Covid19Backend.Services.WebDataScrappingService;
using Covid19Backend.Services.WorldDataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Covid19Backend
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
            services.AddControllersWithViews();

            #region Service Registration 
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailBodyFormatter, EmailBodyFormatter>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IWebDataScrapingService, WebDataScrapingService>();
            services.AddTransient<IGitService, GitService>();
            services.AddTransient<IGitHelper, GitHelper>();
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<IExcelHelper, ExcelHelper>();
            services.AddTransient<IDirectoryHelper, DirectoryHelper>();
            services.AddTransient<IWorldDataService, WorldDataService>();
            //Singleton
            services.AddSingleton<IStats, Stats>();


            services.Configure<DatabaseSettings>(
                 Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<IEmailRepository, EmailRepository>();
            #endregion

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                //configuration.RootPath = "ClientApp/build";
                configuration.RootPath = "WebClient/client/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                //spa.Options.SourcePath = "ClientApp";
                spa.Options.SourcePath = "WebClient/client";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
