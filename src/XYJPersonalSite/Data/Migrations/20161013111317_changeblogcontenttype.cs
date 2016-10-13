using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYJPersonalSite.Data.Migrations
{
    public partial class changeblogcontenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Medias_ContentId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ContentId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ContentId",
                table: "Blogs",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Medias_ContentId",
                table: "Blogs",
                column: "ContentId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
