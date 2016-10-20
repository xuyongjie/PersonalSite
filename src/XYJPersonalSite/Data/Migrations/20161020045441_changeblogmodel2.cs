using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYJPersonalSite.Data.Migrations
{
    public partial class changeblogmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TypeName",
                table: "Blogs",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogTypes_TypeName",
                table: "Blogs",
                column: "TypeName",
                principalTable: "BlogTypes",
                principalColumn: "TypeName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogTypes_TypeName",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TypeName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Blogs");

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
    }
}
