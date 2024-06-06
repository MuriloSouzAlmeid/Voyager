using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class VoyagerBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusViagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusViagem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoViagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoViagem = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViagem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    CodRecupSenha = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoUsuario",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: true),
                    Logradouro = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Estado = table.Column<string>(type: "CHAR(2)", nullable: true),
                    Cidade = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoUsuario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnderecoUsuario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IdStatusViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Viagem_StatusViagem_IdStatusViagem",
                        column: x => x.IdStatusViagem,
                        principalTable: "StatusViagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Viagem_TipoViagem_IdTipoViagem",
                        column: x => x.IdTipoViagem,
                        principalTable: "TipoViagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Viagem_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtividade = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DescricaoAtividade = table.Column<string>(type: "TEXT", nullable: true),
                    Concluida = table.Column<bool>(type: "BIT", nullable: true),
                    IdViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanejamento = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atividades_Viagem_IdPlanejamento",
                        column: x => x.IdPlanejamento,
                        principalTable: "Viagem",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EnderecosViagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaisOrigem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CidadeOrigem = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    PaisDestino = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CidadeDestino = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosViagem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnderecosViagem_Viagem_IdViagem",
                        column: x => x.IdViagem,
                        principalTable: "Viagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PostagemViagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Titulo = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostagemViagem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostagemViagem_Viagem_IdViagem",
                        column: x => x.IdViagem,
                        principalTable: "Viagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPostagemViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusAvaliacao = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Avaliacao_PostagemViagem_IdPostagemViagem",
                        column: x => x.IdPostagemViagem,
                        principalTable: "PostagemViagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPostagemViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComentarioTexto = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentario_PostagemViagem_IdPostagemViagem",
                        column: x => x.IdPostagemViagem,
                        principalTable: "PostagemViagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GaleriaImagem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPostagemViagem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Media = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaImagem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GaleriaImagem_PostagemViagem_IdPostagemViagem",
                        column: x => x.IdPostagemViagem,
                        principalTable: "PostagemViagem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdPlanejamento",
                table: "Atividades",
                column: "IdPlanejamento");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdPostagemViagem",
                table: "Avaliacao",
                column: "IdPostagemViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdUsuario",
                table: "Avaliacao",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdPostagemViagem",
                table: "Comentario",
                column: "IdPostagemViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdUsuario",
                table: "Comentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosViagem_IdViagem",
                table: "EnderecosViagem",
                column: "IdViagem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUsuario_IdUsuario",
                table: "EnderecoUsuario",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaleriaImagem_IdPostagemViagem",
                table: "GaleriaImagem",
                column: "IdPostagemViagem");

            migrationBuilder.CreateIndex(
                name: "IX_PostagemViagem_IdViagem",
                table: "PostagemViagem",
                column: "IdViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_IdStatusViagem",
                table: "Viagem",
                column: "IdStatusViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_IdTipoViagem",
                table: "Viagem",
                column: "IdTipoViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_IdUsuario",
                table: "Viagem",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "EnderecosViagem");

            migrationBuilder.DropTable(
                name: "EnderecoUsuario");

            migrationBuilder.DropTable(
                name: "GaleriaImagem");

            migrationBuilder.DropTable(
                name: "PostagemViagem");

            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "StatusViagem");

            migrationBuilder.DropTable(
                name: "TipoViagem");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
