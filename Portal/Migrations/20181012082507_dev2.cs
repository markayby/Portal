using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class dev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELaDVDFHgyI0nUxJRT5K7JrZVBu6TM4k4+N8x9HQ7BLFpwXeN/jr6zor3wZbcx/GYg==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "RoleId" },
                values: new object[] { 2L, "user", "AQAAAAEAACcQAAAAEId5LaM9Xq/DsKwF+zrUS5cuFhLlDgfmACknwSYw9r4mKN+mB/RjCBe8qEuS0+hJrQ==", 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEMMX/774ip0njOqNAL6jBiMvRsDGfZU+JVquY1gCm2dGF9hZzcHrFWZhKclva7EzXA==");
        }
    }
}
