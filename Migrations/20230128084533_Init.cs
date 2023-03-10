using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPnetWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LoginNameUppercase = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PairRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PairedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    RatingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PairRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Knowledge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchStatus = table.Column<bool>(type: "bit", nullable: false),
                    MentorSearchStatus = table.Column<bool>(type: "bit", nullable: false),
                    MentorStatus = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProfile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PairRecords_UserId",
                table: "PairRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginNameUppercase",
                table: "Users",
                column: "LoginNameUppercase",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfile_UserId",
                table: "UsersProfile",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PairRecords");

            migrationBuilder.DropTable(
                name: "UsersProfile");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
