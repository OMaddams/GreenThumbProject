using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbProject.Migrations
{
    public partial class instructionSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "InstructionDescription", "PlantId" },
                values: new object[] { 1, "Keep it in your pond", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserPassword",
                value: "4tWbx5vN7mIYljZjsOsGhA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserPassword",
                value: "4tWbx5vN7mIYljZjsOsGhA==");
        }
    }
}
