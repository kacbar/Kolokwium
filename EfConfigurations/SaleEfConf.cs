using KolokwiumAPBD.Models;

namespace Kolokwium.EfConfigurations
{
    public class SaleEfConf : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.IdSale);
            builder.Property(s => s.IdSale).ValueGeneratedOnAdd();
            builder.Propert(s => s.CreatedAt).IsRequired();

            builder.HasOne(s => s.IdClientNavigation)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.IdClient);

            builder.HasOne(s => s.IdSubscriptionNavigation)
                .WithMany(su => su.Sales)
                .HasForeignKey(s => s.IdSubscription);
        }
    }
}
