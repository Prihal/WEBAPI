using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI_REL2.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Countrys_countryid",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_Reviewersid",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemonowners",
                table: "Pokemonowners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonCatagories",
                table: "PokemonCatagories");

            migrationBuilder.RenameColumn(
                name: "Reviewersid",
                table: "Reviews",
                newName: "ReviewersId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Reviewersid",
                table: "Reviews",
                newName: "IX_Reviews_ReviewersId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviewers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "countryid",
                table: "Owners",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Owners",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_countryid",
                table: "Owners",
                newName: "IX_Owners_countryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Countrys",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pokemonowners",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PokemonCatagories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemonowners",
                table: "Pokemonowners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonCatagories",
                table: "PokemonCatagories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemonowners_p_id",
                table: "Pokemonowners",
                column: "p_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Countrys_countryId",
                table: "Owners",
                column: "countryId",
                principalTable: "Countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewersId",
                table: "Reviews",
                column: "ReviewersId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Countrys_countryId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewersId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemonowners",
                table: "Pokemonowners");

            migrationBuilder.DropIndex(
                name: "IX_Pokemonowners_p_id",
                table: "Pokemonowners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonCatagories",
                table: "PokemonCatagories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pokemonowners");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PokemonCatagories");

            migrationBuilder.RenameColumn(
                name: "ReviewersId",
                table: "Reviews",
                newName: "Reviewersid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewersId",
                table: "Reviews",
                newName: "IX_Reviews_Reviewersid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviewers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Owners",
                newName: "countryid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_countryId",
                table: "Owners",
                newName: "IX_Owners_countryid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countrys",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemonowners",
                table: "Pokemonowners",
                columns: new[] { "p_id", "o_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonCatagories",
                table: "PokemonCatagories",
                columns: new[] { "c_id", "p_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Countrys_countryid",
                table: "Owners",
                column: "countryid",
                principalTable: "Countrys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_Reviewersid",
                table: "Reviews",
                column: "Reviewersid",
                principalTable: "Reviewers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
