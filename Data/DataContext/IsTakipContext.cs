using Data.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.DataContext
{
    public class IsTakipContext : DbContext
    {
        public DbSet<Eleman> Eleman { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Izin> Izin { get; set; }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Is> Is { get; set; }
        public DbSet<IsMadde> IsMadde { get; set; }
        public DbSet<Duyuru> Duyuru { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
        }
    }
}
