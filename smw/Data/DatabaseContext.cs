using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SMW.Models;

namespace SMW.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<ApplicationUser>(b =>
        //     {
        //         // Each User can have many Addresses
        //         b.HasMany(e => e.Addresses)
        //             .WithOne()
        //             .HasForeignKey(uc => uc.ApplicationUserId)
        //             .IsRequired();
        //     });
        // }

        public DbSet<State> States {get; set;}
        public DbSet<LocalGovernment> Local_Governments {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<CustomRequest> CustomRequests { get; set; }
        public DbSet<CustomRequestImage> CustomRequestImages { get; set; }
        public DbSet<CustomRequestFabric> CustomRequestFabrics { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<FabricImage> FabricImages { get; set; }
        public DbSet<FabricCategory> FabricCategories { get; set; }
        public DbSet<FabricSubCategory> FabricSubCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SizeChart> SizeCharts { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<StyleAttribute> StyleAttributes { get; set; }
        public DbSet<StyleCategory> StyleCategories { get; set; }
        public DbSet<StyleSubCategory> StyleSubCategories { get; set; }
        public DbSet<StyleImage> StyleImages { get; set; }
    }
}