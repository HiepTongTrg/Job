using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JobOnline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhaTuyenDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaTuyenDung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UngVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenUngVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngVien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhaTuyenDungID = table.Column<int>(type: "int", nullable: false),
                    NgayDang = table.Column<DateTime>(type: "date", nullable: false),
                    TenCongViec = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Luong = table.Column<double>(type: "float", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LoaiCV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CongViec_NhaTuyenDung_NhaTuyenDungID",
                        column: x => x.NhaTuyenDungID,
                        principalTable: "NhaTuyenDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XinViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UngVienID = table.Column<int>(type: "int", nullable: false),
                    CongViecID = table.Column<int>(type: "int", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XinViec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_XinViec_CongViec_CongViecID",
                        column: x => x.CongViecID,
                        principalTable: "CongViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XinViec_UngVien_UngVienID",
                        column: x => x.UngVienID,
                        principalTable: "UngVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_NhaTuyenDungID",
                table: "CongViec",
                column: "NhaTuyenDungID");

            migrationBuilder.CreateIndex(
                name: "IX_XinViec_CongViecID",
                table: "XinViec",
                column: "CongViecID");

            migrationBuilder.CreateIndex(
                name: "IX_XinViec_UngVienID",
                table: "XinViec",
                column: "UngVienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XinViec");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "UngVien");

            migrationBuilder.DropTable(
                name: "NhaTuyenDung");
        }
    }
}
