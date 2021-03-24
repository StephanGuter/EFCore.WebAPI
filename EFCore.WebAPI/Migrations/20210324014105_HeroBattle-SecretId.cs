using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class HeroBattleSecretId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Battles_BattleId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_BattleId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Id_Hero",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "Dt_Init",
                table: "Battles",
                newName: "DtInit");

            migrationBuilder.RenameColumn(
                name: "Dt_End",
                table: "Battles",
                newName: "DtEnd");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HeroesBattles",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesBattles", x => new { x.BattleId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_HeroesBattles_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroesBattles_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    HeroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroesBattles_HeroId",
                table: "HeroesBattles",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_HeroId",
                table: "SecretIdentities",
                column: "HeroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "HeroesBattles");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.RenameColumn(
                name: "DtInit",
                table: "Battles",
                newName: "Dt_Init");

            migrationBuilder.RenameColumn(
                name: "DtEnd",
                table: "Battles",
                newName: "Dt_End");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Weapons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id_Hero",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Heroes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_BattleId",
                table: "Heroes",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Battles_BattleId",
                table: "Heroes",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
