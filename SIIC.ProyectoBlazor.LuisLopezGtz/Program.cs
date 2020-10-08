using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIIC.ProyectoBlazor.LuisLopezGtz.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisLopezGtz.Bussines_Layer;
namespace SIIC.ProyectoBlazor.LuisLopezGtz
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            #region UrlServer
            builder.Services.AddTransient(EmpresasAPI => new EmpresasAPI("https://tiendablazor.azurewebsites.net"));
            builder.Services.AddTransient<EmpresasBL>();
            builder.Services.AddTransient(EmpleadosAPI => new EmpleadosAPI("https://tiendablazor.azurewebsites.net"));
            builder.Services.AddTransient<EmpleadosBL>();
            #endregion

            await builder.Build().RunAsync();
        }
    }
}
