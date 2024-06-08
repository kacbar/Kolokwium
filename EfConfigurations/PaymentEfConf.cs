using KolokwiumAPBD.Models;

namespace Kolokwium.EfConfigurations
{
    public class PaymentEfConf : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.IdPayment);
            builder.Property(p => p.IdPayment).ValueGeneratedOnAdd();
            builder.Property(p => p.Date).IsRequired();

            builder.HasOne(p => p.IdClientNavigation)
                   .WithMany(c => c.Payments)
                   .HasForeignKey(p => p.IdClient);

            builder.HasOne(p => p.IdSubscriptionNavigation)
                   .WithMany(s => s.Payments)
                   .HasForeignKey(p => p.IdSubscription);
        }
    }
}
