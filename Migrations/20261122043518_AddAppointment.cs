using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Appointments",
                newName: "Remark");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Appointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceItemId",
                table: "Appointments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MaintenanceItemId",
                table: "Appointments",
                column: "MaintenanceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments",
                column: "MaintenanceItemId",
                principalTable: "MaintenanceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_MaintenanceItemId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "MaintenanceItemId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "Appointments",
                newName: "Description");
        }
    }
}
