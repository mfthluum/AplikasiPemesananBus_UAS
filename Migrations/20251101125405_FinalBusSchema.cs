using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AplikasiPemesananBus_UAS.Migrations
{
    /// <inheritdoc />
    public partial class FinalBusSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaBus = table.Column<string>(type: "text", nullable: false),
                    NomorPlat = table.Column<string>(type: "text", nullable: false),
                    Kapasitas = table.Column<int>(type: "integer", nullable: false),
                    TarifBase = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Penumpangs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    NomorHP = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penumpangs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pemesanan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PenumpangID = table.Column<int>(type: "integer", nullable: false),
                    BusID = table.Column<int>(type: "integer", nullable: false),
                    TanggalPemesanan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JumlahTiket = table.Column<int>(type: "integer", nullable: false),
                    TotalBayar = table.Column<decimal>(type: "numeric", nullable: false),
                    TarifDasar = table.Column<decimal>(type: "numeric", nullable: false),
                    Retribusi = table.Column<decimal>(type: "numeric", nullable: false),
                    PemesananID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pemesanan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pemesanan_Buses_BusID",
                        column: x => x.BusID,
                        principalTable: "Buses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pemesanan_Penumpangs_PenumpangID",
                        column: x => x.PenumpangID,
                        principalTable: "Penumpangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_NomorPlat",
                table: "Buses",
                column: "NomorPlat",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pemesanan_BusID",
                table: "Pemesanan",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_Pemesanan_PenumpangID",
                table: "Pemesanan",
                column: "PenumpangID");

            migrationBuilder.CreateIndex(
                name: "IX_Penumpangs_NomorHP",
                table: "Penumpangs",
                column: "NomorHP",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pemesanan");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Penumpangs");
        }
    }
}
