using Microsoft.AspNetCore.Builder;

namespace Portal.AppConfig
{
    public class RouteConfiguration
    {
        public static void Config(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
//                routes.MapRoute(
//                    name: "areaRoute",
//                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}