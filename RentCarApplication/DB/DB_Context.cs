using Microsoft.EntityFrameworkCore;
using RentCarApplication.DTOs;

namespace RentCarApplication.DB
{
    public class DB_Context: DbContext 
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehiculo>(entity =>
            {
                entity.HasOne(x => x.Modelo)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Cliente>(entity =>
            {
                entity.Property(x => x.Limite_Credito)
                .HasColumnName("Límite_Credito");
            });

            builder.Entity<Vehiculo>(entity =>
            {
                entity.Property(x => x.Descripcion)
                .HasColumnName("Descripción");
            });
        }
        
        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<Combustible> Combustibles { set; get; }
        public DbSet<Empleado> Empleados { set; get; }
        public DbSet<Inspeccion> Inspeccions { set; get; }
        public DbSet<Marcas> Marcas { set; get; }
        public DbSet<Modelos> Modelos { set; get; }
        public DbSet<Renta_Devolucion> Renta_Devolucions { set; get; }
        public DbSet<Tipo_Vehiculo> Tipo_Vehiculos { set; get; }
        public DbSet<Vehiculo> Vehiculos { set; get; }
    }
}
