using clientBookStoreApp.Data;
using clientBookStoreApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace clientBookStoreApp.Services
{
    public class CustomerService
    {
        private readonly CustomerDbContext _context;

        public CustomerService(CustomerDbContext context)
        { 
            _context = context;
        }

        public async Task ListCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            Console.WriteLine("========= LISTADO DE CLIENTES =========");
            foreach (var customer in customers)
            {
                
               Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Rut: {customer.Rut}, Status: {customer.Status}");
                
            }
            Console.WriteLine("========================================");
        }

        public async Task CreateCustomer()
        {
            Console.WriteLine("========= CREANDO CLIENTES =========");
            Console.Write("Ingrese el nombre completo del cliente: ");
            var name = Console.ReadLine();

            Console.WriteLine("Ingrese el RUT del cliente:");
            var rut = Console.ReadLine();

            var customer = new Customer { Name = name, Rut = rut };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            Console.WriteLine("Cliente creado con exito");
            Console.WriteLine("========================================");
        }

        public async Task ChangeCustomerStatus()
        {
            Console.WriteLine("========= CAMBIAR STATUS DE CLIENTES =========");
            Console.WriteLine("Ingrese el ID del cliente");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    Console.WriteLine("Ingrese el nuevo estado del cliente (Activo/Inactivo):");
                    var status = Console.ReadLine();
                    if (status == "Activo" || status == "Inactivo")
                    {
                        customer.Status = status;
                        await _context.SaveChangesAsync();
                        Console.WriteLine("Estado del cliente actualizado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Estado no valido");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado");
                }
            }
            else {
                Console.WriteLine("ID no valido");
            }
            Console.WriteLine("========================================");
        }

        public async Task GenerateJsonFile()
        {
            Console.WriteLine("========= EXPORTANDO CLIENTES =========");
            var customers = await _context.Customers.ToListAsync();
            var json = JsonSerializer.Serialize(customers);
            await System.IO.File.WriteAllTextAsync("customers.json", json);
            Console.WriteLine("Archivo JSON generado con exito");
            Console.WriteLine("========================================");
        }

    }
}
