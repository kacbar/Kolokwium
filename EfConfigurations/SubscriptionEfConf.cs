using KolokwiumAPBD.Models;

namespace Kolokwium.EfConfigurations
{
    public class SubscriptionEfConf : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.IdSubscription);
            builder.Property(s => s.IdSubscription).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.RenewalPeriod).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();
            builder.Property(s => s.Price).IsRequired();
        }
    }
}
