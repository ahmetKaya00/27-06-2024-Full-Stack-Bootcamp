using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBTechcareer.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEgitmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.EgitmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_BootcampId",
                table: "KursKayitlari",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Bootcamps_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId",
                principalTable: "Egitmenler",
                principalColumn: "EgitmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Bootcamps_BootcampId",
                table: "KursKayitlari",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "BootcampId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Bootcamps_BootcampId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropTable(
                name: "Egitmenler");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_BootcampId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_Bootcamps_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.DropColumn(
                name: "EgitmenId",
                table: "Bootcamps");
        }
    }
}
