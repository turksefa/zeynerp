using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zeynerp.Infrastructure.Data.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cariler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cariStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cariler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariTurler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariTurler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KDVler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDVler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeVadeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Sipariste = table.Column<int>(type: "int", nullable: false),
                    FaturaTarihinden = table.Column<int>(type: "int", nullable: false),
                    Kalan = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeVadeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParaBirimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaBirimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokGruplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokGruplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokOzellikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    OzgulAgirlik = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokOzellikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariYetkililer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariYetkililer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariYetkililer_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeslimatAdresleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeslimatAdresleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeslimatAdresleri_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariCariTur",
                columns: table => new
                {
                    CariTurlerId = table.Column<int>(type: "int", nullable: false),
                    CarilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariCariTur", x => new { x.CariTurlerId, x.CarilerId });
                    table.ForeignKey(
                        name: "FK_CariCariTur_CariTurler_CariTurlerId",
                        column: x => x.CariTurlerId,
                        principalTable: "CariTurler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CariCariTur_Cariler_CarilerId",
                        column: x => x.CarilerId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KutuSayisi = table.Column<int>(type: "int", nullable: true),
                    Oncul1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oncul2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oncul3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oncul4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ayrac1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ayrac2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ayrac3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ayrac4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boyut1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boyut2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boyut3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boyut4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KGFormül = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2Formül = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MMFormül = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MFormül = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fire1 = table.Column<bool>(type: "bit", nullable: true),
                    Fire2 = table.Column<bool>(type: "bit", nullable: true),
                    Fire3 = table.Column<bool>(type: "bit", nullable: true),
                    Fire4 = table.Column<bool>(type: "bit", nullable: true),
                    Siralama1 = table.Column<int>(type: "int", nullable: true),
                    Siralama2 = table.Column<int>(type: "int", nullable: true),
                    Siralama3 = table.Column<int>(type: "int", nullable: true),
                    Siralama4 = table.Column<int>(type: "int", nullable: true),
                    Sertifika = table.Column<bool>(type: "bit", nullable: false),
                    SatinAlma = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StokGrupId = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    BirimFiyatHesaplama = table.Column<int>(type: "int", nullable: false),
                    StokSorumluId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stoklar_StokGruplar_StokGrupId",
                        column: x => x.StokGrupId,
                        principalTable: "StokGruplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MalzemeTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birim = table.Column<int>(type: "int", nullable: false),
                    StokGrupId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    StokOzellikId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boyut1 = table.Column<double>(type: "float", nullable: false),
                    Boyut2 = table.Column<double>(type: "float", nullable: false),
                    Boyut3 = table.Column<double>(type: "float", nullable: false),
                    Boyut4 = table.Column<double>(type: "float", nullable: false),
                    Kg = table.Column<double>(type: "float", nullable: false),
                    M2 = table.Column<double>(type: "float", nullable: false),
                    Mm = table.Column<double>(type: "float", nullable: false),
                    M = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalzemeTalepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepler_StokGruplar_StokGrupId",
                        column: x => x.StokGrupId,
                        principalTable: "StokGruplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepler_StokOzellikler_StokOzellikId",
                        column: x => x.StokOzellikId,
                        principalTable: "StokOzellikler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepler_Stoklar_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MalzemeTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    CariYetkiliId = table.Column<int>(type: "int", nullable: false),
                    MalzemeTalepId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Boyut1 = table.Column<double>(type: "float", nullable: true),
                    Boyut2 = table.Column<double>(type: "float", nullable: true),
                    Boyut3 = table.Column<double>(type: "float", nullable: true),
                    Boyut4 = table.Column<double>(type: "float", nullable: true),
                    BirimId = table.Column<int>(type: "int", nullable: true),
                    BirimSayisi = table.Column<int>(type: "int", nullable: true),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KdvId = table.Column<int>(type: "int", nullable: true),
                    ParaBirimId = table.Column<int>(type: "int", nullable: true),
                    OdemeVadeId = table.Column<int>(type: "int", nullable: true),
                    TeslimatAdresId = table.Column<int>(type: "int", nullable: true),
                    TeslimatTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeslimatNot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mevcut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalzemeTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_Birimler_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birimler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_CariYetkililer_CariYetkiliId",
                        column: x => x.CariYetkiliId,
                        principalTable: "CariYetkililer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_Cariler_CariId",
                        column: x => x.CariId,
                        principalTable: "Cariler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_KDVler_KdvId",
                        column: x => x.KdvId,
                        principalTable: "KDVler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_MalzemeTalepler_MalzemeTalepId",
                        column: x => x.MalzemeTalepId,
                        principalTable: "MalzemeTalepler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_OdemeVadeler_OdemeVadeId",
                        column: x => x.OdemeVadeId,
                        principalTable: "OdemeVadeler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_ParaBirimler_ParaBirimId",
                        column: x => x.ParaBirimId,
                        principalTable: "ParaBirimler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MalzemeTalepleri_TeslimatAdresleri_TeslimatAdresId",
                        column: x => x.TeslimatAdresId,
                        principalTable: "TeslimatAdresleri",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Birimler",
                columns: new[] { "Id", "Name", "Order", "Status", "Unit" },
                values: new object[,]
                {
                    { 1, "Yok", 1, 1, "Yok" },
                    { 2, "Adet", 2, 1, "Adet" },
                    { 3, "Kilogram", 3, 1, "KG" },
                    { 4, "Metrekare", 4, 1, "M2" },
                    { 5, "Milimetre", 5, 1, "MM" },
                    { 6, "Metre", 6, 1, "M" }
                });

            migrationBuilder.InsertData(
                table: "KDVler",
                columns: new[] { "Id", "Name", "Order", "Status" },
                values: new object[,]
                {
                    { 1, "0", 1, 1 },
                    { 2, "1", 2, 1 },
                    { 3, "10", 3, 1 },
                    { 4, "20", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "ParaBirimler",
                columns: new[] { "Id", "Birim", "Name", "Order", "Status" },
                values: new object[,]
                {
                    { 1, "₺", "TRY", 1, 1 },
                    { 2, "$", "USD", 2, 1 },
                    { 3, "€", "EUR", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "StokGruplar",
                columns: new[] { "Id", "Name", "Order", "Status" },
                values: new object[] { 1, "Yok", 1, 1 });

            migrationBuilder.InsertData(
                table: "StokOzellikler",
                columns: new[] { "Id", "Name", "Order", "OzgulAgirlik", "Status" },
                values: new object[] { 1, "Yok", 1, 1.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CariCariTur_CarilerId",
                table: "CariCariTur",
                column: "CarilerId");

            migrationBuilder.CreateIndex(
                name: "IX_CariYetkililer_CariId",
                table: "CariYetkililer",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepler_StokGrupId",
                table: "MalzemeTalepler",
                column: "StokGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepler_StokId",
                table: "MalzemeTalepler",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepler_StokOzellikId",
                table: "MalzemeTalepler",
                column: "StokOzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_BirimId",
                table: "MalzemeTalepleri",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_CariId",
                table: "MalzemeTalepleri",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_CariYetkiliId",
                table: "MalzemeTalepleri",
                column: "CariYetkiliId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_KdvId",
                table: "MalzemeTalepleri",
                column: "KdvId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_MalzemeTalepId",
                table: "MalzemeTalepleri",
                column: "MalzemeTalepId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_OdemeVadeId",
                table: "MalzemeTalepleri",
                column: "OdemeVadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_ParaBirimId",
                table: "MalzemeTalepleri",
                column: "ParaBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeTalepleri_TeslimatAdresId",
                table: "MalzemeTalepleri",
                column: "TeslimatAdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoklar_StokGrupId",
                table: "Stoklar",
                column: "StokGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeslimatAdresleri_CariId",
                table: "TeslimatAdresleri",
                column: "CariId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CariCariTur");

            migrationBuilder.DropTable(
                name: "MalzemeTalepleri");

            migrationBuilder.DropTable(
                name: "CariTurler");

            migrationBuilder.DropTable(
                name: "Birimler");

            migrationBuilder.DropTable(
                name: "CariYetkililer");

            migrationBuilder.DropTable(
                name: "KDVler");

            migrationBuilder.DropTable(
                name: "MalzemeTalepler");

            migrationBuilder.DropTable(
                name: "OdemeVadeler");

            migrationBuilder.DropTable(
                name: "ParaBirimler");

            migrationBuilder.DropTable(
                name: "TeslimatAdresleri");

            migrationBuilder.DropTable(
                name: "StokOzellikler");

            migrationBuilder.DropTable(
                name: "Stoklar");

            migrationBuilder.DropTable(
                name: "Cariler");

            migrationBuilder.DropTable(
                name: "StokGruplar");
        }
    }
}
