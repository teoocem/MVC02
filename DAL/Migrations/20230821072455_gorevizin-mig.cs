using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class gorevizinmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanGorev_Calisanlar_StandartCalisanId",
                table: "CalisanGorev");

            migrationBuilder.DropForeignKey(
                name: "FK_İzinTalepleri_Calisanlar_StandartCalisanId",
                table: "İzinTalepleri");

            migrationBuilder.RenameColumn(
                name: "StandartCalisanId",
                table: "İzinTalepleri",
                newName: "CalisanId");

            migrationBuilder.RenameIndex(
                name: "IX_İzinTalepleri_StandartCalisanId",
                table: "İzinTalepleri",
                newName: "IX_İzinTalepleri_CalisanId");

            migrationBuilder.RenameColumn(
                name: "StandartCalisanId",
                table: "CalisanGorev",
                newName: "CalisanId");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanGorev_StandartCalisanId",
                table: "CalisanGorev",
                newName: "IX_CalisanGorev_CalisanId");

            migrationBuilder.AddColumn<int>(
                name: "StandartCalisanCalisanId",
                table: "CalisanGorev",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalisanGorev_StandartCalisanCalisanId",
                table: "CalisanGorev",
                column: "StandartCalisanCalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanGorev_Calisanlar_CalisanId",
                table: "CalisanGorev",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanGorev_Calisanlar_StandartCalisanCalisanId",
                table: "CalisanGorev",
                column: "StandartCalisanCalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_İzinTalepleri_Calisanlar_CalisanId",
                table: "İzinTalepleri",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanGorev_Calisanlar_CalisanId",
                table: "CalisanGorev");

            migrationBuilder.DropForeignKey(
                name: "FK_CalisanGorev_Calisanlar_StandartCalisanCalisanId",
                table: "CalisanGorev");

            migrationBuilder.DropForeignKey(
                name: "FK_İzinTalepleri_Calisanlar_CalisanId",
                table: "İzinTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_CalisanGorev_StandartCalisanCalisanId",
                table: "CalisanGorev");

            migrationBuilder.DropColumn(
                name: "StandartCalisanCalisanId",
                table: "CalisanGorev");

            migrationBuilder.RenameColumn(
                name: "CalisanId",
                table: "İzinTalepleri",
                newName: "StandartCalisanId");

            migrationBuilder.RenameIndex(
                name: "IX_İzinTalepleri_CalisanId",
                table: "İzinTalepleri",
                newName: "IX_İzinTalepleri_StandartCalisanId");

            migrationBuilder.RenameColumn(
                name: "CalisanId",
                table: "CalisanGorev",
                newName: "StandartCalisanId");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanGorev_CalisanId",
                table: "CalisanGorev",
                newName: "IX_CalisanGorev_StandartCalisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanGorev_Calisanlar_StandartCalisanId",
                table: "CalisanGorev",
                column: "StandartCalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_İzinTalepleri_Calisanlar_StandartCalisanId",
                table: "İzinTalepleri",
                column: "StandartCalisanId",
                principalTable: "Calisanlar",
                principalColumn: "CalisanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
