using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Byte.Bank.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableListaDeUsuáriosETransações : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioKey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Genêro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    DataDeNascimento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioKey", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioKey");
        }
    }
}
