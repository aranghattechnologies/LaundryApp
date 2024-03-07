using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaundryApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProfilePic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilepicture",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilepicture",
                table: "customers");
        }
    }
}
