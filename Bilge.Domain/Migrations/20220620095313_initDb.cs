using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilge.Domain.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonemBaslangıcTarihi = table.Column<int>(type: "int", nullable: false),
                    DonemBitisTarihi = table.Column<int>(type: "int", nullable: false),
                    DonemTip = table.Column<int>(type: "int", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veliler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veliler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SiniflarId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_Siniflar_SiniflarId",
                        column: x => x.SiniflarId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GirisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CikisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DersProgram",
                columns: table => new
                {
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiniflarId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    VeliId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgram", x => x.Tarih);
                    table.ForeignKey(
                        name: "FK_DersProgram_Ders_DersId",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgram_Siniflar_SiniflarId",
                        column: x => x.SiniflarId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgram_Veliler_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Veliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GirisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CikisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Yoklamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DersPogramId = table.Column<int>(type: "int", nullable: false),
                    DersProgramTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VeliId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoklamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_DersProgram_DersProgramTarih",
                        column: x => x.DersProgramTarih,
                        principalTable: "DersProgram",
                        principalColumn: "Tarih",
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

            migrationBuilder.InsertData(
                table: "Siniflar",
                columns: new[] { "Id", "CreateDate", "Kapasite", "Kod", "SinifAdi" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "100", "9A" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "101", "10A" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "102", "11A" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "103", "12A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_SiniflarId",
                table: "Ders",
                column: "SiniflarId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgram_DersId",
                table: "DersProgram",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgram_SiniflarId",
                table: "DersProgram",
                column: "SiniflarId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgram_VeliId",
                table: "DersProgram",
                column: "VeliId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_SinifId",
                table: "Ogrenciler",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_DersId",
                table: "Ogretmenler",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_DersProgramTarih",
                table: "Yoklamalar",
                column: "DersProgramTarih");

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
                name: "Donem");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropTable(
                name: "Yoklamalar");

            migrationBuilder.DropTable(
                name: "DersProgram");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Veliler");

            migrationBuilder.DropTable(
                name: "Siniflar");
        }
    }
}
