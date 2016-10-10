using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYJPersonalSite.Data.Migrations
{
    public partial class edit_datatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToCommentId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToCommentId",
                table: "Comments");
        }
    }
}
