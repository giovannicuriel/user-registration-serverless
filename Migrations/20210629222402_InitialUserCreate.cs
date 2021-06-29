using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace awscsharp.Migrations
{
    public partial class InitialUserCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "PersonDb",
                columns: table => new
                {
                    id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    rolecode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonDb_Role_rolecode",
                        column: x => x.rolecode,
                        principalTable: "Role",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonDb_rolecode",
                table: "PersonDb",
                column: "rolecode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonDb");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
