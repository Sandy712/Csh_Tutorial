using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_12_23.Migrations
{
    /// <inheritdoc />
    public partial class updatePhoneno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PnoneNo",
                table: "Employees",
                newName: "PhoneNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Employees",
                newName: "PnoneNo");
        }
    }
}
