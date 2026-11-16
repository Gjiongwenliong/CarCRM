using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRecord2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServiceRecords");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ServiceRecords",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceItemId",
                table: "ServiceRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "ServiceRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_MaintenanceItemId",
                table: "ServiceRecords",
                column: "MaintenanceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecords_MaintenanceItems_MaintenanceItemId",
                table: "ServiceRecords",
                column: "MaintenanceItemId",
                principalTable: "MaintenanceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRecords_MaintenanceItems_MaintenanceItemId",
                table: "ServiceRecords");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRecords_MaintenanceItemId",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "MaintenanceItemId",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "ServiceRecords");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "ServiceRecords",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "ServiceRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
