﻿// <auto-generated />
using System;
using CoronaTest.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoronaTest.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210415210851_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CampaignTestCenter", b =>
                {
                    b.Property<int>("AvailableInCampaignsId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableTestCentersId")
                        .HasColumnType("int");

                    b.HasKey("AvailableInCampaignsId", "AvailableTestCentersId");

                    b.HasIndex("AvailableTestCentersId");

                    b.ToTable("CampaignTestCenter");

                    b.HasData(
                        new
                        {
                            AvailableInCampaignsId = 1,
                            AvailableTestCentersId = 1
                        },
                        new
                        {
                            AvailableInCampaignsId = 1,
                            AvailableTestCentersId = 2
                        },
                        new
                        {
                            AvailableInCampaignsId = 1,
                            AvailableTestCentersId = 3
                        });
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Examinations")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Campaign");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Examinations = 0,
                            From = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Test-Kampagne",
                            To = new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Burgenland)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Kärnten)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Niederösterreich)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Oberösterreich)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Salzburg)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Steiermark)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Tirol)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Vorarlberg)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Examinations = 0,
                            From = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Antigentest Bildungsbereich (Wien)",
                            To = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExaminationAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("TestCenterId")
                        .HasColumnType("int");

                    b.Property<int>("TestResult")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("TestCenterId");

                    b.ToTable("Examination");
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Door")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobilenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.TestCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SlotCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestCenter");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Leonding",
                            Name = "Sporthalle Leonding",
                            Postcode = "4060",
                            SlotCapacity = 5,
                            Street = "Ehrenfellnerstraße 9"
                        },
                        new
                        {
                            Id = 2,
                            City = "Marchtrenk",
                            Name = "Kulturzentrum Marchtrenk",
                            Postcode = "4614",
                            SlotCapacity = 3,
                            Street = "Rennerstraße 7"
                        },
                        new
                        {
                            Id = 3,
                            City = "Linz",
                            Name = "Design Center Linz",
                            Postcode = "4020",
                            SlotCapacity = 10,
                            Street = "Europaplatz 1"
                        });
                });

            modelBuilder.Entity("CoronaTest.Core.Models.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@htl.at",
                            Password = "8fQgn1AJCwg5/jnumGJoT++BNr0cG6N0J/2aEZeJtE8=d09210e3d0eac14f08cdd4d7c6ba7c06"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@htl.at",
                            Password = "agoPwYdSFUmQ5RPCZCUCoASW8eVnK4iTN8SPOze41fE=3046c0ca459b645343db8e0258425706"
                        });
                });

            modelBuilder.Entity("CoronaTest.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("CoronaTest.Core.Models.VerificationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("Identifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsInvalidated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Token")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("VerificationTokens");
                });

            modelBuilder.Entity("CampaignTestCenter", b =>
                {
                    b.HasOne("CoronaTest.Core.Entities.Campaign", null)
                        .WithMany()
                        .HasForeignKey("AvailableInCampaignsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoronaTest.Core.Entities.TestCenter", null)
                        .WithMany()
                        .HasForeignKey("AvailableTestCentersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.Examination", b =>
                {
                    b.HasOne("CoronaTest.Core.Entities.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.HasOne("CoronaTest.Core.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");

                    b.HasOne("CoronaTest.Core.Entities.TestCenter", "TestCenter")
                        .WithMany()
                        .HasForeignKey("TestCenterId");

                    b.Navigation("Campaign");

                    b.Navigation("Participant");

                    b.Navigation("TestCenter");
                });

            modelBuilder.Entity("CoronaTest.Core.Models.VerificationToken", b =>
                {
                    b.HasOne("CoronaTest.Core.Entities.Participant", "Participant")
                        .WithMany("Verifications")
                        .HasForeignKey("ParticipantId");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("CoronaTest.Core.Entities.Participant", b =>
                {
                    b.Navigation("Verifications");
                });
#pragma warning restore 612, 618
        }
    }
}
