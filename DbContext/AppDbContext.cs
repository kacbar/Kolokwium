using Kolokwium.EfConfigurations;

crosoft.EntityFrameworkCore;

namespace KolokwiumAPBD.DbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEfConf());
            modelBuilder.ApplyConfiguration(new DiscountEfConf());
            modelBuilder.ApplyConfiguration(new PaymentEfConf());
            modelBuilder.ApplyConfiguration(new SaleEfConf());
            modelBuilder.ApplyConfiguration(new SubscriptionEfConf());

            base.OnModelCreating(modelBuilder);
        }
    }
}