using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cad_usuario",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuariocodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_usuario", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_usuario_tb_cad_usuario_Usuariocodigo",
                        column: x => x.Usuariocodigo,
                        principalTable: "tb_cad_usuario",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateTable(
                name: "tb_cad_termo",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_codigo = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    termocodigo = table.Column<int>(type: "int", nullable: false),
                    versao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_termo", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_tb_cad_termo_termocodigo",
                        column: x => x.termocodigo,
                        principalTable: "tb_cad_termo",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_tb_cad_usuario_usuario_codigo",
                        column: x => x.usuario_codigo,
                        principalTable: "tb_cad_usuario",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cad_termo_item",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    termo_codigo = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obrigatorio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_termo_item", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_item_tb_cad_termo_termo_codigo",
                        column: x => x.termo_codigo,
                        principalTable: "tb_cad_termo",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cad_termo_item_aceite_usuario_historico",
                columns: table => new
                {
                    usuario_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    termo_codigo = table.Column<int>(type: "int", nullable: false),
                    data_aceite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_termo_item_aceite_usuario_historico", x => x.usuario_codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_item_aceite_usuario_historico_tb_cad_termo_termo_codigo",
                        column: x => x.termo_codigo,
                        principalTable: "tb_cad_termo",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cad_termo_item_aceite",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    termo_aceite_codigo = table.Column<int>(type: "int", nullable: false),
                    termo_item_codigo = table.Column<int>(type: "int", nullable: false),
                    aceite = table.Column<bool>(type: "bit", nullable: false),
                    CadTermoItemcodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cad_termo_item_aceite", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_item_aceite_tb_cad_termo_item_CadTermoItemcodigo",
                        column: x => x.CadTermoItemcodigo,
                        principalTable: "tb_cad_termo_item",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_tb_cad_termo_item_aceite_tb_cad_termo_item_aceite_usuario_historico_termo_aceite_codigo",
                        column: x => x.termo_aceite_codigo,
                        principalTable: "tb_cad_termo_item_aceite_usuario_historico",
                        principalColumn: "usuario_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_termocodigo",
                table: "tb_cad_termo",
                column: "termocodigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_usuario_codigo",
                table: "tb_cad_termo",
                column: "usuario_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_item_termo_codigo",
                table: "tb_cad_termo_item",
                column: "termo_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_item_aceite_CadTermoItemcodigo",
                table: "tb_cad_termo_item_aceite",
                column: "CadTermoItemcodigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_item_aceite_termo_aceite_codigo",
                table: "tb_cad_termo_item_aceite",
                column: "termo_aceite_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_termo_item_aceite_usuario_historico_termo_codigo",
                table: "tb_cad_termo_item_aceite_usuario_historico",
                column: "termo_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cad_usuario_Usuariocodigo",
                table: "tb_cad_usuario",
                column: "Usuariocodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cad_termo_item_aceite");

            migrationBuilder.DropTable(
                name: "tb_cad_termo_item");

            migrationBuilder.DropTable(
                name: "tb_cad_termo_item_aceite_usuario_historico");

            migrationBuilder.DropTable(
                name: "tb_cad_termo");

            migrationBuilder.DropTable(
                name: "tb_cad_usuario");
        }
    }
}
