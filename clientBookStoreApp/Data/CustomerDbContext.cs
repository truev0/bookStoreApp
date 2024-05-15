using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clientBookStoreApp.Models.Entities;
using Microsoft.Extensions.Logging;

namespace clientBookStoreApp.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseMySql("Server=localhost;Port=3315;Database=customerdb;User=root;Password=123456789;", ServerVersion.AutoDetect("Server=localhost;Port=3315;Database=customerdb;User=root;Password=123456789;"))
                    .UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder
                        .AddFilter("Microsodt", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                        .AddConsole();
                    }))
                    .EnableSensitiveDataLogging(false);
            }
        }
    }
}
