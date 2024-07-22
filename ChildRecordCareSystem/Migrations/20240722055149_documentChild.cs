using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildRecordCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class documentChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Doument1",
                table: "Children",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doument2",
                table: "Children",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doument3",
                table: "Children",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doument1",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Doument2",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Doument3",
                table: "Children");
        }
    }
}
