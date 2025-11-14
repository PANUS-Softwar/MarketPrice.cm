using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EFCore.CheckConstraints;
using System.Threading.Tasks;
using MarketPrice.Models;


namespace MarketPrice.Data
{

    internal class MarketPriceDbContext : DbContext
    {
        public DbSet<AccountType> AccountTypes{ get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<CommodityGroup> CommodityGroups { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<CommodityType> CommodityTypes { get; set; }
        public DbSet<VerificationType> VerificationTypes{ get; set; }


        public MarketPriceDbContext(DbContextOptions<MarketPriceDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // #1 User (1) -> Position (M)
            modelBuilder.Entity<Position>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            // #2: Position (1) -> DeliveryDetail (1)
            modelBuilder.Entity<Position>()
                .HasOne<DeliveryDetail>()
                .WithOne() 
                .HasForeignKey<DeliveryDetail>(dd => dd.PositionId)
                .IsRequired();

            // #3: User (1..M) <- Location (0..1) - Requires a collection property in Location, or a bridge table.
            modelBuilder.Entity<User>()
                .HasMany<Location>()
                .WithMany();

            // #5: Rating (1) -> User (M)
            modelBuilder.Entity<Rating>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.RatedUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Rating>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.RaterUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // #6: Verification (1) -> User (M)
            modelBuilder.Entity<Verification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .IsRequired();

            // #7: VerificationType (1..M) <- Verification (0..M)
            modelBuilder.Entity<Verification>()
                .HasOne<VerificationType>()
                .WithMany()
                .HasForeignKey(v => v.VerificationTypeId)
                .IsRequired();

            // #8: AccountType (1..M) <- User (1)
            modelBuilder.Entity<User>()
                .HasOne<AccountType>()
                .WithMany()
                .HasForeignKey(u => u.AccountTypeId)
                .IsRequired(); // AccountTypeId is required in the users table

            // #9: Position (1) <- Commodity (0..M)
            modelBuilder.Entity<Position>()
                .HasOne<Commodity>()
                .WithMany()
                .HasForeignKey(p => p.CommodityId)
                .IsRequired(); // Position is for a single commodity (NOT NULL)

            // #10: Commodity (1) <- CommodityType (1)
            modelBuilder.Entity<Commodity>()
                .HasOne<CommodityType>()
                .WithMany()
                .HasForeignKey(c => c.CommodityTypeId)
                .IsRequired();

            // #11: CommodityGroup (1..M) <- CommodityType (1)
            modelBuilder.Entity<CommodityType>()
                .HasOne<CommodityGroup>()
                .WithMany()
                .HasForeignKey(ct => ct.CommodityGroupId)
                .IsRequired();

            // #12: UnitOfMeasure (0..M) <- CommodityType (1)
            modelBuilder.Entity<CommodityType>()
                .HasOne<UnitOfMeasure>()
                .WithMany()
                .HasForeignKey(ct => ct.DefaultUnitOfMeasureId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // #13: UnitOfMeasure (0..M) <- Commodity (1)
            modelBuilder.Entity<Commodity>()
                .HasOne<UnitOfMeasure>()
                .WithMany()
                .HasForeignKey(c => c.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // #14: PositionType (0..M) <- Position (1)
            modelBuilder.Entity<Position>()
                .HasOne<PositionType>()
                .WithMany()
                .HasForeignKey(p => p.PositionTypeId)
                .IsRequired();

            // #15: LocationType (0..M) <- Location (1)
            modelBuilder.Entity<Location>()
                .HasOne<LocationType>()
                .WithMany()
                .HasForeignKey(l => l.LocationTypeId)
                .IsRequired();

            // // Inside OnModelCreating:

            // DELIVERY DETAIL PROPERTIES
            modelBuilder.Entity<DeliveryDetail>()
                .Property(dd => dd.Fee)
                .HasPrecision(18, 2); // Standard currency precision

            modelBuilder.Entity<DeliveryDetail>()
                .Property(dd => dd.MaxDistance)
                .HasPrecision(10, 2); // Example precision for distance (e.g., up to 99,999,999.99)

            // LOCATION PROPERTIES
            modelBuilder.Entity<Location>()
                .Property(l => l.Latitude)
                .HasPrecision(18, 10); // High precision for coordinates

            modelBuilder.Entity<Location>()
                .Property(l => l.Longitude)
                .HasPrecision(18, 10); // High precision for coordinates

            // POSITION PROPERTIES
            modelBuilder.Entity<Position>()
                .Property(p => p.Quantity)
                .HasPrecision(18, 4); // Example for product quantity (4 decimal places)

            modelBuilder.Entity<Position>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2); // Standard currency precision


            //// Enforce PositionType ('Bid' or 'Offer')
            //modelBuilder.Entity<PositionType>()
            //    .HasCheckConstraint("CHK_PositionTypes_PositionTypeName", "[PositionTypeName] IN (N'Bid', N'Offer')");

            //// Enforce Status ('Open', 'Closed', 'Cancelled')
            //modelBuilder.Entity<Position>()
            //    .HasCheckConstraint("CHK_Positions_Status", "[Status] IN (N'Opened', N'Closed', N'Cancelled')");

            // Enforce Uniqueness for Reusability on location components, a User will only be required to enter Quarter and Street info .
            modelBuilder.Entity<Location>()
                .HasIndex(l => new { l.Town, l.Region})
                .IsUnique();

            // RATINGS Constraints (Business Rules)
            // Enforce Score must be between 1 and 5
            modelBuilder.Entity<Rating>()
                .HasCheckConstraint("CHK_Ratings_Score", "[Score] BETWEEN 1 AND 5");

            // Enforce that a rater can only rate a rated user once 
            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.RatedUserId, r.RaterUserId });

            // Enforce Status check constraint for Verification
            //modelBuilder.Entity<Verification>()
            //    .HasCheckConstraint("CHK_Verifications_Status", "[Status] IN (N'Pending', N'Unverified', N'Redo', N'Verified', N'Rejected')");

            //// Enforce Status check constraint for Verification Type
            //modelBuilder.Entity<VerificationType>()
            //    .HasCheckConstraint("CHK_VerificationTypes_VerificationTypeName", "[VerificationTypeName] IN (N'IdCardNumber', N'Email', N'PhoneNumber')");


            // Enforce unique ID card number
            modelBuilder.Entity<User>()
                .HasIndex(u => u.IdCardNumber)
                .IsUnique();


        }

    }
} 
