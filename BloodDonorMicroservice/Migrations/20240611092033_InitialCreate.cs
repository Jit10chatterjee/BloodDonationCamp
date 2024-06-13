using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDonorMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodDonorInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBrith = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonorInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BloodDonorInfos",
                columns: new[] { "Id", "Address", "BloodGroup", "City", "ContactNumber", "DateOfBrith", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "2/1 - RC Road", "AB+", "Maldah", "7002589633", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jit", "chatterjee" },
                    { 2, "RBC road", "B+", "Kolkata", "8475889658", new DateTime(2004, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rahul", "Ghosh" },
                    { 3, "2 CBN Lane", "O+", "Kolkata", "7884536985", new DateTime(1998, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ram", "Das" },
                    { 4, "33/87 ghosh para road", "A+", "Bhatpara", "9874585652", new DateTime(2001, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shyam", "Bardhan" },
                    { 5, "2/1 - RC Road", "AB-", "Naihati", "8966364587", new DateTime(2002, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soumya", "Sen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodDonorInfos");
        }
    }
}
