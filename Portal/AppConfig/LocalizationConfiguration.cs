using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace Portal.AppConfig
{
    public class LocalizationConfiguration
    {
        public static void Config(IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("ru"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }
    }
}