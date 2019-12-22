using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ogrenciyimProje.Data.Migrations
{
    public partial class Sorular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sorular",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(nullable: true),
                    Soru = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorular", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sorular");
        }
    }
}
