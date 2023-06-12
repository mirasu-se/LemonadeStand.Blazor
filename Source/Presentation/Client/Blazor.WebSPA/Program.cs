using Blazor.WebSPA.ViewModels;
using Blazor.WebSPA.ViewModels.Coctail;
using Blazor.WebSPA.ViewModels.Juice;
using Domain.Services;
using Domain.Services.Juice;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.WebSPA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<JuiceRecipeViewModel>();
            builder.Services.AddSingleton<JuiceOrderViewModel>();

            builder.Services.AddSingleton<CoctailRecipeViewModel>();
            builder.Services.AddSingleton<IFruitPressService, FruitPressService>();
            builder.Services.AddSingleton<IRecipeService, RecipeService>();

            await builder.Build().RunAsync();
        }
    }
}
