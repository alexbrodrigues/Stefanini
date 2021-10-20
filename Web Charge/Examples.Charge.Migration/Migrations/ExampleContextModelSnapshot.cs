﻿// <auto-generated />
using System;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Examples.Charge.Infra.Data.Configuration.Migrations
{
    [DbContext(typeof(ExampleContext))]
    partial class ExampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.ExampleAggregate.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Example","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Example 1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Example 2"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Example 3"
                        });
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.PersonAggregate.Person", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BusinessEntityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("BusinessEntityID");

                    b.ToTable("Person","dbo");

                    b.HasData(
                        new
                        {
                            BusinessEntityID = 1,
                            Name = "User One"
                        });
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.PersonAggregate.PersonPhone", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .HasColumnName("BusinessEntityID");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("PhoneNumberTypeID")
                        .HasColumnName("PhoneNumberTypeID");

                    b.HasKey("BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID");

                    b.HasIndex("PhoneNumberTypeID");

                    b.ToTable("PersonPhone","dbo");

                    b.HasData(
                        new
                        {
                            BusinessEntityID = 1,
                            PhoneNumber = "(19)99999-2883",
                            PhoneNumberTypeID = 1
                        },
                        new
                        {
                            BusinessEntityID = 1,
                            PhoneNumber = "(19)99999-4021",
                            PhoneNumberTypeID = 2
                        });
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.PersonAggregate.PhoneNumberType", b =>
                {
                    b.Property<int>("PhoneNumberTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BusinessEntityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("PhoneNumberTypeID");

                    b.ToTable("PhoneNumberType","dbo");

                    b.HasData(
                        new
                        {
                            PhoneNumberTypeID = 1,
                            Name = "Local phone"
                        },
                        new
                        {
                            PhoneNumberTypeID = 2,
                            Name = "Cellphone"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.Identity.UserRole", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.User", "Usuario")
                        .WithMany("UserRoles")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Examples.Charge.Domain.Aggregates.PersonAggregate.PersonPhone", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.PersonAggregate.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("BusinessEntityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Examples.Charge.Domain.Aggregates.PersonAggregate.PhoneNumberType", "PhoneNumberType")
                        .WithMany()
                        .HasForeignKey("PhoneNumberTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Examples.Charge.Domain.Aggregates.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
