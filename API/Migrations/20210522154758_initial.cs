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
                values: new object[] { new Guid("db578f7a-1334-4abe-a0db-beddafd33190"), "Swargate", "Pune", "", new DateTime(2021, 5, 22, 15, 47, 58, 578, DateTimeKind.Utc).AddTicks(8183), "ab123@gmail.com", "Since Last Four Days we are since Network Range Issues in Area. Please can you resolve asap", new DateTime(2021, 5, 22, 21, 17, 58, 578, DateTimeKind.Local).AddTicks(9022), "Internet Range Issue" });

            migrationBuilder.InsertData(
                table: "ComplaintDetails",
                columns: new[] { "Id", "Area", "City", "ContactNumber", "CreatedDate", "EmailAddress", "IssueDescription", "LastModifiedDate", "Title" },
                values: new object[] { new Guid("3793561d-a485-499f-a034-dddfc2917fca"), "Magarpatta", "Pune", "", new DateTime(2021, 5, 22, 15, 47, 58, 581, DateTimeKind.Utc).AddTicks(5385), "ab123@gmail.com", "Increase in Call Drop Since Last Few Days", new DateTime(2021, 5, 22, 21, 17, 58, 581, DateTimeKind.Local).AddTicks(5404), "Call Drop Issue" });

            migrationBuilder.InsertData(
                table: "ComplaintDetails",
                columns: new[] { "Id", "Area", "City", "ContactNumber", "CreatedDate", "EmailAddress", "IssueDescription", "LastModifiedDate", "Title" },
                values: new object[] { new Guid("e7375cd1-b138-429e-95ae-be489c4a1ef4"), "Magarpatta", "Pune", "", new DateTime(2021, 5, 22, 15, 47, 58, 581, DateTimeKind.Utc).AddTicks(5462), "231abc@gmail.com", "Increase in Call Drop Since Last Few Days", new DateTime(2021, 5, 22, 21, 17, 58, 581, DateTimeKind.Local).AddTicks(5463), "Call Drop Issue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintDetails");
        }
    }
}
