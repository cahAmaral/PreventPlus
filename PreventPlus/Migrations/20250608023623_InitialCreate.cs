using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreventPlus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOCAL_SEGURO",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeLocal = table.Column<string>(type: "TEXT", nullable: false),
                    EnderecoLocal = table.Column<string>(type: "TEXT", nullable: false),
                    TipoLocal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_SEGURO", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "REGIAO",
                columns: table => new
                {
                    IdRegiao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeRegiao = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoRegiao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGIAO", x => x.IdRegiao);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_DESASTRE",
                columns: table => new
                {
                    IdDesastre = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDesastre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_DESASTRE", x => x.IdDesastre);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_RISCO",
                columns: table => new
                {
                    IdHistorico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HistChuva = table.Column<int>(type: "INTEGER", nullable: false),
                    HistUmidade = table.Column<int>(type: "INTEGER", nullable: false),
                    HistTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    HistAlerta = table.Column<int>(type: "INTEGER", nullable: false),
                    HistImpacto = table.Column<string>(type: "TEXT", nullable: false),
                    IdRegiao = table.Column<int>(type: "INTEGER", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_RISCO", x => x.IdHistorico);
                    table.ForeignKey(
                        name: "FK_HISTORICO_RISCO_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "REGIAO",
                        principalColumn: "IdRegiao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    EmailUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    TipoUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioCriado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdRegiao = table.Column<int>(type: "INTEGER", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_USUARIO_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "REGIAO",
                        principalColumn: "IdRegiao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHECKLIST",
                columns: table => new
                {
                    IdChecklist = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloChecklist = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoChecklist = table.Column<string>(type: "TEXT", nullable: false),
                    StatusChecklist = table.Column<string>(type: "TEXT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHECKLIST", x => x.IdChecklist);
                    table.ForeignKey(
                        name: "FK_CHECKLIST_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DICA",
                columns: table => new
                {
                    IdDica = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloDica = table.Column<string>(type: "TEXT", nullable: false),
                    ConteudoDica = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDica = table.Column<string>(type: "TEXT", nullable: false),
                    CriacaoDica = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdDesastre = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoDesastreIdDesastre = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICA", x => x.IdDica);
                    table.ForeignKey(
                        name: "FK_DICA_TIPO_DESASTRE_TipoDesastreIdDesastre",
                        column: x => x.TipoDesastreIdDesastre,
                        principalTable: "TIPO_DESASTRE",
                        principalColumn: "IdDesastre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DICA_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KIT",
                columns: table => new
                {
                    IdKit = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemKit = table.Column<string>(type: "TEXT", nullable: false),
                    QtdItem = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KIT", x => x.IdKit);
                    table.ForeignKey(
                        name: "FK_KIT_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_FAVORITO",
                columns: table => new
                {
                    IdFav = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLocal = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalSeguroIdLocal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_FAVORITO", x => x.IdFav);
                    table.ForeignKey(
                        name: "FK_LOCAL_FAVORITO_LOCAL_SEGURO_LocalSeguroIdLocal",
                        column: x => x.LocalSeguroIdLocal,
                        principalTable: "LOCAL_SEGURO",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOCAL_FAVORITO_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICACAO",
                columns: table => new
                {
                    IdNotificacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloNotificacao = table.Column<string>(type: "TEXT", nullable: false),
                    DescNotificacao = table.Column<string>(type: "TEXT", nullable: false),
                    EnvioNotificacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACAO", x => x.IdNotificacao);
                    table.ForeignKey(
                        name: "FK_NOTIFICACAO_USUARIO_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTA",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MensagemAlerta = table.Column<string>(type: "TEXT", nullable: false),
                    TipoAlerta = table.Column<string>(type: "TEXT", nullable: false),
                    CriacaoAlerta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdNotificacao = table.Column<int>(type: "INTEGER", nullable: false),
                    NotificacaoIdNotificacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTA", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_ALERTA_NOTIFICACAO_NotificacaoIdNotificacao",
                        column: x => x.NotificacaoIdNotificacao,
                        principalTable: "NOTIFICACAO",
                        principalColumn: "IdNotificacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTA_NotificacaoIdNotificacao",
                table: "ALERTA",
                column: "NotificacaoIdNotificacao");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKLIST_UsuarioIdUsuario",
                table: "CHECKLIST",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DICA_TipoDesastreIdDesastre",
                table: "DICA",
                column: "TipoDesastreIdDesastre");

            migrationBuilder.CreateIndex(
                name: "IX_DICA_UsuarioIdUsuario",
                table: "DICA",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_RISCO_RegiaoIdRegiao",
                table: "HISTORICO_RISCO",
                column: "RegiaoIdRegiao");

            migrationBuilder.CreateIndex(
                name: "IX_KIT_UsuarioIdUsuario",
                table: "KIT",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_LOCAL_FAVORITO_LocalSeguroIdLocal",
                table: "LOCAL_FAVORITO",
                column: "LocalSeguroIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_LOCAL_FAVORITO_UsuarioIdUsuario",
                table: "LOCAL_FAVORITO",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACAO_UsuarioIdUsuario",
                table: "NOTIFICACAO",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_RegiaoIdRegiao",
                table: "USUARIO",
                column: "RegiaoIdRegiao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTA");

            migrationBuilder.DropTable(
                name: "CHECKLIST");

            migrationBuilder.DropTable(
                name: "DICA");

            migrationBuilder.DropTable(
                name: "HISTORICO_RISCO");

            migrationBuilder.DropTable(
                name: "KIT");

            migrationBuilder.DropTable(
                name: "LOCAL_FAVORITO");

            migrationBuilder.DropTable(
                name: "NOTIFICACAO");

            migrationBuilder.DropTable(
                name: "TIPO_DESASTRE");

            migrationBuilder.DropTable(
                name: "LOCAL_SEGURO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "REGIAO");
        }
    }
}
