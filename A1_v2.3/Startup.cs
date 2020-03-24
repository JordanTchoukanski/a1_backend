using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using A1_v2._3.Data;
using A1_v2._3.Models;
using Microsoft.EntityFrameworkCore;

namespace A1_v2._3
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddMvc().AddXmlSerializerFormatters();
            services.AddEntityFrameworkNpgsql().AddDbContext<aApiContext>(options => options.UseNpgsql(Configuration.GetConnectionString("a1_connection")));


            //services.AddDbContext<ProductsDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("a1_connection")));
            //services.AddEntityFrameworkNpgsql.AddDbContext<ProductsDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("a1_connection")));
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, aApiContext aApiContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            aApiContext.Database.EnsureCreated();

        }
    }
}
