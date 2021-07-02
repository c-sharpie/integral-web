using System;
using Integral.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Integral.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseWebSocketMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseWebSockets();
            applicationBuilder.UseMiddleware<WebSocketMiddleware>();
        }

        public static void UseFileServer(this IApplicationBuilder applicationBuilder, Action<FileServerOptions> configureOptions)
        {
            FileServerOptions fileServerOptions = new FileServerOptions();
            configureOptions(fileServerOptions);
            applicationBuilder.UseFileServer(fileServerOptions);
        }
    }
}
