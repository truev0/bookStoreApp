using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using clientBookStoreApp.Data;
using clientBookStoreApp.Services;
using Microsoft.Extensions.Logging;

namespace clientBookStoreApp
{
    class Program
    {
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            var customerService = services.GetRequiredService<CustomerService>();

            // Logica para el menu de la consola
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bienvenido al adminPanel de clientes");
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Crear Cliente");
                Console.WriteLine("3. Cambiar estado de cliente");
                Console.WriteLine("4. Generar archivo JSON con los clientes actuales");
                Console.WriteLine("5. Salir");
                    Console.Write("Eleccion: ");
                var choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        await customerService.ListCustomers();
                        break;
                    case "2":
                        await customerService.CreateCustomer();
                        break;
                    case "3":
                            await customerService.ChangeCustomerStatus();
                            break;
                    case "4":
                        await customerService.GenerateJsonFile();
                            break;
                    case "5":
                            exit = true;
                            break;

                    default:
                            Console.WriteLine("Opción no valida");
                        break;
                }
            }
        }
    }
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddDbContext<CustomerDbContext>(options =>
                        options.UseMySql("Server=localhost;Port=3315;Database=customerdb;User=root;Password=123456789;",
                            new MySqlServerVersion(new Version(8, 0, 23))))
                            .AddTransient<CustomerService>())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); // Remove all providers from LoggerFactory
                    logging.AddConsole(); // Add console logging
                    logging.AddFilter("Microsoft", LogLevel.Warning); // Filters out all logs, except for warnings
                    logging.AddFilter("System", LogLevel.Warning);
                });
    }
}