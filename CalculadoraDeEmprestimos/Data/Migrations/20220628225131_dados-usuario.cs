using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculadoraDeEmprestimos.Data.Migrations
{
    public partial class dadosusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {        

            migrationBuilder.CreateTable(
                name: "DadosUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimiteCredTotal6 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorParcelaCred6 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimiteCredTotal12 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorParcelaCred12 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimiteCredTotal24 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorParcelaCred24 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LimiteCredTotal36 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorParcelaCred36 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosUsuario");
        }
    }
}
