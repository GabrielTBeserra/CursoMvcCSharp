using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMvcCourse.Migrations
{
    public partial class newname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_SalesRecords_StatusId",
                table: "SalesRecords");

            migrationBuilder.DropIndex(
                name: "IX_SalesRecords_StatusId",
                table: "SalesRecords");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "SalesRecords");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SalesRecords",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SalesRecords");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "SalesRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecords_StatusId",
                table: "SalesRecords",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_SalesRecords_StatusId",
                table: "SalesRecords",
                column: "StatusId",
                principalTable: "SalesRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
