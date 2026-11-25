using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddCarCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "Cars",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdCustomer",
                table: "Cars",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_IdCustomer",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Cars");
        }
    }
}
