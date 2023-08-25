using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class tphmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmanAciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmanAktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    GorevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GörevBaşlığı = table.Column<string>(name: "Görev Başlığı", type: "nvarchar(max)", nullable: false),
                    GörevAçıklaması = table.Column<string>(name: "Görev Açıklaması", type: "nvarchar(max)", nullable: false),
                    OluşturulmaTarihi = table.Column<DateTime>(name: "Oluşturulma Tarihi", type: "datetime2", nullable: false),
                    TahminiBitişTarihi = table.Column<DateTime>(name: "Tahmini Bitiş Tarihi", type: "datetime2", nullable: false),
                    GörevDurumu = table.Column<bool>(name: "Görev Durumu", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.GorevId);
                });

            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    IzinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaşlangıçTarihi = table.Column<DateTime>(name: "Başlangıç Tarihi", type: "datetime2", nullable: false),
                    BitişTarihi = table.Column<DateTime>(name: "Bitiş Tarihi", type: "datetime2", nullable: false),
                    İzinAktif = table.Column<bool>(name: "İzin Aktif", type: "bit", nullable: false),
                    İzinTipi = table.Column<int>(name: "İzin Tipi", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.IzinId);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanYas = table.Column<int>(type: "int", nullable: false),
                    CalisanTcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanAktif = table.Column<bool>(type: "bit", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    CalisanTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaireBaskanId = table.Column<int>(type: "int", nullable: true),
                    DaireAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubeMuduru_AtanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.CalisanId);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalisanGorev",
                columns: table => new
                {
                    StandartCalisanId = table.Column<int>(type: "int", nullable: false),
                    GorevId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanGorev", x => new { x.GorevId, x.StandartCalisanId });
                    table.ForeignKey(
                        name: "FK_CalisanGorev_Calisanlar_StandartCalisanId",
                        column: x => x.StandartCalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanGorev_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "GorevId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İzinTalepleri",
                columns: table => new
                {
                    IzinTalepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TalepAsama = table.Column<int>(type: "int", nullable: false),
                    IzinAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandartCalisanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzinTalepleri", x => x.IzinTalepId);
                    table.ForeignKey(
                        name: "FK_İzinTalepleri_Calisanlar_StandartCalisanId",
                        column: x => x.StandartCalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_LoginInfo_Calisanlar_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanGorev_StandartCalisanId",
                table: "CalisanGorev",
                column: "StandartCalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_İzinTalepleri_StandartCalisanId",
                table: "İzinTalepleri",
                column: "StandartCalisanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginInfo_CalisanId",
                table: "LoginInfo",
                column: "CalisanId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanGorev");

            migrationBuilder.DropTable(
                name: "Izinler");

            migrationBuilder.DropTable(
                name: "İzinTalepleri");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "Departmanlar");
        }
    }
}
