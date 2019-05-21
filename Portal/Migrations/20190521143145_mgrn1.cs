using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class mgrn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Requests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJ8OeBAtuYYufbF20oE8DJnsH0e5Ma9frXkfVFId/UvsUqhQarr3f24NGZesmo+0Ag==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEFQ35RAmzQNzdQiiHazO2eztGe8ZtgjLP6XjQqUxfjM4FYt4gMEf6xY3gUSzwLFVgQ==");
        }
    }
}
