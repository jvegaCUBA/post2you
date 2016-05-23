using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace mkm.model.Migrations
{
    public partial class AddingIsDeletedToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Category_CategoryId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_CategoryPost_Post_PostId", table: "CategoryPost");
            migrationBuilder.DropForeignKey(name: "FK_Comment_Post_PostId", table: "Comment");
            migrationBuilder.DropForeignKey(name: "FK_Cupon_Ofert_OfertId", table: "Cupon");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Post_PostId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Like_Post_PostId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Cupon_CuponId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Resource_Post_PostId", table: "Resource");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post",
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
                name: "FK_Cupon_Ofert_OfertId",
                table: "Cupon",
                column: "OfertId",
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
                name: "FK_PostDenounce_Post_PostId",
                table: "PostDenounce",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Cupon_CuponId",
                table: "Reservation",
                column: "CuponId",
                principalTable: "Cupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Post_PostId",
                table: "Resource",
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
            migrationBuilder.DropForeignKey(name: "FK_Cupon_Ofert_OfertId", table: "Cupon");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Post_PostId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Like_Post_PostId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Cupon_CuponId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Resource_Post_PostId", table: "Resource");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.DropColumn(name: "IsDeleted", table: "Post");
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
                name: "FK_Cupon_Ofert_OfertId",
                table: "Cupon",
                column: "OfertId",
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
                name: "FK_Reservation_Cupon_CuponId",
                table: "Reservation",
                column: "CuponId",
                principalTable: "Cupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Post_PostId",
                table: "Resource",
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
