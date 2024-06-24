using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Virtable.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Grid_Record_Field : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Columns",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Discriminator = table.Column<int>(type: "int", nullable: false),
                Variants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Pattern = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Columns", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Grids",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Grids", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Records",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                GridId = table.Column<long>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Records", x => x.Id);
                table.ForeignKey(
                    name: "FK_Records_Grids_GridId",
                    column: x => x.GridId,
                    principalTable: "Grids",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Fields",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Discriminator = table.Column<int>(type: "int", nullable: false),
                ColumnId = table.Column<long>(type: "bigint", nullable: false),
                RecordId = table.Column<long>(type: "bigint", nullable: false),
                Number = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Fields", x => x.Id);
                table.ForeignKey(
                    name: "FK_Fields_Columns_ColumnId",
                    column: x => x.ColumnId,
                    principalTable: "Columns",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Fields_Records_RecordId",
                    column: x => x.RecordId,
                    principalTable: "Records",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Fields_ColumnId",
            table: "Fields",
            column: "ColumnId");

        migrationBuilder.CreateIndex(
            name: "IX_Fields_RecordId",
            table: "Fields",
            column: "RecordId");

        migrationBuilder.CreateIndex(
            name: "IX_Records_GridId",
            table: "Records",
            column: "GridId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Fields");

        migrationBuilder.DropTable(
            name: "Columns");

        migrationBuilder.DropTable(
            name: "Records");

        migrationBuilder.DropTable(
            name: "Grids");
    }
}
