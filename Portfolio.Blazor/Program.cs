using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Portfolio.Shared;

namespace Portfolio.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //TODO get this to work with base
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://lloyd-portfoli.herokuapp.com/") });
            builder.Services.AddScoped<ProjectApiService>();
            //builder.Services.Configure<RouteOptions>(options =>
            //{
            //    options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
            //});

            await builder.Build().RunAsync();
        }
    }
}
