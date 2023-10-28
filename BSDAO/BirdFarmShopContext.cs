using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class BirdFarmShopContext : DbContext
    {
        public BirdFarmShopContext()
        {
        }

        public BirdFarmShopContext(DbContextOptions<BirdFarmShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccounts { get; set; } = null!;
        public virtual DbSet<TbBird> TbBirds { get; set; } = null!;
        public virtual DbSet<TbBirdCategory> TbBirdCategories { get; set; } = null!;
        public virtual DbSet<TbCart> TbCarts { get; set; } = null!;
        public virtual DbSet<TbNest> TbNests { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        protected string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            return configuration.GetConnectionString("DBConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_tb_UserAccount");

                entity.ToTable("tb_Account");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.TbAccount)
                    .HasForeignKey<TbAccount>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_UserAccount_tb_User");
            });

            modelBuilder.Entity<TbBird>(entity =>
            {
                entity.HasKey(e => e.BirdId)
                    .HasName("PK_tb_BirdProduct");

                entity.ToTable("tb_Bird");

                entity.HasIndex(e => e.BirdSpeciesId, "IX_tb_Bird_bird_species_id");

                entity.Property(e => e.BirdId)
                    .HasMaxLength(50)
                    .HasColumnName("bird_id");

                entity.Property(e => e.BirdImage)
                    .HasMaxLength(100)
                    .HasColumnName("bird_image");

                entity.Property(e => e.BirdSpeciesId)
                    .HasMaxLength(50)
                    .HasColumnName("bird_species_id");

                entity.Property(e => e.BirthMonthYear)
                    .HasColumnType("date")
                    .HasColumnName("birth_month_year");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.OffspringAvailable).HasColumnName("offspring_available");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.StatusSold).HasColumnName("status_sold");

                entity.HasOne(d => d.BirdSpecies)
                    .WithMany(p => p.TbBirds)
                    .HasForeignKey(d => d.BirdSpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_BirdProduct_tb_BirdCategory");
            });

            modelBuilder.Entity<TbBirdCategory>(entity =>
            {
                entity.HasKey(e => e.BirdSpeciesId)
                    .HasName("PK_tb_birdCategory_1");

                entity.ToTable("tb_BirdCategory");

                entity.Property(e => e.BirdSpeciesId)
                    .HasMaxLength(50)
                    .HasColumnName("bird_species_id");

                entity.Property(e => e.BirdSpeciesName)
                    .HasMaxLength(50)
                    .HasColumnName("bird_species_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<TbCart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("tb_Cart");

                entity.HasIndex(e => e.UserId, "IX_tb_Cart_user_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Cart_tb_User");
            });

            modelBuilder.Entity<TbNest>(entity =>
            {
                entity.HasKey(e => e.NestId);

                entity.ToTable("tb_Nest");

                entity.HasIndex(e => e.BirdIdFemale, "IX_tb_Nest_bird_id_female");

                entity.HasIndex(e => e.BirdIdMale, "IX_tb_Nest_bird_id_male");

                entity.Property(e => e.NestId)
                    .HasMaxLength(50)
                    .HasColumnName("nest_id");

                entity.Property(e => e.BirdIdFemale)
                    .HasMaxLength(50)
                    .HasColumnName("bird_id_female");

                entity.Property(e => e.BirdIdMale)
                    .HasMaxLength(50)
                    .HasColumnName("bird_id_male");

                entity.Property(e => e.BirdImage)
                    .HasMaxLength(100)
                    .HasColumnName("bird_image");

                entity.Property(e => e.BirdSpecies)
                    .HasMaxLength(20)
                    .HasColumnName("bird_species");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.BirdIdFemaleNavigation)
                    .WithMany(p => p.TbNestBirdIdFemaleNavigations)
                    .HasForeignKey(d => d.BirdIdFemale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Nest_tb_Bird1");

                entity.HasOne(d => d.BirdIdMaleNavigation)
                    .WithMany(p => p.TbNestBirdIdMaleNavigations)
                    .HasForeignKey(d => d.BirdIdMale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Nest_tb_Bird");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_user");

                entity.ToTable("tb_User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBird)
                    .HasColumnType("date")
                    .HasColumnName("date_of_bird");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(30)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(10)
                    .HasColumnName("zipcode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
