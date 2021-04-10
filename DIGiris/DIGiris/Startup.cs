using DIGiris.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIGiris
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
            //services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
            //services.Add(new ServiceDescriptor(typeof(TextLog), typeof(ILog), ServiceLifetime.Singleton));
            services.AddSingleton<ILog, ConsoleLog>();
            //services.AddScoped<ILog, TextLog>();
            //services.AddScoped<ILog, ConsoleLog>();
            //services.AddTransient<ILog, ConsoleLog>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Custom Middleware Calisti");
            //    await next.Invoke();
            //    Console.WriteLine("Custom Middleware Tamamlandi");
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Run Middleware Calisti");
            //});

            app.Map("/wordpress", level1App => {
                level1App.Run(async context => {
                    await context.Response.WriteAsync("Bu site Wordpress Degil!");
                });
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
