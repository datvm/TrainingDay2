using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TrainingDay2.Api.Models.Entities;
using TrainingDay2.Api.Models.Services;
using TrainingDay2.Api.Models.ViewModels;

namespace TrainingDay2.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            this.InitializeMapper();

            var connectionString = this.Configuration.GetConnectionString("TrainingContext");
            services.AddDbContext<TrainingContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Tag, TagBasicViewModel>();
                config.CreateMap<Contact, ContactBasicViewModel>();

                config.CreateMap<ContactSearchResultItemEntity, ContactSearchResultItemViewModel>();
            });
        }

    }
}
