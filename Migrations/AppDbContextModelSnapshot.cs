using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KolokwiumAPBD.DbContext;

#nullable disable

namespace Kolokwium.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KolokwiumAPBD.Models.Client", b =>
            {
                b.Property<int>("IdClient")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Phone")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.HasKey("IdClient");

                b.ToTable("Client");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Subscription", b =>
            {
                b.Property<int>("IdSubscription")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("RenewalPeriod")
                    .HasColumnType("int");

                b.Property<DateTime>("EndTime")
                    .HasColumnType("datetime2");

                b.Property<float>("Price")
                    .HasColumnType("real");

                b.HasKey("IdSubscription");

                b.ToTable("Subscription");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Sale", b =>
            {
                b.Property<int>("IdSale")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("IdClient")
                    .HasColumnType("int");

                b.Property<int>("IdSubscription")
                    .HasColumnType("int");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("datetime2");

                b.HasKey("IdSale");

                b.HasIndex("IdClient");

                b.HasIndex("IdSubscription");

                b.ToTable("Sale");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Payment", b =>
            {
                b.Property<int>("IdPayment")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<int>("IdClient")
                    .HasColumnType("int");

                b.Property<int>("IdSubscription")
                    .HasColumnType("int");

                b.HasKey("IdPayment");

                b.HasIndex("IdClient");

                b.HasIndex("IdSubscription");

                b.ToTable("Payment");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Discount", b =>
            {
                b.Property<int>("IdDiscount")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("Value")
                    .HasColumnType("int");

                b.Property<int>("IdSubscription")
                    .HasColumnType("int");

                b.Property<DateTime>("DateFrom")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DateTo")
                    .HasColumnType("datetime2");

                b.HasKey("IdDiscount");

                b.HasIndex("IdSubscription");

                b.ToTable("Discount");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Sale", b =>
            {
                b.HasOne("KolokwiumAPBD.Models.Client", "IdClientNavigation")
                    .WithMany("Sales")
                    .HasForeignKey("IdClient")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("KolokwiumAPBD.Models.Subscription", "IdSubscriptionNavigation")
                    .WithMany("Sales")
                    .HasForeignKey("IdSubscription")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("IdClientNavigation");

                b.Navigation("IdSubscriptionNavigation");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Payment", b =>
            {
                b.HasOne("KolokwiumAPBD.Models.Client", "IdClientNavigation")
                    .WithMany("Payments")
                    .HasForeignKey("IdClient")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("KolokwiumAPBD.Models.Subscription", "IdSubscriptionNavigation")
                    .WithMany("Payments")
                    .HasForeignKey("IdSubscription")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("IdClientNavigation");

                b.Navigation("IdSubscriptionNavigation");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Discount", b =>
            {
                b.HasOne("KolokwiumAPBD.Models.Subscription", "IdSubscriptionNavigation")
                    .WithMany("Discounts")
                    .HasForeignKey("IdSubscription")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("IdSubscriptionNavigation");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Client", b =>
            {
                b.Navigation("Payments");

                b.Navigation("Sales");
            });

            modelBuilder.Entity("KolokwiumAPBD.Models.Subscription", b =>
            {
                b.Navigation("Discounts");

                b.Navigation("Payments");

                b.Navigation("Sales");
            });
        }
    }
}
