using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2.semprojektboglistesystemet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boghandlere",
                columns: table => new
                {
                    BoghandlerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boghandlere", x => x.BoghandlerId);
                });

            migrationBuilder.CreateTable(
                name: "Koordinatorer",
                columns: table => new
                {
                    KoordinatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koordinatorer", x => x.KoordinatorId);
                });

            migrationBuilder.CreateTable(
                name: "Fag",
                columns: table => new
                {
                    FagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KoordinatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fag", x => x.FagId);
                    table.ForeignKey(
                        name: "FK_Fag_Koordinatorer_KoordinatorId",
                        column: x => x.KoordinatorId,
                        principalTable: "Koordinatorer",
                        principalColumn: "KoordinatorId");
                });

            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    HoldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KoordinatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.HoldId);
                    table.ForeignKey(
                        name: "FK_Hold_Koordinatorer_KoordinatorId",
                        column: x => x.KoordinatorId,
                        principalTable: "Koordinatorer",
                        principalColumn: "KoordinatorId");
                });

            migrationBuilder.CreateTable(
                name: "Uddannelser",
                columns: table => new
                {
                    UddannelseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KoordinatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uddannelser", x => x.UddannelseId);
                    table.ForeignKey(
                        name: "FK_Uddannelser_Koordinatorer_KoordinatorId",
                        column: x => x.KoordinatorId,
                        principalTable: "Koordinatorer",
                        principalColumn: "KoordinatorId");
                });

            migrationBuilder.CreateTable(
                name: "Undervisere",
                columns: table => new
                {
                    UnderviserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KoordinatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Undervisere", x => x.UnderviserId);
                    table.ForeignKey(
                        name: "FK_Undervisere_Koordinatorer_KoordinatorId",
                        column: x => x.KoordinatorId,
                        principalTable: "Koordinatorer",
                        principalColumn: "KoordinatorId");
                });

            migrationBuilder.CreateTable(
                name: "Semestre",
                columns: table => new
                {
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KoordinatorId = table.Column<int>(type: "int", nullable: true),
                    UddannelserUddannelseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestre", x => x.SemesterId);
                    table.ForeignKey(
                        name: "FK_Semestre_Koordinatorer_KoordinatorId",
                        column: x => x.KoordinatorId,
                        principalTable: "Koordinatorer",
                        principalColumn: "KoordinatorId");
                    table.ForeignKey(
                        name: "FK_Semestre_Uddannelser_UddannelserUddannelseId",
                        column: x => x.UddannelserUddannelseId,
                        principalTable: "Uddannelser",
                        principalColumn: "UddannelseId");
                });

            migrationBuilder.CreateTable(
                name: "Bøger",
                columns: table => new
                {
                    BogId = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: true),
                    BoghandlerId = table.Column<int>(type: "int", nullable: true),
                    UnderviserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bøger", x => x.BogId);
                    table.ForeignKey(
                        name: "FK_Bøger_Boghandlere_BoghandlerId",
                        column: x => x.BoghandlerId,
                        principalTable: "Boghandlere",
                        principalColumn: "BoghandlerId");
                    table.ForeignKey(
                        name: "FK_Bøger_Undervisere_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Undervisere",
                        principalColumn: "UnderviserId");
                });

            migrationBuilder.CreateTable(
                name: "FagUnderviser",
                columns: table => new
                {
                    FagId = table.Column<int>(type: "int", nullable: false),
                    UnderviserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FagUnderviser", x => new { x.FagId, x.UnderviserId });
                    table.ForeignKey(
                        name: "FK_FagUnderviser_Fag_FagId",
                        column: x => x.FagId,
                        principalTable: "Fag",
                        principalColumn: "FagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FagUnderviser_Undervisere_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Undervisere",
                        principalColumn: "UnderviserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldSemestre",
                columns: table => new
                {
                    HoldId = table.Column<int>(type: "int", nullable: false),
                    semestreSemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldSemestre", x => new { x.HoldId, x.semestreSemesterId });
                    table.ForeignKey(
                        name: "FK_HoldSemestre_Hold_HoldId",
                        column: x => x.HoldId,
                        principalTable: "Hold",
                        principalColumn: "HoldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldSemestre_Semestre_semestreSemesterId",
                        column: x => x.semestreSemesterId,
                        principalTable: "Semestre",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bøger_BoghandlerId",
                table: "Bøger",
                column: "BoghandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bøger_UnderviserId",
                table: "Bøger",
                column: "UnderviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fag_KoordinatorId",
                table: "Fag",
                column: "KoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FagUnderviser_UnderviserId",
                table: "FagUnderviser",
                column: "UnderviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hold_KoordinatorId",
                table: "Hold",
                column: "KoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldSemestre_semestreSemesterId",
                table: "HoldSemestre",
                column: "semestreSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semestre_KoordinatorId",
                table: "Semestre",
                column: "KoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Semestre_UddannelserUddannelseId",
                table: "Semestre",
                column: "UddannelserUddannelseId");

            migrationBuilder.CreateIndex(
                name: "IX_Uddannelser_KoordinatorId",
                table: "Uddannelser",
                column: "KoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Undervisere_KoordinatorId",
                table: "Undervisere",
                column: "KoordinatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bøger");

            migrationBuilder.DropTable(
                name: "FagUnderviser");

            migrationBuilder.DropTable(
                name: "HoldSemestre");

            migrationBuilder.DropTable(
                name: "Boghandlere");

            migrationBuilder.DropTable(
                name: "Fag");

            migrationBuilder.DropTable(
                name: "Undervisere");

            migrationBuilder.DropTable(
                name: "Hold");

            migrationBuilder.DropTable(
                name: "Semestre");

            migrationBuilder.DropTable(
                name: "Uddannelser");

            migrationBuilder.DropTable(
                name: "Koordinatorer");
        }
    }
}
