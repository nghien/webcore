﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCore.EntityFramework.Data;

namespace WebCore.EntityFramework.Migrations
{
    [DbContext(typeof(WebCoreDbContext))]
    [Migration("20181202064819_AddIconMenu")]
    partial class AddIconMenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCore.Entities.AdminMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Icon");

                    b.Property<string>("Link");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentMenuId");

                    b.Property<string>("Permission");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.ToTable("AdminMenus");
                });

            modelBuilder.Entity("WebCore.Entities.AppMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("MenuIcon");

                    b.Property<string>("MenuName");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ParentId");

                    b.Property<string>("Permission");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.ToTable("AppMenus");
                });

            modelBuilder.Entity("WebCore.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("LangCode")
                        .HasMaxLength(100);

                    b.Property<string>("LangName")
                        .HasMaxLength(500);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("WebCore.Entities.LanguageDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("LanguageCode");

                    b.Property<string>("LanguageKey");

                    b.Property<string>("LanguageValue");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.ToTable("LanguageDetails");
                });

            modelBuilder.Entity("WebCore.Entities.SystemConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Key");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.Property<decimal>("ValueNumber");

                    b.Property<string>("ValueString");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("WebCoreRoles");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("WebCoreRoleClaims");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Carrer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Contract");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("JobTitle");

                    b.Property<DateTime?>("JoinDate");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<long?>("RecordStatus");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<Guid?>("UpdateToken");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("WebCoreUsers");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WebCoreUserClaims");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Id");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("WebCoreUserLogins");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Id");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("WebCoreUserRoles");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Id");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("RecordStatus");

                    b.Property<Guid?>("UpdateToken");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreRoleClaim", b =>
                {
                    b.HasOne("WebCore.Entities.WebCoreRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserClaim", b =>
                {
                    b.HasOne("WebCore.Entities.WebCoreUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserLogin", b =>
                {
                    b.HasOne("WebCore.Entities.WebCoreUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserRole", b =>
                {
                    b.HasOne("WebCore.Entities.WebCoreRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebCore.Entities.WebCoreUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebCore.Entities.WebCoreUserToken", b =>
                {
                    b.HasOne("WebCore.Entities.WebCoreUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
