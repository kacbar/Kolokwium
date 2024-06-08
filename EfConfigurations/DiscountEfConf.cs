using KolokwiumAPBD.Models;

namespace Kolokwium.EfConfigurations
{
    public class DiscountEfConf : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.IdDiscount);
            builder.Property(d => d.IdDiscount).ValueGeneratedOnAdd();
            builder.Propert(d => d.Value).IsRequired();
            builder.Propert(d => d.DateFrom).IsRequired();
            builder.Propert(d => d.DateTo).IsRequired();

            builder.HasOne(d => d.IdSubscriptionNavigation)
                   .WithMany(s => s.Discounts)
                   .HasForeignKey(d => d.IdSubscription);
        }
    }
}
