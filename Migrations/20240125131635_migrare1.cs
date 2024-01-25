using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examen.Migrations
{
    /// <inheritdoc />
    public partial class migrare1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materii",
                columns: table => new
                {
                    MaterieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materii", x => x.MaterieId);
                });

            migrationBuilder.CreateTable(
                name: "Profesori",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesori", x => x.ProfesorId);
                });

            migrationBuilder.CreateTable(
                name: "ProfesoriMaterii",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    MaterieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesoriMaterii", x => new { x.ProfesorId, x.MaterieId });
                    table.ForeignKey(
                        name: "FK_ProfesoriMaterii_Materii_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materii",
                        principalColumn: "MaterieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesoriMaterii_Profesori_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesori",
                        principalColumn: "ProfesorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoriMaterii_MaterieId",
                table: "ProfesoriMaterii",
                column: "MaterieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesoriMaterii");

            migrationBuilder.DropTable(
                name: "Materii");

            migrationBuilder.DropTable(
                name: "Profesori");
        }
    }
}
