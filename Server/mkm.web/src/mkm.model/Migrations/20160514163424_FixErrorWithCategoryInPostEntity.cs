using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace mkm.model.Migrations
{
    public partial class FixErrorWithCategoryInPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Category_CategoryId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Post_PostId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_Comment_Post_PostId", table: "Comment");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Post_PostId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Like_Post_PostId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                nullable: false);
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Post",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "BusinessId",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "RealCupons",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "RealPrice",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "ReservedCupons",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "ActiveOfertCount",
                table: "IdentityUser",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "IdentityUser",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "OfertCount",
                table: "IdentityUser",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "ActiveReservations",
                table: "IdentityUser",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "ReservationsCount",
                table: "IdentityUser",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Category_CategoryId",
                table: "CategoryPost",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Post_PostId",
                table: "CategoryPost",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Post_PostId",
                table: "Favorite",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Ofert_Business_BusinessId",
                table: "Post",
                column: "BusinessId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Post_Client_ClientId",
                table: "Post",
                column: "ClientId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PostDenounce_Post_PostId",
                table: "PostDenounce",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SharedPost_Post_PostId",
                table: "SharedPost",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Category_CategoryId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Post_PostId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_Comment_Post_PostId", table: "Comment");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Post_PostId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Like_Post_PostId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_Ofert_Business_BusinessId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_Post_Client_ClientId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.DropColumn(name: "ClientId", table: "Post");
            migrationBuilder.DropColumn(name: "Discriminator", table: "Post");
            migrationBuilder.DropColumn(name: "BusinessId", table: "Post");
            migrationBuilder.DropColumn(name: "Capacity", table: "Post");
            migrationBuilder.DropColumn(name: "DiscountPercent", table: "Post");
            migrationBuilder.DropColumn(name: "DiscountPrice", table: "Post");
            migrationBuilder.DropColumn(name: "DueDate", table: "Post");
            migrationBuilder.DropColumn(name: "FinishDate", table: "Post");
            migrationBuilder.DropColumn(name: "IsActive", table: "Post");
            migrationBuilder.DropColumn(name: "RealCupons", table: "Post");
            migrationBuilder.DropColumn(name: "RealPrice", table: "Post");
            migrationBuilder.DropColumn(name: "ReservedCupons", table: "Post");
            migrationBuilder.DropColumn(name: "StartDate", table: "Post");
            migrationBuilder.DropColumn(name: "ActiveOfertCount", table: "IdentityUser");
            migrationBuilder.DropColumn(name: "ActivityDescription", table: "IdentityUser");
            migrationBuilder.DropColumn(name: "OfertCount", table: "IdentityUser");
            migrationBuilder.DropColumn(name: "ActiveReservations", table: "IdentityUser");
            migrationBuilder.DropColumn(name: "ReservationsCount", table: "IdentityUser");
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2016, 5, 14, 16, 0, 46, 365, DateTimeKind.Unspecified));
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Category_CategoryId",
                table: "CategoryPost",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Post_PostId",
                table: "CategoryPost",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Post_PostId",
                table: "Favorite",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PostDenounce_Post_PostId",
                table: "PostDenounce",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SharedPost_Post_PostId",
                table: "SharedPost",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
