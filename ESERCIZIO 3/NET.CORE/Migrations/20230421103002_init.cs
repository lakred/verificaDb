using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET.CORE.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARTIST",
                columns: table => new
                {
                    Id_Artist = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTIST", x => x.Id_Artist);
                });

            migrationBuilder.CreateTable(
                name: "CHARACTER",
                columns: table => new
                {
                    ID_Character = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHARACTER", x => x.ID_Character);
                });

            migrationBuilder.CreateTable(
                name: "MUSEUM",
                columns: table => new
                {
                    Id_Museum = table.Column<int>(type: "int", nullable: false),
                    MuseumName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSEUM", x => x.Id_Museum);
                });

            migrationBuilder.CreateTable(
                name: "ARTWORK",
                columns: table => new
                {
                    ID_Artwork = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ID_Museum = table.Column<int>(type: "int", nullable: true),
                    ID_Artist = table.Column<int>(type: "int", nullable: true),
                    ID_Character = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTWORK", x => x.ID_Artwork);
                    table.ForeignKey(
                        name: "FK_ARTWORK_Arti",
                        column: x => x.ID_Artist,
                        principalTable: "ARTIST",
                        principalColumn: "Id_Artist");
                    table.ForeignKey(
                        name: "FK_ARTWORK_Char",
                        column: x => x.ID_Character,
                        principalTable: "CHARACTER",
                        principalColumn: "ID_Character");
                    table.ForeignKey(
                        name: "FK_ARTWORK_Mus",
                        column: x => x.ID_Museum,
                        principalTable: "MUSEUM",
                        principalColumn: "Id_Museum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARTWORK_ID_Artist",
                table: "ARTWORK",
                column: "ID_Artist");

            migrationBuilder.CreateIndex(
                name: "IX_ARTWORK_ID_Character",
                table: "ARTWORK",
                column: "ID_Character");

            migrationBuilder.CreateIndex(
                name: "IX_ARTWORK_ID_Museum",
                table: "ARTWORK",
                column: "ID_Museum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARTWORK");

            migrationBuilder.DropTable(
                name: "ARTIST");

            migrationBuilder.DropTable(
                name: "CHARACTER");

            migrationBuilder.DropTable(
                name: "MUSEUM");
        }
    }
}
