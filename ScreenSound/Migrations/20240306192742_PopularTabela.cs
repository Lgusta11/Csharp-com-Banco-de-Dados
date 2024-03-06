using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio" ,
             "FotoPerfil"}, new object[] { "Djavan", "Melhor do MPB", "fotoPerfil.jpn" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio" ,
             "FotoPerfil"}, new object[] { "Yrlan", "Fera", "fotoPerfil.jpn" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio" ,
             "FotoPerfil"}, new object[] { "Gusta", "Mais lindo da AFS", "fotoPerfil.jpn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
