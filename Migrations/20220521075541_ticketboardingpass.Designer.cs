﻿// <auto-generated />
using System;
using Fizzy_Airline.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fizzy_Airline.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220521075541_ticketboardingpass")]
    partial class ticketboardingpass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fizzy_Airline.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "Airbus",
                            Model = "Airbus A350-1000",
                            NumberOfSeats = 3
                        },
                        new
                        {
                            Id = 2,
                            Manufacturer = "Antonov",
                            Model = "Antonov AN-124 Ruslan",
                            NumberOfSeats = 3
                        });
                });

            modelBuilder.Entity("Fizzy_Airline.Models.BoardingPass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Flight_id")
                        .HasColumnType("int");

                    b.Property<bool>("HasBoarded")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCheckedIn")
                        .HasColumnType("bit");

                    b.Property<bool>("Luggage")
                        .HasColumnType("bit");

                    b.Property<int>("Passenger_id")
                        .HasColumnType("int");

                    b.Property<int>("Ticket_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Flight_id");

                    b.ToTable("BoardingPass");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Airplane_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ArrivedAtDestination")
                        .HasColumnType("bit");

                    b.Property<int>("ArrivingAtId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Departed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstFlightAttendantId")
                        .HasColumnType("int");

                    b.Property<int>("FirstPilotId")
                        .HasColumnType("int");

                    b.Property<int>("GoingFromId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SecondFlightAttendantId")
                        .HasColumnType("int");

                    b.Property<int>("SecondPilotId")
                        .HasColumnType("int");

                    b.Property<int?>("ThirdFlightAttendantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Airplane_Id");

                    b.HasIndex("ArrivingAtId");

                    b.HasIndex("FirstFlightAttendantId");

                    b.HasIndex("FirstPilotId");

                    b.HasIndex("GoingFromId");

                    b.HasIndex("SecondFlightAttendantId");

                    b.HasIndex("SecondPilotId");

                    b.HasIndex("ThirdFlightAttendantId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Airplane_Id = 1,
                            ArrivalDate = new DateTime(2022, 5, 22, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(8732),
                            ArrivedAtDestination = false,
                            ArrivingAtId = 2,
                            CreatedAt = new DateTime(2022, 5, 21, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(9972),
                            CreatedBy = "Fisayo.Adegun",
                            Departed = false,
                            DepartureDate = new DateTime(2022, 5, 21, 8, 55, 41, 154, DateTimeKind.Local).AddTicks(2258),
                            FirstFlightAttendantId = 1,
                            FirstPilotId = 1,
                            GoingFromId = 1,
                            Price = 107500.0,
                            SecondFlightAttendantId = 2,
                            SecondPilotId = 2,
                            ThirdFlightAttendantId = 4
                        });
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Flight_Attendant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Flight_Attendants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactNumber = "87368396",
                            Designation = "test",
                            FirstName = "Busola",
                            LastName = "Adegun"
                        },
                        new
                        {
                            Id = 2,
                            ContactNumber = "87368347396",
                            Designation = "test",
                            FirstName = "Tope",
                            LastName = "Fajuyi"
                        },
                        new
                        {
                            Id = 3,
                            ContactNumber = "0737373",
                            Designation = "test",
                            FirstName = "Shade",
                            LastName = "Francis"
                        },
                        new
                        {
                            Id = 4,
                            ContactNumber = "6453353",
                            Designation = "test",
                            FirstName = "Ola",
                            LastName = "John"
                        });
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationName = "Lagos"
                        },
                        new
                        {
                            Id = 2,
                            LocationName = "Enugu"
                        },
                        new
                        {
                            Id = 3,
                            LocationName = "Abuja"
                        });
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PilotLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pilots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactNumber = "07069482433",
                            Designation = "test",
                            FirstName = "Wale",
                            LastName = "Akinyemi",
                            PilotLicense = "test"
                        },
                        new
                        {
                            Id = 2,
                            ContactNumber = "84387936",
                            Designation = "test",
                            FirstName = "Fisayo",
                            LastName = "Emma",
                            PilotLicense = "test"
                        });
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ArrivingAtId")
                        .HasColumnType("int");

                    b.Property<string>("BookingReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Flight_id")
                        .HasColumnType("int");

                    b.Property<int>("GoingFromId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("Passenger_id")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArrivingAtId");

                    b.HasIndex("Flight_id");

                    b.HasIndex("GoingFromId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Account", b =>
                {
                    b.OwnsMany("Fizzy_Airline.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.BoardingPass", b =>
                {
                    b.HasOne("Fizzy_Airline.Models.Flight", "Flight")
                        .WithMany("BoardingPasses")
                        .HasForeignKey("Flight_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Flight", b =>
                {
                    b.HasOne("Fizzy_Airline.Models.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("Airplane_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Location", "ArrivingAt")
                        .WithMany()
                        .HasForeignKey("ArrivingAtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Flight_Attendant", "FirstFlightAttendant")
                        .WithMany()
                        .HasForeignKey("FirstFlightAttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Pilot", "FirstPilot")
                        .WithMany()
                        .HasForeignKey("FirstPilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Location", "GoingFrom")
                        .WithMany()
                        .HasForeignKey("GoingFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Flight_Attendant", "SecondFlightAttendant")
                        .WithMany()
                        .HasForeignKey("SecondFlightAttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Pilot", "SecondPilot")
                        .WithMany()
                        .HasForeignKey("SecondPilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Flight_Attendant", "ThirdFlightAttendant")
                        .WithMany()
                        .HasForeignKey("ThirdFlightAttendantId");

                    b.Navigation("Airplane");

                    b.Navigation("ArrivingAt");

                    b.Navigation("FirstFlightAttendant");

                    b.Navigation("FirstPilot");

                    b.Navigation("GoingFrom");

                    b.Navigation("SecondFlightAttendant");

                    b.Navigation("SecondPilot");

                    b.Navigation("ThirdFlightAttendant");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Ticket", b =>
                {
                    b.HasOne("Fizzy_Airline.Models.Location", "ArrivingAt")
                        .WithMany()
                        .HasForeignKey("ArrivingAtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("Flight_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fizzy_Airline.Models.Location", "GoingFrom")
                        .WithMany()
                        .HasForeignKey("GoingFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivingAt");

                    b.Navigation("Flight");

                    b.Navigation("GoingFrom");
                });

            modelBuilder.Entity("Fizzy_Airline.Models.Flight", b =>
                {
                    b.Navigation("BoardingPasses");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
