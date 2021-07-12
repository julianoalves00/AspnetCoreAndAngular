using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddMessageGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikeUserID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_SourceUserID",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "SourceUserID",
                table: "Likes",
                newName: "SourceUserId");

            migrationBuilder.RenameColumn(
                name: "LikeUserID",
                table: "Likes",
                newName: "LikedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikeUserID",
                table: "Likes",
                newName: "IX_Likes_LikedUserId");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    GroupName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connections_Groups_GroupName",
                        column: x => x.GroupName,
                        principalTable: "Groups",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_GroupName",
                table: "Connections",
                column: "GroupName");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikedUserId",
                table: "Likes",
                column: "LikedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_SourceUserId",
                table: "Likes",
                column: "SourceUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikedUserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_SourceUserId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.RenameColumn(
                name: "SourceUserId",
                table: "Likes",
                newName: "SourceUserID");

            migrationBuilder.RenameColumn(
                name: "LikedUserId",
                table: "Likes",
                newName: "LikeUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikedUserId",
                table: "Likes",
                newName: "IX_Likes_LikeUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikeUserID",
                table: "Likes",
                column: "LikeUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_SourceUserID",
                table: "Likes",
                column: "SourceUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
