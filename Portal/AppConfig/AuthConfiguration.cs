using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Portal.AppConfig
{
    public static class AuthConfiguration
    {
        public static void Config(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
                    options.Cookie.Name = "portal_session_id";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.MaxAge = TimeSpan.FromDays(1);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/home/autherror";
                });
//
//            services.AddAuthorization(options =>
//            {
//                options.AddPolicy("View", policy =>
//                {
//                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
//                    policy.RequireAuthenticatedUser();
//                    policy.Requirements.Add(new ViewPermission());
//                });
//                
//                options.AddPolicy("All", policy =>
//                {
//                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
//                    policy.RequireAuthenticatedUser();
//                    policy.Requirements.Add(new AllPermission());
//                });
//            });
//            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        }
    }
}