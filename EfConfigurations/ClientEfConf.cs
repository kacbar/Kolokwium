using KolokwiumAPBD.Models;

namespace Kolokwium.EfConfigurations
{
    public class ClientEfConf : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.IdClient);
            builder.Property(c => c.IdClient).ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Phone).IsRequired(false).HasMaxLength(100);
        }
    }
}
