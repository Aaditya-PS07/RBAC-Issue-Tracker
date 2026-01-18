using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class AddIssueOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Issues",
                newName: "IsClosed");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Issues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_CreatedByUserId",
                table: "Issues",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_CreatedByUserId",
                table: "Issues",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_CreatedByUserId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CreatedByUserId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "IsClosed",
                table: "Issues",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Issues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Issues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
