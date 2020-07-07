using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();

            IWebHost Host = CreateWebHostBuilder(args).Build();
            RunSeeding(Host);
            Host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }

        private static void RunSeeding(IWebHost Host)
        {
            IServiceScopeFactory ScopeFactory = Host.Services.GetService<IServiceScopeFactory>();

            using (IServiceScope Scope = ScopeFactory.CreateScope())
            {
                SeedDB Seeder = Scope.ServiceProvider.GetService<SeedDB>();
                Seeder.SeedAsync().Wait();

                /*
                Seeder.CheckPropietariosAsync().Wait();
                Seeder.CheckTipoMascotasAsync().Wait();
                Seeder.CheckMascotasAsync().Wait();
                Seeder.CheckTipoServiciosAsync().Wait();
                Seeder.CheckAgendasAsync().Wait();
                */
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
