﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceLaunchTracker.Data;

namespace SpaceLaunchTracker.Migrations
{
    [DbContext(typeof(SpaceLaunchTrackerDbContext))]
    partial class SpaceLaunchTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpaceLaunchTracker.Data.DataModels.AgencyDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("InfoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("SpaceLaunchTracker.Data.DataModels.CountryDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SpaceLaunchTracker.Data.DataModels.LaunchDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("InfoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LaunchNumber")
                        .HasColumnType("int");

                    b.Property<string>("LaunchSite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MissionDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MissionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RocketName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("CountryId");

                    b.ToTable("Launches");
                });

            modelBuilder.Entity("SpaceLaunchTracker.Data.DataModels.AgencyDto", b =>
                {
                    b.HasOne("SpaceLaunchTracker.Data.DataModels.CountryDto", "Country")
                        .WithMany("Agencies")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("SpaceLaunchTracker.Data.DataModels.LaunchDto", b =>
                {
                    b.HasOne("SpaceLaunchTracker.Data.DataModels.AgencyDto", "Agency")
                        .WithMany("Launches")
                        .HasForeignKey("AgencyId");

                    b.HasOne("SpaceLaunchTracker.Data.DataModels.CountryDto", "Country")
                        .WithMany("Launches")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
