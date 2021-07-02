using Integral.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integral.Applications
{
    public abstract class MvcApplication : WebApplication
    {
        protected MvcApplication(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            base.ConfigureServices(serviceCollection);
            serviceCollection.AddRazorPages(Configure);
            serviceCollection.AddControllers(Configure);
        }

        public override void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            base.Configure(applicationBuilder, webHostEnvironment);
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseFileServer(Configure);
            applicationBuilder.UseEndpoints(Configure);
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseHsts();
        }

        protected virtual void Configure(RazorPagesOptions razorPagesOptions)
        {
        }

        protected virtual void Configure(MvcOptions mvcOptions)
        {
        }

        protected virtual void Configure(FileServerOptions fileServerOptions)
        {
        }

        protected virtual void Configure(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapRazorPages();
            endpointRouteBuilder.MapControllers();
        }
    }
}