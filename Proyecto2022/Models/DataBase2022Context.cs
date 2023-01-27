using Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Windows.Media.Media3D;

namespace Data.Models
{
    public class DataBase2022Context : DbContext
    {
        public DataBase2022Context()
        {

        }


        public virtual DbSet<Producto>? Productos { get; set; }
        public virtual DbSet<Cliente>? Clientes { get; set; }
        public virtual DbSet<Localidad>? Localidades { get; set; }
        public virtual DbSet<Venta>? Ventas { get; set; }
        public virtual DbSet<VentaDetalle>? VentaDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.LogTo(m => Debug.WriteLine(m), new[] { DbLoggerCategory.Database.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .UseMySql(Helper.GetConnectionString(),
                    ServerVersion.AutoDetect(Helper.GetConnectionString()),
                    options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                   errorNumbersToAdd: null));


                //    optionsBuilder.UseMySql("Server=localhost;Database=proyecto2022;user=root;password=;", ServerVersion.AutoDetect("Server=localhost;Database=proyecto2022;user=root;password=;"),
                //         options => options.EnableRetryOnFailure(
                //         maxRetryCount: 5,
                //         maxRetryDelay: System.TimeSpan.FromSeconds(30),
                //         errorNumbersToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
