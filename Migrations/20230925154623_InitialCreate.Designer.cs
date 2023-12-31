﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    [DbContext(typeof(HillarysHairCareDbContext))]
    [Migration("20230925154623_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.Property<int>("AppointmentsId")
                        .HasColumnType("integer");

                    b.Property<int>("ServicesId")
                        .HasColumnType("integer");

                    b.HasKey("AppointmentsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("AppointmentService");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Date = new DateTime(2023, 9, 15, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 3
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentsServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 1
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Barry O'Bannon"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Michael O'Keefe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Billy Smalls"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mary O'Reilly"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Micah Swanson"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Women's Haircut",
                            Price = 30m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shampoo",
                            Price = 20m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Men's Haircut",
                            Price = 15m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Beard Trim",
                            Price = 5m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Razor Shave",
                            Price = 10m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hot Towel",
                            Price = 2m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Massage",
                            Price = 100m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pedicure",
                            Price = 35m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Manicure",
                            Price = 25m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Perm",
                            Price = 80m
                        },
                        new
                        {
                            Id = 11,
                            Name = "Color",
                            Price = 70m
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isEmployed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yvonne Peterson",
                            isEmployed = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "MichaelAnne Yarbrough",
                            isEmployed = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kimmy Sanderson",
                            isEmployed = true
                        },
                        new
                        {
                            Id = 4,
                            Name = "Adrian Wizniowski",
                            isEmployed = true
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pippa Vanderschnout",
                            isEmployed = true
                        });
                });

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillarysHairCare.Models.AppointmentService", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}
