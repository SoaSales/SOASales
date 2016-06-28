using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineSales.Data.Models.Mapping
{
    public class productMap : EntityTypeConfiguration<product>
    {
        public productMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Category)
                .HasMaxLength(50);

            this.Property(t => t.OtherInfo)
                .HasMaxLength(1073741823);

            this.Property(t => t.MadeIn)
                .HasMaxLength(100);

            this.Property(t => t.Seller)
                .HasMaxLength(100);

            this.Property(t => t.Tags)
                .HasMaxLength(250);

            this.Property(t => t.StorageLocation)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("products", "onlinesales");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.OtherInfo).HasColumnName("OtherInfo");
            this.Property(t => t.MadeIn).HasColumnName("MadeIn");
            this.Property(t => t.Seller).HasColumnName("Seller");
            this.Property(t => t.ISBN).HasColumnName("ISBN");
            this.Property(t => t.OutOfProduction).HasColumnName("OutOfProduction");
            this.Property(t => t.Tags).HasColumnName("Tags");
            this.Property(t => t.StorageLocation).HasColumnName("StorageLocation");
        }
    }
}
