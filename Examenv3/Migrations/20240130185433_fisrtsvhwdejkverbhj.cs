using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examenv3.Migrations
{
    /// <inheritdoc />
    public partial class fisrtsvhwdejkverbhj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanaleTV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaSediu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanaleTV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emisiuni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnulLansarii = table.Column<int>(type: "int", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanalTVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emisiuni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emisiuni_CanaleTV_CanalTVId",
                        column: x => x.CanalTVId,
                        principalTable: "CanaleTV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emisiuni_CanalTVId",
                table: "Emisiuni",
                column: "CanalTVId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emisiuni");

            migrationBuilder.DropTable(
                name: "CanaleTV");
        }
    }
}
