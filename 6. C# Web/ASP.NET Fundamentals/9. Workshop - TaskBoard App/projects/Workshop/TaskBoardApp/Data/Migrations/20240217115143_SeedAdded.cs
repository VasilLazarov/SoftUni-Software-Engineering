using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Board identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Board Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                },
                comment: "Boards");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Task title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of creation"),
                    BoardId = table.Column<int>(type: "int", nullable: true, comment: "Board identifier"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Application user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Board Tasks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e443ff8c-2610-49e1-a83b-fc80bf7df1c7", 0, "4027c022-d430-4a4e-8c98-c45d11e089ec", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEI9FuIN8y0/NSh1W8ItYxX9KTr5NbcNvsFUrCRDrD+589TcgWBqjNVBjxYm4rcpUeA==", null, false, "e7ffb5f8-e2a2-4997-af26-b0c146e41700", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 1, 13, 51, 43, 450, DateTimeKind.Local).AddTicks(3594), "Implement better styling for all public pages", "e443ff8c-2610-49e1-a83b-fc80bf7df1c7", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 17, 13, 51, 43, 450, DateTimeKind.Local).AddTicks(3637), "Create Android client app for the TaskBoard RESTful API", "e443ff8c-2610-49e1-a83b-fc80bf7df1c7", "Android Client App" },
                    { 3, 2, new DateTime(2023, 8, 1, 13, 51, 43, 450, DateTimeKind.Local).AddTicks(3643), "Implement better styling for all public pages", "e443ff8c-2610-49e1-a83b-fc80bf7df1c7", "Improve CSS styles" },
                    { 4, 3, new DateTime(2023, 8, 1, 13, 51, 43, 450, DateTimeKind.Local).AddTicks(3644), "Implement better styling for all public pages", "e443ff8c-2610-49e1-a83b-fc80bf7df1c7", "Improve CSS styles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e443ff8c-2610-49e1-a83b-fc80bf7df1c7");
        }
    }
}
