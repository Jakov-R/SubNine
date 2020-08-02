﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubNine.Data.Database;

namespace SubNine.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SubNine.Data.Entities.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubNine.Data.Entities.Athlete", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClubId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("CountryId");

                    b.ToTable("Athletes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ClubId = 1L,
                            CountryId = 1L,
                            DateOfBirth = new DateTimeOffset(new DateTime(1998, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Jakov",
                            Gender = "M",
                            LastName = "Raguž"
                        },
                        new
                        {
                            Id = 2L,
                            ClubId = 2L,
                            CountryId = 1L,
                            DateOfBirth = new DateTimeOffset(new DateTime(1999, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Martin",
                            Gender = "M",
                            LastName = "Poje"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "running"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "jumping"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CountryId = 1L,
                            Name = "Zagreb"
                        },
                        new
                        {
                            Id = 2L,
                            CountryId = 1L,
                            Name = "Split"
                        },
                        new
                        {
                            Id = 3L,
                            CountryId = 2L,
                            Name = "Mostar"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Club", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ShirtColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CityId = 1L,
                            Name = "AK Agram",
                            ShirtColor = "black"
                        },
                        new
                        {
                            Id = 2L,
                            CityId = 1L,
                            Name = "AK Dinamo-Zrinjevac",
                            ShirtColor = "blue"
                        },
                        new
                        {
                            Id = 3L,
                            CityId = 1L,
                            Name = "AK Zagreb",
                            ShirtColor = "blue/white"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Hrvatska"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Bosna i Hercegovina"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Discipline", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Name = "100m"
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 2L,
                            Name = "long jump"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Preliminary round"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Qualifications"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Heats"
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Participation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AthleteId")
                        .HasColumnType("bigint");

                    b.Property<long>("DisciplineId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EventId")
                        .HasColumnType("bigint");

                    b.Property<double>("Result")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("EventId");

                    b.ToTable("Participations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AthleteId = 1L,
                            DisciplineId = 1L,
                            EventId = 3L,
                            Result = 10.970000000000001
                        },
                        new
                        {
                            Id = 2L,
                            AthleteId = 1L,
                            DisciplineId = 2L,
                            EventId = 3L,
                            Result = 6.1100000000000003
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.RangList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AthleteId")
                        .HasColumnType("bigint");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("EventId");

                    b.ToTable("RangLists");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AthleteId = 1L,
                            EventId = 3L,
                            Place = 4
                        },
                        new
                        {
                            Id = 2L,
                            AthleteId = 1L,
                            EventId = 3L,
                            Place = 2
                        });
                });

            modelBuilder.Entity("SubNine.Data.Entities.Athlete", b =>
                {
                    b.HasOne("SubNine.Data.Entities.Club", "Club")
                        .WithMany("Athletes")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubNine.Data.Entities.Country", "Country")
                        .WithMany("Athletes")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("SubNine.Data.Entities.City", b =>
                {
                    b.HasOne("SubNine.Data.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubNine.Data.Entities.Club", b =>
                {
                    b.HasOne("SubNine.Data.Entities.City", "City")
                        .WithMany("Clubs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubNine.Data.Entities.Discipline", b =>
                {
                    b.HasOne("SubNine.Data.Entities.Category", "Category")
                        .WithMany("Disciplines")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubNine.Data.Entities.Participation", b =>
                {
                    b.HasOne("SubNine.Data.Entities.Athlete", "Athlete")
                        .WithMany("Participations")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubNine.Data.Entities.Discipline", "Discipline")
                        .WithMany("Participtions")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubNine.Data.Entities.Event", "Event")
                        .WithMany("Participations")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("SubNine.Data.Entities.RangList", b =>
                {
                    b.HasOne("SubNine.Data.Entities.Athlete", "Athlete")
                        .WithMany("RangLists")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubNine.Data.Entities.Event", "Event")
                        .WithMany("RangLists")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
