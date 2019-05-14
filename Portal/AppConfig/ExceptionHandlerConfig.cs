using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Portal.AppConfig
{
    public class ExceptionHandlerConfig
    {
        public static void Config(IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandlingPath = "/Admin/Home/ServerError"
                }
            );

//            async Task ExceptionHandlerDelegate(HttpContext context)
//            {
//                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
//                context.Response.ContentType = "application/json";
//                var ex = context.Features.Get<IExceptionHandlerFeature>();
//                if (ex != null)
//                {
//                    Log.Error(ex.Error, ex.Error.Message);
//                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResult<object>(default, false)
//                    {
//                        Error = new ErrorModel
//                        {
//                            Code = 500,
//                            Message = "Internal server error"
//                        }
//                    })).ConfigureAwait(false);
//                }
//            }
                
//            app.UseWhen(
//                context => context.Request.Path.StartsWithSegments(new PathString("/api")),
//                a => a.UseExceptionHandler(options => { options.Run(ExceptionHandlerDelegate); }));
        }
    }
}