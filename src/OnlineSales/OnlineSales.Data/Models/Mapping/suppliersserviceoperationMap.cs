using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineSales.Data.Models.Mapping
{
    public class suppliersserviceoperationMap : EntityTypeConfiguration<suppliersserviceoperation>
    {
        public suppliersserviceoperationMap()
        {
            // Primary Key
            this.HasKey(t => t.ServiceOperationsId);

            // Properties
            this.Property(t => t.ServiceOperationsId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Operation)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.URL)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.HTTAction)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("suppliersserviceoperations", "onlinesales");
            this.Property(t => t.ServiceOperationsId).HasColumnName("ServiceOperationsId");
            this.Property(t => t.SupplierId).HasColumnName("SupplierId");
            this.Property(t => t.Operation).HasColumnName("Operation");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.HTTAction).HasColumnName("HTTAction");
        }
    }
}
