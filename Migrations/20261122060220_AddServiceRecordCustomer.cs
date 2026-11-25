using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRecordCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "ServiceRecords",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.Sql(
                """
                UPDATE "ServiceRecords"
                SET "IdCustomer" = (
                    SELECT "IdCustomer"
                    FROM "Cars"
                    WHERE "Cars"."Id" = "ServiceRecords"."CarId"
                )
                WHERE EXISTS (
                    SELECT 1
                    FROM "Cars"
                    WHERE "Cars"."Id" = "ServiceRecords"."CarId"
                );
                """);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_IdCustomer",
                table: "ServiceRecords",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecords_Customers_IdCustomer",
                table: "ServiceRecords",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRecords_Customers_IdCustomer",
                table: "ServiceRecords");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRecords_IdCustomer",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "ServiceRecords");
        }
    }
}
