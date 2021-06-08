﻿// <auto-generated />
using System;
using DogShelter.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DogShelter.Migrations
{
    [DbContext(typeof(DogShelterDbContext))]
    partial class DogShelterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DogShelter.Auth.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConcurrencyStamp = "roleId",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("DogShelter.Model.Dog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShelterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ShelterId");

                    b.HasIndex("Age", "Breed")
                        .HasName("Age_Breed_Index");

                    b.ToTable("Dog");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 1,
                            Breed = "Jack Russel Terrier",
                            Name = "Zsuli",
                            ShelterId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Age = 14,
                            Breed = "Beagle",
                            Name = "Lulu",
                            OwnerId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Age = 1,
                            Breed = "Cuki",
                            Name = "Füge",
                            ShelterId = 2L
                        },
                        new
                        {
                            Id = 4L,
                            Age = 15,
                            Breed = "Valami",
                            Name = "Guszti",
                            OwnerId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            Age = 3,
                            Breed = "Beagle",
                            Name = "Fuli",
                            ShelterId = 1L
                        },
                        new
                        {
                            Id = 6L,
                            Age = 9,
                            Breed = "Beagle",
                            Name = "Macska",
                            OwnerId = 1L
                        },
                        new
                        {
                            Id = 7L,
                            Age = 1,
                            Breed = "Cuki",
                            Name = "Bodza",
                            ShelterId = 2L
                        },
                        new
                        {
                            Id = 8L,
                            Age = 15,
                            Breed = "Valami",
                            Name = "Gusztika",
                            OwnerId = 2L
                        },
                        new
                        {
                            Id = 9L,
                            Age = 1,
                            Breed = "Jack Russel Terrier",
                            Name = "Zsulike",
                            ShelterId = 1L
                        },
                        new
                        {
                            Id = 10L,
                            Age = 14,
                            Breed = "Beagle",
                            Name = "Luluka",
                            OwnerId = 1L
                        },
                        new
                        {
                            Id = 11L,
                            Age = 1,
                            Breed = "Cuki",
                            Name = "Fügcsi",
                            ShelterId = 2L
                        },
                        new
                        {
                            Id = 12L,
                            Age = 15,
                            Breed = "Valami",
                            Name = "Jani",
                            OwnerId = 2L
                        });
                });

            modelBuilder.Entity("DogShelter.Model.Shelter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Shelter");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Gödöllő",
                            Name = "Gödöllői menhely",
                            OwnerId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Szada",
                            Name = "Lelenc menhely",
                            OwnerId = 3L
                        });
                });

            modelBuilder.Entity("DogShelter.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8dc76956-948f-4f65-96d4-e52adc63f4d2",
                            Email = "akos@akos.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Ákos",
                            PasswordHash = "AQAAAAEAACcQAAAAEEv5EW7omdi69aZKbpHiddqy7Rk1KsrS1hdalbfZzJr96QHAuV7SMkU1I2+A3SlmzA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "akos@akos.com"
                        },
                        new
                        {
                            Id = 2L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "47f47b57-d1cd-42f0-9c6b-fa817f236df6",
                            Email = "dani@dani.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Dani",
                            PasswordHash = "AQAAAAEAACcQAAAAEKoK+4qPe8+ajpNSmxH0kPpUBZkc14tafVneUdiV+7q4Ri5ZS8N3cj5Ni3s4T0t9Xw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "dani@dani.com"
                        },
                        new
                        {
                            Id = 3L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05306314-ce34-45dd-b355-e1476a8ed731",
                            Email = "virag@virag.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Virág",
                            PasswordHash = "AQAAAAEAACcQAAAAEC974QNhEX8RMKTqo+kJPNN+JRlwCmk+iPqxyBzkROaH+rEwUqhNpQ1xLcbnbEyizQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "virag@virag.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            RoleId = 1L
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DogShelter.Model.Dog", b =>
                {
                    b.HasOne("DogShelter.Model.User", "Owner")
                        .WithMany("Dogs")
                        .HasForeignKey("OwnerId");

                    b.HasOne("DogShelter.Model.Shelter", "Shelter")
                        .WithMany("Dogs")
                        .HasForeignKey("ShelterId");
                });

            modelBuilder.Entity("DogShelter.Model.Shelter", b =>
                {
                    b.HasOne("DogShelter.Model.User", "Owner")
                        .WithMany("Shelters")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("DogShelter.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("DogShelter.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("DogShelter.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("DogShelter.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogShelter.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("DogShelter.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
