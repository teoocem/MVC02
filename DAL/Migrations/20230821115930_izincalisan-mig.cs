using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class izincalisanmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_CalisanId",
                table: "Izinler",
                column: "CalisanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Calisanlar_CalisanId",
                table: "Izinler",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_Calisanlar_CalisanId",
                table: "Izinler");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_CalisanId",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Izinler");
        }
    }
}
