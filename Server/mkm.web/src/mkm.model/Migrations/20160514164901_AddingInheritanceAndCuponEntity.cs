using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace mkm.model.Migrations
{
    public partial class AddingInheritanceAndCuponEntity : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_Post_Client_ClientId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_Post_User_UserId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.DropColumn(name: "ClientId", table: "Post");
            migrationBuilder.CreateTable(
                name: "Cupon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    InUse = table.Column<bool>(nullable: false),
                    OfertId = table.Column<long>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cupon_Ofert_OfertId",
                        column: x => x.OfertId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CancelationDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CuponId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Cupon_CuponId",
                        column: x => x.CuponId,
                        principalTable: "Cupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
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
                name: "FK_Post_Client_UserId",
                table: "Post",
                column: "UserId",
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
            migrationBuilder.DropForeignKey(name: "FK_Post_Client_UserId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_PostDenounce_Post_PostId", table: "PostDenounce");
            migrationBuilder.DropForeignKey(name: "FK_SharedPost_Post_PostId", table: "SharedPost");
            migrationBuilder.DropTable("Reservation");
            migrationBuilder.DropTable("Cupon");
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Post",
                nullable: true);
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
                name: "FK_Post_Client_ClientId",
                table: "Post",
                column: "ClientId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "IdentityUser",
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
