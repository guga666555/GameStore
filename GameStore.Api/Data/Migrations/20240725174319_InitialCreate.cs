using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Games_Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Games_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Games_Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Games_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Games_Plataform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Games_Plataform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Games_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Games_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PictureId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlataformId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Games_Product_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Product_Games_Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Games_Product_Games_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Product_Games_Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Games_Product_Games_Plataform_PlataformId",
                        column: x => x.PlataformId,
                        principalTable: "Product_Games_Plataform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Games_Product_Games_Type_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "Product_Games_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Games_GenreId",
                table: "Product_Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Games_PictureId",
                table: "Product_Games",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Games_PlataformId",
                table: "Product_Games",
                column: "PlataformId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Games_ProductTypeId",
                table: "Product_Games",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Games");

            migrationBuilder.DropTable(
                name: "Product_Games_Genres");

            migrationBuilder.DropTable(
                name: "Product_Games_Picture");

            migrationBuilder.DropTable(
                name: "Product_Games_Plataform");

            migrationBuilder.DropTable(
                name: "Product_Games_Type");
        }
    }
}
