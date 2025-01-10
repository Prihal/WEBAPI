using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI_REL2.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCatagories_Categorys_p_id",
                table: "PokemonCatagories");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCatagories_c_id",
                table: "PokemonCatagories",
                column: "c_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCatagories_Categorys_c_id",
                table: "PokemonCatagories",
                column: "c_id",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCatagories_Categorys_c_id",
                table: "PokemonCatagories");

            migrationBuilder.DropIndex(
                name: "IX_PokemonCatagories_c_id",
                table: "PokemonCatagories");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCatagories_Categorys_p_id",
                table: "PokemonCatagories",
                column: "p_id",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
