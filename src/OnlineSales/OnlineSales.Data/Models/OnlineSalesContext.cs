using System.Data.Entity;
using OnlineSales.Data.Models.Mapping;

namespace OnlineSales.Data.Models
{
    public partial class OnlineSalesContext : DbContext
    {
        static OnlineSalesContext()
        {
            Database.SetInitializer<OnlineSalesContext>(null);
        }

        public OnlineSalesContext()
            : base("Name=onlinesalesContext")
        {
        }

        public DbSet<product> products { get; set; }
        public DbSet<supplier> suppliers { get; set; }
        public DbSet<suppliersserviceoperation> suppliersserviceoperations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new productMap());
            modelBuilder.Configurations.Add(new supplierMap());
            modelBuilder.Configurations.Add(new suppliersserviceoperationMap());
        }
    }
}
