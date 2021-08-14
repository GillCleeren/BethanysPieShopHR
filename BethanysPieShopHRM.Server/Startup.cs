using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BethanysPieShopHRM.Server.Services;
using Syncfusion.Blazor;

namespace BethanysPieShopHRM.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            
            //services.AddScoped<HttpClient>(s =>
            //{
            //    var client = new HttpClient { BaseAddress = new System.Uri("https://localhost:44340/") };
            //    //var client = new HttpClient();
            //    //var client = new HttpClient { BaseAddress = new System.Uri("https://bethanyspieshophrmapi.azurewebsites.net/") }; 
            //    return client;
            //});

            //services.AddScoped<IEmployeeDataService, MockEmployeeDataService>();
            services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
            });
            services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
            });
            services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
            });

            services.AddSyncfusionBlazor();
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
