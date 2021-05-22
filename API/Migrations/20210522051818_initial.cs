using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseLibrary.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplaintDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(maxLength: 500, nullable: false),
                    Area = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComplaintDetails",
                columns: new[] { "Id", "Area", "City", "ContactNumber", "CreatedDate", "EmailAddress", "IssueDescription", "LastModifiedDate", "Title" },
                values: new object[] { new Guid("e788a3bc-0841-4bba-a819-2df8e2a5775d"), "Swargate", "Pune", "", new DateTime(2021, 5, 22, 5, 18, 17, 989, DateTimeKind.Utc).AddTicks(9681), "ab123@gmail.com", "Since Last Four Days we are since Network Range Issues in Area. Please can you resolve asap", new DateTime(2021, 5, 22, 10, 48, 17, 990, DateTimeKind.Local).AddTicks(797), "Internet Range Issue" });

            migrationBuilder.InsertData(
                table: "ComplaintDetails",
                columns: new[] { "Id", "Area", "City", "ContactNumber", "CreatedDate", "EmailAddress", "IssueDescription", "LastModifiedDate", "Title" },
                values: new object[] { new Guid("4556c7c8-5cf8-4c9b-98a9-a7fb6083bd11"), "Magarpatta", "Pune", "", new DateTime(2021, 5, 22, 5, 18, 17, 992, DateTimeKind.Utc).AddTicks(8062), "ab123@gmail.com", "Increase in Call Drop Since Last Few Days", new DateTime(2021, 5, 22, 10, 48, 17, 992, DateTimeKind.Local).AddTicks(8094), "Call Drop Issue" });

            migrationBuilder.InsertData(
                table: "ComplaintDetails",
                columns: new[] { "Id", "Area", "City", "ContactNumber", "CreatedDate", "EmailAddress", "IssueDescription", "LastModifiedDate", "Title" },
                values: new object[] { new Guid("9fb1f08d-1c03-49da-be11-e90c443e5ffc"), "Magarpatta", "Pune", "", new DateTime(2021, 5, 22, 5, 18, 17, 992, DateTimeKind.Utc).AddTicks(8202), "231abc@gmail.com", "Increase in Call Drop Since Last Few Days", new DateTime(2021, 5, 22, 10, 48, 17, 992, DateTimeKind.Local).AddTicks(8204), "Call Drop Issue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintDetails");
        }
    }
}
