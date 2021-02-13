using System.Data.Entity;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Infra.EF.Mapping;

namespace WiproPriceSystem.Infra.EF.Context
{
    public class LocalContext : DbContext
    {
        static LocalContext()
        {
            Database.SetInitializer<LocalContext>(null);
        }
        public LocalContext() : base("Name=LocalContext")
        {
        }
        
        public DbSet<Fila> Filas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FilaMapping());
        }
    }
}