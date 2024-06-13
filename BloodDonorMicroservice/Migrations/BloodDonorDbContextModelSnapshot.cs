﻿// <auto-generated />
using System;
using BloodDonorMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodDonorMicroservice.Migrations
{
    [DbContext(typeof(BloodDonorDbContext))]
    partial class BloodDonorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodDonorMicroservice.Models.BloodDonorInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BloodDonorInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "2/1 - RC Road",
                            BloodGroup = "AB+",
                            City = "Maldah",
                            ContactNumber = "7002589633",
                            DateOfBrith = new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "jit",
                            LastName = "chatterjee"
                        },
                        new
                        {
                            Id = 2,
                            Address = "RBC road",
                            BloodGroup = "B+",
                            City = "Kolkata",
                            ContactNumber = "8475889658",
                            DateOfBrith = new DateTime(2004, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rahul",
                            LastName = "Ghosh"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2 CBN Lane",
                            BloodGroup = "O+",
                            City = "Kolkata",
                            ContactNumber = "7884536985",
                            DateOfBrith = new DateTime(1998, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ram",
                            LastName = "Das"
                        },
                        new
                        {
                            Id = 4,
                            Address = "33/87 ghosh para road",
                            BloodGroup = "A+",
                            City = "Bhatpara",
                            ContactNumber = "9874585652",
                            DateOfBrith = new DateTime(2001, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Shyam",
                            LastName = "Bardhan"
                        },
                        new
                        {
                            Id = 5,
                            Address = "2/1 - RC Road",
                            BloodGroup = "AB-",
                            City = "Naihati",
                            ContactNumber = "8966364587",
                            DateOfBrith = new DateTime(2002, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Soumya",
                            LastName = "Sen"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
