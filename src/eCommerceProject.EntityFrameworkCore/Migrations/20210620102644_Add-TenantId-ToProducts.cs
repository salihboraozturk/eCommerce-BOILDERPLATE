using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceProject.Migrations
{
    public partial class AddTenantIdToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Products",
                type: "int",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Products");

        }
    }
}
