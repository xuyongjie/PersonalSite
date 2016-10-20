using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYJPersonalSite.Data.Migrations
{
    public partial class addblogtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(nullable: false),
                    ThisTypeBlogCount = table.Column<int>(nullable: false),
                    TypeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTypes", x => x.TypeName);
                });

            migrationBuilder.AddColumn<string>(
                name: "BlogTypeName",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogTypeTypeName",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogTypeTypeName",
                table: "Blogs",
                column: "BlogTypeTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeTypeName",
                table: "Blogs",
                column: "BlogTypeTypeName",
                principalTable: "BlogTypes",
                principalColumn: "TypeName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeTypeName",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogTypeTypeName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogTypeName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogTypeTypeName",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogTypes");
        }
    }
}
