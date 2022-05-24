using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class entityInfoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Informaziones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 75, nullable: false),
                    Testo = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ViaggioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informaziones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informaziones_Viaggios_ViaggioId",
                        column: x => x.ViaggioId,
                        principalTable: "Viaggios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informaziones_ViaggioId",
                table: "Informaziones",
                column: "ViaggioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informaziones");
        }
    }
}
