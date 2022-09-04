using System;
using System.Collections.Generic;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental.Repository
{
    public partial class carrentaldbContext : DbContext
    {
        public carrentaldbContext()
        {
        }

        public carrentaldbContext(DbContextOptions<carrentaldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Carimage> Carimages { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Creditcard> Creditcards { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Findek> Findeks { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=carrentaldb;uid=root;pwd=1234", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BrandsName).HasMaxLength(45);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ColorId, e.BrandId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("cars");

                entity.HasIndex(e => e.BrandId, "BrandId_idx");

                entity.HasIndex(e => e.ColorId, "ColorId_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Plaka).HasMaxLength(45);

                entity.Property(e => e.DailyPrice).HasPrecision(25);

                entity.Property(e => e.FindexScore).HasMaxLength(45);

                entity.Property(e => e.ModelYear).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BrandId");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ColorId");
            });

            modelBuilder.Entity<Carimage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CarId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("carimages");

                entity.HasIndex(e => e.CarId, "CarId_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).HasMaxLength(45);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Carimages)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CarId");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ColorName).HasMaxLength(45);
            });

            modelBuilder.Entity<Creditcard>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UsersId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("creditcards");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UsersId, "fk_CreditCards_Users1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.CardCvc).HasMaxLength(45);

                entity.Property(e => e.CardExpiration).HasColumnType("mediumtext");

                entity.Property(e => e.CardName).HasMaxLength(55);

                entity.Property(e => e.CardNumber).HasMaxLength(55);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Creditcards)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CreditCards_Users1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("customers");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UserId_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyName).HasMaxLength(45);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserId");
            });

            modelBuilder.Entity<Findek>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CustomerId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("findeks");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "fk_Findeks_Customers1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Score).HasMaxLength(45);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Findeks)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CusomerId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CustomersId, e.CreditCardsId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("payments");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CreditCardsId, "fk_Payments_CreditCards1_idx");

                entity.HasIndex(e => e.CustomersId, "fk_Payments_Customers1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomersId).HasColumnName("Customers_Id");

                entity.Property(e => e.CreditCardsId).HasColumnName("CreditCards_Id");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreditCards)
                    .WithMany(p => p.Payments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CreditCardsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Payments_CreditCards1");

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Payments)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CustomersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Payments_Customers1");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CustomerId, e.CarsId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("rentals");

                entity.HasIndex(e => e.CustomerId, "CustomerId_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CarsId, "fk_Rentals_Cars1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CarsId).HasColumnName("Cars_Id");

                entity.Property(e => e.RentDate).HasColumnType("datetime");

                entity.Property(e => e.RetumDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cars)
                    .WithMany(p => p.Rentals)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CarsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rentals_Cars1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rentals)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(55);

                entity.Property(e => e.FirstName).HasMaxLength(45);

                entity.Property(e => e.LastName).HasMaxLength(45);

                entity.Property(e => e.PasswordHash).HasMaxLength(45);

                entity.Property(e => e.PasswordSalt).HasMaxLength(45);

                entity.Property(e => e.Status).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
