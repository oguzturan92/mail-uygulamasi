﻿// <auto-generated />
using System;
using Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ProjeContext))]
    [Migration("20240320101823_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entity.Concrete.Mail", b =>
                {
                    b.Property<int>("MailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MailId"), 1L, 1);

                    b.Property<string>("MailContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MailDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("MailDraft")
                        .HasColumnType("bit");

                    b.Property<bool>("MailImportant")
                        .HasColumnType("bit");

                    b.Property<int>("MailKimdenMailId")
                        .HasColumnType("int");

                    b.Property<string>("MailKimeMailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MailRead")
                        .HasColumnType("bit");

                    b.Property<string>("MailSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MailTrash")
                        .HasColumnType("bit");

                    b.HasKey("MailId");

                    b.ToTable("Mails");

                    b.HasData(
                        new
                        {
                            MailId = 1,
                            MailContent = "Gelen Mail içeriği 1",
                            MailDate = new DateTime(2024, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 1",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 2,
                            MailContent = "Gelen Mail içeriği 2",
                            MailDate = new DateTime(2024, 1, 2, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = false,
                            MailSubject = "Gelen Konu başlığı 2",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 3,
                            MailContent = "Gelen Mail içeriği 3",
                            MailDate = new DateTime(2024, 1, 3, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = false,
                            MailSubject = "Gelen Konu başlığı 3",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 4,
                            MailContent = "Gelen Mail içeriği 4",
                            MailDate = new DateTime(2024, 1, 4, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 4",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 5,
                            MailContent = "Gelen Mail içeriği 5",
                            MailDate = new DateTime(2024, 1, 5, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 5",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 6,
                            MailContent = "Gelen Mail içeriği 6",
                            MailDate = new DateTime(2024, 1, 6, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 6",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 7,
                            MailContent = "Gelen Mail içeriği 7",
                            MailDate = new DateTime(2024, 1, 7, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 7",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 8,
                            MailContent = "Gelen Mail içeriği 8",
                            MailDate = new DateTime(2024, 1, 8, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = false,
                            MailSubject = "Gelen Konu başlığı 8",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 9,
                            MailContent = "Gelen Mail içeriği 9",
                            MailDate = new DateTime(2024, 1, 9, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 9",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 10,
                            MailContent = "Gelen Mail içeriği 10",
                            MailDate = new DateTime(2024, 1, 10, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 10",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 11,
                            MailContent = "Gelen Mail içeriği 11",
                            MailDate = new DateTime(2024, 1, 11, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 11",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 12,
                            MailContent = "Gelen Mail içeriği 12",
                            MailDate = new DateTime(2024, 1, 12, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 12",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 13,
                            MailContent = "Gelen Mail içeriği 13",
                            MailDate = new DateTime(2024, 1, 13, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 3,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 13",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 14,
                            MailContent = "Gelen Mail içeriği 14",
                            MailDate = new DateTime(2024, 1, 14, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 14",
                            MailTrash = true
                        },
                        new
                        {
                            MailId = 15,
                            MailContent = "Gelen Mail içeriği 15",
                            MailDate = new DateTime(2024, 1, 15, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 2,
                            MailKimeMailName = "a@gmail.com",
                            MailRead = true,
                            MailSubject = "Gelen Konu başlığı 15",
                            MailTrash = true
                        },
                        new
                        {
                            MailId = 16,
                            MailContent = "Giden Mail içeriği 1",
                            MailDate = new DateTime(2024, 1, 8, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 1",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 17,
                            MailContent = "Giden Mail içeriği 2",
                            MailDate = new DateTime(2024, 1, 7, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 2",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 18,
                            MailContent = "Giden Mail içeriği 3",
                            MailDate = new DateTime(2024, 1, 1, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 3",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 19,
                            MailContent = "Giden Mail içeriği 4",
                            MailDate = new DateTime(2024, 1, 3, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 4",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 20,
                            MailContent = "Giden Mail içeriği 5",
                            MailDate = new DateTime(2024, 1, 6, 13, 38, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 5",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 21,
                            MailContent = "Giden Mail içeriği 6",
                            MailDate = new DateTime(2024, 1, 17, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 6",
                            MailTrash = true
                        },
                        new
                        {
                            MailId = 22,
                            MailContent = "Giden Mail içeriği 7",
                            MailDate = new DateTime(2024, 1, 14, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = true,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "Giden Konu başlığı 7",
                            MailTrash = false
                        },
                        new
                        {
                            MailId = 23,
                            MailContent = "Taslak içeriği 1",
                            MailDate = new DateTime(2024, 1, 15, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            MailDraft = false,
                            MailImportant = false,
                            MailKimdenMailId = 1,
                            MailKimeMailName = "b@gmail.com",
                            MailRead = true,
                            MailSubject = "",
                            MailTrash = false
                        });
                });

            modelBuilder.Entity("Entity.Concrete.ProjeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Entity.Concrete.ProjeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UserRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Entity.Concrete.ProjeRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Entity.Concrete.ProjeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Entity.Concrete.ProjeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Entity.Concrete.ProjeRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Concrete.ProjeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Entity.Concrete.ProjeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
