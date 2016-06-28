using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineSales.Data.Models.Mapping
{
    public class supplierMap : EntityTypeConfiguration<supplier>
    {
        public supplierMap()
        {
            // Primary Key
            this.HasKey(t => t.SupplierId);

            // Properties
            this.Property(t => t.SupplierId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("suppliers", "onlinesales");
            this.Property(t => t.SupplierId).HasColumnName("SupplierId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
