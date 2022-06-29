using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculadoraDeEmprestimos.Data.Migrations
{
    public partial class attDadosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorParcelaCred12",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "ValorParcelaCred24",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "ValorParcelaCred36",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "ValorParcelaCred6",
                table: "DadosUsuario");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorMinimo",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal6",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal36",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal24",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal12",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DadosUsuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SimulacaoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPretendido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorSimulado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdParcelas = table.Column<int>(type: "int", nullable: false),
                    ValorParcelas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoEfetivoMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulacaoUsuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimulacaoUsuario");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DadosUsuario");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorMinimo",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal6",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal36",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal24",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LimiteCredTotal12",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorParcelaCred12",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorParcelaCred24",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorParcelaCred36",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorParcelaCred6",
                table: "DadosUsuario",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
