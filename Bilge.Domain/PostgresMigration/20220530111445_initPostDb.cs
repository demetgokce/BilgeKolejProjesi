using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bilge.Domain.PostresMigration
{
    public partial class initPostDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonemBaslangıcTarihi = table.Column<int>(type: "integer", nullable: false),
                    DonemBitisTarihi = table.Column<int>(type: "integer", nullable: false),
                    DonemTip = table.Column<int>(type: "integer", nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SinifAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Kapasite = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veliler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    TcNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veliler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DersAd = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    SinifId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adi = table.Column<string>(type: "text", nullable: false),
                    Soyadi = table.Column<string>(type: "text", nullable: false),
                    TcNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    DogumTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GirisTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CikisTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SinifId = table.Column<int>(type: "integer", nullable: false),
                    DersId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    TcNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    DogumTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GirisTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CikisTarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DersId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogretmenler_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DersProgramlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Saat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SinifId = table.Column<int>(type: "integer", nullable: false),
                    DersId = table.Column<int>(type: "integer", nullable: false),
                    OgretmenId = table.Column<int>(type: "integer", nullable: false),
                    OgrenciId = table.Column<int>(type: "integer", nullable: true),
                    VeliId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DersProgramlar_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramlar_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DersProgramlar_Ogretmenler_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramlar_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramlar_Veliler_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Veliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonemDers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonemId = table.Column<int>(type: "integer", nullable: false),
                    DersId = table.Column<int>(type: "integer", nullable: false),
                    OgretmenId = table.Column<int>(type: "integer", nullable: false),
                    OgrenciId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonemDers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonemDers_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonemDers_Donem_DonemId",
                        column: x => x.DonemId,
                        principalTable: "Donem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonemDers_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonemDers_Ogretmenler_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yoklamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OgrenciId = table.Column<int>(type: "integer", nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Saat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlanID = table.Column<int>(type: "integer", nullable: false),
                    DersProgramId = table.Column<int>(type: "integer", nullable: true),
                    VeliId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoklamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_DersProgramlar_DersProgramId",
                        column: x => x.DersProgramId,
                        principalTable: "DersProgramlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_Veliler_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Veliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDonemNotlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonemDersId = table.Column<int>(type: "integer", nullable: false),
                    OgrenciId = table.Column<int>(type: "integer", nullable: false),
                    Sinav1 = table.Column<int>(type: "integer", nullable: false),
                    Sinav2 = table.Column<int>(type: "integer", nullable: false),
                    SonSinav = table.Column<int>(type: "integer", nullable: false),
                    Ortalama = table.Column<int>(type: "integer", nullable: false),
                    BasariDurumTip = table.Column<int>(type: "integer", nullable: false),
                    VeliId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDonemNotlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciDonemNotlar_DonemDers_DonemDersId",
                        column: x => x.DonemDersId,
                        principalTable: "DonemDers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDonemNotlar_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDonemNotlar_Veliler_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Veliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_SinifId",
                table: "Ders",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlar_DersId",
                table: "DersProgramlar",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlar_OgrenciId",
                table: "DersProgramlar",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlar_OgretmenId",
                table: "DersProgramlar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlar_SinifId",
                table: "DersProgramlar",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlar_VeliId",
                table: "DersProgramlar",
                column: "VeliId");

            migrationBuilder.CreateIndex(
                name: "IX_DonemDers_DersId",
                table: "DonemDers",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_DonemDers_DonemId",
                table: "DonemDers",
                column: "DonemId");

            migrationBuilder.CreateIndex(
                name: "IX_DonemDers_OgrenciId",
                table: "DonemDers",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_DonemDers_OgretmenId",
                table: "DonemDers",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDonemNotlar_DonemDersId",
                table: "OgrenciDonemNotlar",
                column: "DonemDersId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDonemNotlar_OgrenciId",
                table: "OgrenciDonemNotlar",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDonemNotlar_VeliId",
                table: "OgrenciDonemNotlar",
                column: "VeliId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_DersId",
                table: "Ogrenciler",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_SinifId",
                table: "Ogrenciler",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_DersId",
                table: "Ogretmenler",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_DersProgramId",
                table: "Yoklamalar",
                column: "DersProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_OgrenciId",
                table: "Yoklamalar",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_VeliId",
                table: "Yoklamalar",
                column: "VeliId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDonemNotlar");

            migrationBuilder.DropTable(
                name: "Yoklamalar");

            migrationBuilder.DropTable(
                name: "DonemDers");

            migrationBuilder.DropTable(
                name: "DersProgramlar");

            migrationBuilder.DropTable(
                name: "Donem");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropTable(
                name: "Veliler");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Siniflar");
        }
    }
}
