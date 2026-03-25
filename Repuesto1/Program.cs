using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repuesto1.Model;
using System.IO;

namespace Repuesto1
{
    internal static class Program
    {
        public static IConfiguration? Configuration { get; private set; }
        public static AppDbContext? DbContext { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar la lectura del appsettings.json
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configurar el DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            // Crear una instancia global del DbContext
            DbContext = new AppDbContext(optionsBuilder.Options);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}