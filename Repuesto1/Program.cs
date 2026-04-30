using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using System.IO;

namespace Repuesto1;

static class Program
{
    public static ServiceProvider ServiceProvider { get; private set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        // Iniciar con el formulario de Login
        //TODO Application.Run(ServiceProvider.GetRequiredService<FormLogin>());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Configurar la lectura del appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("RepuestoConnection");

        // Registrar DbContext
        services.AddDbContext<RepuestoContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            }));

        // Registrar Forms
        //services.AddTransient<FrmLogin>();
        //services.AddTransient<FrmMain>();          // Tu formulario principal con el menú

        // Registrar Forms de las diferentes tablas (como en AdventureAdmin)
        services.AddTransient<GestionarFacturasForm>();
        services.AddTransient<GestionarComprasForm>();
        services.AddTransient<GestionarProductForm>();
        services.AddTransient<GestionarProveedorForm>();
        services.AddTransient<GestionarIngresosForm>();

        // Registrar Servicios (IService)
        services.AddTransient<ProductoServices>();
        services.AddTransient<ProveedorServices>();
        services.AddTransient<CompraServices>();
        services.AddTransient<IngresoServices>();
        //services.AddTransient<UsuarioService>();   // Para el login
    }
}