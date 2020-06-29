using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ColorWebPage
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var colorFromConfig = Configuration["color"];
                    var colorFromEnv = Environment.GetEnvironmentVariable("WEB_PAGE_COLOR");
                    var webPageColor = String.IsNullOrEmpty(colorFromConfig) ? colorFromEnv : colorFromConfig; 
                    if(String.IsNullOrEmpty(webPageColor)) {
                        webPageColor = "blue";
                    }
                    var content = "<style>body { background-color: " + webPageColor + "; }</style>";
                    await context.Response.WriteAsync(content);
                });
            });
        }
    }
}
