using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceProject.Migrations
{
    public partial class AddProductSoftDeleteAudited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorUserId",
                table: "Products",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeleterUserId",
                table: "Products",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastModifierUserId",
                table: "Products",
                column: "LastModifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AbpUsers_CreatorUserId",
                table: "Products",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AbpUsers_DeleterUserId",
                table: "Products",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AbpUsers_LastModifierUserId",
                table: "Products",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AbpUsers_CreatorUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AbpUsers_DeleterUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AbpUsers_LastModifierUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatorUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeleterUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LastModifierUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
