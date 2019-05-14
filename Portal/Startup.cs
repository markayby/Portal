using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Portal.AppConfig;
using Portal.Core.Validation;

namespace Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // DIConfiguration.Config(services, Configuration);
            DbConfiguration.Config(services, Configuration);
            AuthConfiguration.Config(services);

            services.AddAntiforgery(opt =>
            {
                opt.HeaderName = "X-XSRF-TOKEN";
                opt.Cookie.Name = "XSRF-TOKEN";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Path = "/";
            });

            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession(opt => { opt.IdleTimeout = TimeSpan.FromDays(1); });

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(
                    options =>
                    {
                        options.ModelMetadataDetailsProviders.Add(
                            new CustomValidationMetadataProvider("Portal.SiteResources", typeof(SiteResources)));
                    }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                })
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

            services.AddAutoMapper();

//            services.Configure<ApiBehaviorOptions>(options =>
//            {
//                options.SuppressModelStateInvalidFilter = true;
//                options.SuppressConsumesConstraintForFormFileParameters = true;
//            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                ExceptionHandlerConfig.Config(app);
            }

            app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)));

            LocalizationConfiguration.Config(app);

            app.UseStaticFiles();

            app.UseSession();
            
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            app.UseAuthentication();

            RouteConfiguration.Config(app);

            DbConfiguration.MigrateDb(app);
        }
    }
}