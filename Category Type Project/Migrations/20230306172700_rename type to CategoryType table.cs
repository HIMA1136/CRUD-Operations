using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Category_Type_Project.Migrations
{
    public partial class renametypetoCategoryTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_types_TypeId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_types",
                table: "types");

            migrationBuilder.RenameTable(
                name: "types",
                newName: "Types");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "types");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_types",
                table: "types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_types_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
