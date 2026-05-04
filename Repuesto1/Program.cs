using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repuesto1.Data.Context;
using Repuesto1.FormsInformacion;
using Repuesto1.Services;
using System.IO;

namespace Repuesto1;

static class Program
{
    public static ServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        Application.Run(ServiceProvider.GetRequiredService<IngresoForm>());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("RepuestoConnection");

        services.AddDbContext<RepuestoContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            }));

        // Forms
        services.AddTransient<IngresoForm>();
        services.AddTransient<RegristroUsuarioForm>();
        services.AddTransient<Form1>();

        services.AddTransient<GestionarFacturasForm>();
        services.AddTransient<GestionarComprasForm>();
        services.AddTransient<GestionarProductForm>();
        services.AddTransient<GestionarProveedorForm>();
        services.AddTransient<GestionarIngresosForm>();
        services.AddTransient<GestionarVentasForm>();
        services.AddTransient<GestionarCajaForm>();

        // Services
        services.AddTransient<ProductoServices>();
        services.AddTransient<ProveedorServices>();
        services.AddTransient<CompraServices>();
        services.AddTransient<IngresoServices>();
        services.AddTransient<UsuarioServices>();
    }
}