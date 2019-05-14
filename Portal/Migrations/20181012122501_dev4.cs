using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class dev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heads",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    Surname = table.Column<string>(maxLength: 120, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heads", x => x.Email);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDYQl21USY/Omwdcklx4kZCjvnCJia8scxew+ZQUeRzgf8Fef2sg/qOGqaEpraOpXg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKEqmNQprAJMagc4KjA6pTQwdLvNnMT7btSa2wJoPBICCRTVnhs+0MD0jzHLZI2QKA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heads");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELaDVDFHgyI0nUxJRT5K7JrZVBu6TM4k4+N8x9HQ7BLFpwXeN/jr6zor3wZbcx/GYg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEId5LaM9Xq/DsKwF+zrUS5cuFhLlDgfmACknwSYw9r4mKN+mB/RjCBe8qEuS0+hJrQ==");
        }
    }
}
