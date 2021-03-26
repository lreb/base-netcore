using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Base.Persistence.Migrations
{
    public partial class Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedOn", "Name", "Quantity", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 3, 25, 23, 41, 40, 629, DateTimeKind.Local).AddTicks(9351), "A", 1, null, null },
                    { 2, true, null, new DateTime(2021, 3, 25, 23, 41, 40, 631, DateTimeKind.Local).AddTicks(6457), "B", 2, null, null },
                    { 3, true, null, new DateTime(2021, 3, 25, 23, 41, 40, 631, DateTimeKind.Local).AddTicks(6484), "C", 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name_Quantity",
                table: "Items",
                columns: new[] { "Name", "Quantity" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
