using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceProject.Migrations
{
    public partial class AddCategorySoftDeleteAudited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuantityPerUnit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatorUserId",
                table: "Categories",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeleterUserId",
                table: "Categories",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastModifierUserId",
                table: "Categories",
                column: "LastModifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AbpUsers_CreatorUserId",
                table: "Categories",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AbpUsers_DeleterUserId",
                table: "Categories",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AbpUsers_LastModifierUserId",
                table: "Categories",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AbpUsers_CreatorUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AbpUsers_DeleterUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AbpUsers_LastModifierUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatorUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeleterUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LastModifierUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "QuantityPerUnit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
