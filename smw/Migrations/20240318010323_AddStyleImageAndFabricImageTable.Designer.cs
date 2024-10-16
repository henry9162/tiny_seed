﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMW.Data;

#nullable disable

namespace SMW.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240318010323_AddStyleImageAndFabricImageTable")]
    partial class AddStyleImageAndFabricImageTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomRequestCustomRequestFabric", b =>
                {
                    b.Property<int>("CustomRequestFabricsId")
                        .HasColumnType("int");

                    b.Property<int>("CustomRequestsId")
                        .HasColumnType("int");

                    b.HasKey("CustomRequestFabricsId", "CustomRequestsId");

                    b.HasIndex("CustomRequestsId");

                    b.ToTable("CustomRequestCustomRequestFabric");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SMW.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LocalGovernmentId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LocalGovernmentId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SMW.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("EmailConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EmailConfirmedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OriginalImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordResetAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PasswordResetExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SMW.Models.CustomRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AdminComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DeliveryAmount")
                        .HasColumnType("float");

                    b.Property<double>("PickUpAmount")
                        .HasColumnType("float");

                    b.Property<bool>("ProvidedFabric")
                        .HasColumnType("bit");

                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeChartId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<string>("ThirdPartyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPartyFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPartySex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("SizeChartId")
                        .IsUnique();

                    b.HasIndex("StyleId");

                    b.HasIndex("UserId");

                    b.ToTable("CustomRequests");
                });

            modelBuilder.Entity("SMW.Models.CustomRequestFabric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("FabricId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FabricId");

                    b.ToTable("CustomRequestFabrics");
                });

            modelBuilder.Entity("SMW.Models.CustomRequestImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomRequestId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomRequestId");

                    b.ToTable("CustomRequestImage");
                });

            modelBuilder.Entity("SMW.Models.Fabric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FabricCategoryId");

                    b.ToTable("Fabrics");
                });

            modelBuilder.Entity("SMW.Models.FabricCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FabricCategories");
                });

            modelBuilder.Entity("SMW.Models.FabricImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FabricId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FabricId");

                    b.ToTable("FabricImage");
                });

            modelBuilder.Entity("SMW.Models.LocalGovernment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Local_Governments");
                });

            modelBuilder.Entity("SMW.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CustomRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GatewayRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomRequestId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SMW.Models.SizeChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnkleGirth")
                        .HasColumnType("int");

                    b.Property<int>("BackWaistLength")
                        .HasColumnType("int");

                    b.Property<int>("BackWidth")
                        .HasColumnType("int");

                    b.Property<int>("BicepsGirth")
                        .HasColumnType("int");

                    b.Property<int>("BodyHeight")
                        .HasColumnType("int");

                    b.Property<int>("BodyRise_F")
                        .HasColumnType("int");

                    b.Property<int>("BurstLength_F")
                        .HasColumnType("int");

                    b.Property<int>("BurstPointDistance_F")
                        .HasColumnType("int");

                    b.Property<int>("CalfGirth")
                        .HasColumnType("int");

                    b.Property<int>("ChestGirth")
                        .HasColumnType("int");

                    b.Property<int>("ChestWidth")
                        .HasColumnType("int");

                    b.Property<int>("ElbowLength")
                        .HasColumnType("int");

                    b.Property<int>("FrontLength_F")
                        .HasColumnType("int");

                    b.Property<int>("HeadGirth")
                        .HasColumnType("int");

                    b.Property<int>("HipGirth_F")
                        .HasColumnType("int");

                    b.Property<int>("Hipdepth_F")
                        .HasColumnType("int");

                    b.Property<int>("KneeBandGirth")
                        .HasColumnType("int");

                    b.Property<int>("KneeLength")
                        .HasColumnType("int");

                    b.Property<int>("LowerWaistGirth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NeckGirth")
                        .HasColumnType("int");

                    b.Property<int>("NeckWidth")
                        .HasColumnType("int");

                    b.Property<int>("ScyeDepth")
                        .HasColumnType("int");

                    b.Property<int>("ScyeWidth")
                        .HasColumnType("int");

                    b.Property<int>("ShoulderWidth")
                        .HasColumnType("int");

                    b.Property<int>("SideLength")
                        .HasColumnType("int");

                    b.Property<int>("SleeveLength")
                        .HasColumnType("int");

                    b.Property<int>("ThighGirth")
                        .HasColumnType("int");

                    b.Property<int>("UnderBurstGirth_F")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WaistGirth")
                        .HasColumnType("int");

                    b.Property<int>("WristGirth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("SizeCharts");
                });

            modelBuilder.Entity("SMW.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SMW.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Colors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricSet")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StyleCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StyleCategoryId");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("SMW.Models.StyleAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StyleAttributes");
                });

            modelBuilder.Entity("SMW.Models.StyleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StyleCategories");
                });

            modelBuilder.Entity("SMW.Models.StyleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StyleId");

                    b.ToTable("StyleImage");
                });

            modelBuilder.Entity("StyleStyleAttribute", b =>
                {
                    b.Property<int>("StyleAttributesId")
                        .HasColumnType("int");

                    b.Property<int>("StylesId")
                        .HasColumnType("int");

                    b.HasKey("StyleAttributesId", "StylesId");

                    b.HasIndex("StylesId");

                    b.ToTable("StyleStyleAttribute");
                });

            modelBuilder.Entity("CustomRequestCustomRequestFabric", b =>
                {
                    b.HasOne("SMW.Models.CustomRequestFabric", null)
                        .WithMany()
                        .HasForeignKey("CustomRequestFabricsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.CustomRequest", null)
                        .WithMany()
                        .HasForeignKey("CustomRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SMW.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SMW.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SMW.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SMW.Models.Address", b =>
                {
                    b.HasOne("SMW.Models.LocalGovernment", "LocalGovernment")
                        .WithMany()
                        .HasForeignKey("LocalGovernmentId");

                    b.HasOne("SMW.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.ApplicationUser", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");

                    b.Navigation("LocalGovernment");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMW.Models.CustomRequest", b =>
                {
                    b.HasOne("SMW.Models.Address", "Address")
                        .WithOne("CustomRequest")
                        .HasForeignKey("SMW.Models.CustomRequest", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.SizeChart", "SizeChart")
                        .WithOne("CustomRequest")
                        .HasForeignKey("SMW.Models.CustomRequest", "SizeChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.Style", "Style")
                        .WithMany("CustomRequests")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.ApplicationUser", "User")
                        .WithMany("CustomRequests")
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("SizeChart");

                    b.Navigation("Style");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMW.Models.CustomRequestFabric", b =>
                {
                    b.HasOne("SMW.Models.Fabric", "Fabric")
                        .WithMany("CustomRequestFabrics")
                        .HasForeignKey("FabricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabric");
                });

            modelBuilder.Entity("SMW.Models.CustomRequestImage", b =>
                {
                    b.HasOne("SMW.Models.CustomRequest", "CustomRequest")
                        .WithMany("CustomRequestImages")
                        .HasForeignKey("CustomRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomRequest");
                });

            modelBuilder.Entity("SMW.Models.Fabric", b =>
                {
                    b.HasOne("SMW.Models.FabricCategory", "FabricCategory")
                        .WithMany("Fabrics")
                        .HasForeignKey("FabricCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FabricCategory");
                });

            modelBuilder.Entity("SMW.Models.FabricImage", b =>
                {
                    b.HasOne("SMW.Models.Fabric", "Fabric")
                        .WithMany("FabricImages")
                        .HasForeignKey("FabricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabric");
                });

            modelBuilder.Entity("SMW.Models.LocalGovernment", b =>
                {
                    b.HasOne("SMW.Models.State", "State")
                        .WithMany("LocalGovernments")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("SMW.Models.Payment", b =>
                {
                    b.HasOne("SMW.Models.CustomRequest", "CustomRequest")
                        .WithOne("Payment")
                        .HasForeignKey("SMW.Models.Payment", "CustomRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.ApplicationUser", "User")
                        .WithMany("Payment")
                        .HasForeignKey("UserId");

                    b.Navigation("CustomRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMW.Models.SizeChart", b =>
                {
                    b.HasOne("SMW.Models.ApplicationUser", "User")
                        .WithOne("SizeChart")
                        .HasForeignKey("SMW.Models.SizeChart", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMW.Models.Style", b =>
                {
                    b.HasOne("SMW.Models.StyleCategory", "StyleCategory")
                        .WithMany("Styles")
                        .HasForeignKey("StyleCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StyleCategory");
                });

            modelBuilder.Entity("SMW.Models.StyleImage", b =>
                {
                    b.HasOne("SMW.Models.Style", "Style")
                        .WithMany("StyleImages")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Style");
                });

            modelBuilder.Entity("StyleStyleAttribute", b =>
                {
                    b.HasOne("SMW.Models.StyleAttribute", null)
                        .WithMany()
                        .HasForeignKey("StyleAttributesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMW.Models.Style", null)
                        .WithMany()
                        .HasForeignKey("StylesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SMW.Models.Address", b =>
                {
                    b.Navigation("CustomRequest");
                });

            modelBuilder.Entity("SMW.Models.ApplicationUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CustomRequests");

                    b.Navigation("Payment");

                    b.Navigation("SizeChart");
                });

            modelBuilder.Entity("SMW.Models.CustomRequest", b =>
                {
                    b.Navigation("CustomRequestImages");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("SMW.Models.Fabric", b =>
                {
                    b.Navigation("CustomRequestFabrics");

                    b.Navigation("FabricImages");
                });

            modelBuilder.Entity("SMW.Models.FabricCategory", b =>
                {
                    b.Navigation("Fabrics");
                });

            modelBuilder.Entity("SMW.Models.SizeChart", b =>
                {
                    b.Navigation("CustomRequest");
                });

            modelBuilder.Entity("SMW.Models.State", b =>
                {
                    b.Navigation("LocalGovernments");
                });

            modelBuilder.Entity("SMW.Models.Style", b =>
                {
                    b.Navigation("CustomRequests");

                    b.Navigation("StyleImages");
                });

            modelBuilder.Entity("SMW.Models.StyleCategory", b =>
                {
                    b.Navigation("Styles");
                });
#pragma warning restore 612, 618
        }
    }
}
