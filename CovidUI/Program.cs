using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Syncfusion.Blazor;

namespace CovidUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddBlazorise(options => options.ChangeTextOnKeyPress = true)
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjkwODA2QDMxMzgyZTMyMmUzMGJKcDJCOEJGVm5zTERQVTRsa0ovNndNRWF6UWtmMmtaNWVXbWxTV21udGM9;MjkwODA3QDMxMzgyZTMyMmUzMEtQU1lGWGRiVzVUbGUyZ3dhMGtOSll5a2REbFNBK3ViYzZpaXVxUE40aWM9;MjkwODA4QDMxMzgyZTMyMmUzMEFmajRHenVyemV6cmV2UjRxUDB6Y0lrS0NBWDRaZmJpenkyZXZoZzlRV2M9");

            await builder.Build().RunAsync();
        }
    }
}
