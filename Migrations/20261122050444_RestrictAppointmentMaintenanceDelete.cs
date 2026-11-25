using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCRM.Migrations
{
    /// <inheritdoc />
    public partial class RestrictAppointmentMaintenanceDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments",
                column: "MaintenanceItemId",
                principalTable: "MaintenanceItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_MaintenanceItems_MaintenanceItemId",
                table: "Appointments",
                column: "MaintenanceItemId",
                principalTable: "MaintenanceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
