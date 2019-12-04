using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftJail.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Department_DepartmentId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_Officers_Department_DepartmentId",
                table: "Officers");

            migrationBuilder.DropForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficerPrisoners",
                table: "OfficerPrisoners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "OfficerPrisoners",
                newName: "OfficersPrisoners");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_OfficerPrisoners_OfficerId",
                table: "OfficersPrisoners",
                newName: "IX_OfficersPrisoners_OfficerId");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Prisoners",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Bail",
                table: "Prisoners",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficersPrisoners",
                table: "OfficersPrisoners",
                columns: new[] { "PrisonerId", "OfficerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Departments_DepartmentId",
                table: "Cells",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficersPrisoners_Officers_OfficerId",
                table: "OfficersPrisoners",
                column: "OfficerId",
                principalTable: "Officers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficersPrisoners_Prisoners_PrisonerId",
                table: "OfficersPrisoners",
                column: "PrisonerId",
                principalTable: "Prisoners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Departments_DepartmentId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Officers_Departments_DepartmentId",
                table: "Officers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficersPrisoners_Officers_OfficerId",
                table: "OfficersPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficersPrisoners_Prisoners_PrisonerId",
                table: "OfficersPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficersPrisoners",
                table: "OfficersPrisoners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "OfficersPrisoners",
                newName: "OfficerPrisoners");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_OfficersPrisoners_OfficerId",
                table: "OfficerPrisoners",
                newName: "IX_OfficerPrisoners_OfficerId");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Prisoners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Bail",
                table: "Prisoners",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficerPrisoners",
                table: "OfficerPrisoners",
                columns: new[] { "PrisonerId", "OfficerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Department_DepartmentId",
                table: "Cells",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners",
                column: "OfficerId",
                principalTable: "Officers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners",
                column: "PrisonerId",
                principalTable: "Prisoners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Officers_Department_DepartmentId",
                table: "Officers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
