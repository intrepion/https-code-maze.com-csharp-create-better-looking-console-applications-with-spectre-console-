﻿// <auto-generated />
using System;
using HostelStudents.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HostelStudents.BusinessLogic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125224157_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetRolesHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetRoleClaimsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetUsersHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetUserClaimsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetUserLoginsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetUserRolesHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("AspNetUserTokens", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AspNetUserTokensHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Hostel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("Hostels", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HostelsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HostelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("HostelId");

                    b.ToTable("Students", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("StudentsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoleClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUsers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.Student", "Student")
                        .WithOne("ApplicationUser")
                        .HasForeignKey("HostelStudents.BusinessLogic.Entities.ApplicationUser", "StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserLogins")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserTokens")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Hostel", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedHostels")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Student", b =>
                {
                    b.HasOne("HostelStudents.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedStudents")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HostelStudents.BusinessLogic.Entities.Hostel", "Hostel")
                        .WithMany("Students")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("UpdatedApplicationRoleClaims");

                    b.Navigation("UpdatedApplicationRoles");

                    b.Navigation("UpdatedApplicationUserClaims");

                    b.Navigation("UpdatedApplicationUserLogins");

                    b.Navigation("UpdatedApplicationUserRoles");

                    b.Navigation("UpdatedApplicationUserTokens");

                    b.Navigation("UpdatedApplicationUsers");

                    b.Navigation("UpdatedHostels");

                    b.Navigation("UpdatedStudents");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Hostel", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("HostelStudents.BusinessLogic.Entities.Student", b =>
                {
                    b.Navigation("ApplicationUser");
                });
#pragma warning restore 612, 618
        }
    }
}
