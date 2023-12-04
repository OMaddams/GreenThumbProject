using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbProject.Migrations
{
    public partial class newPlantSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantDescription", "PlantName" },
                values: new object[] { 3, "A beautiful aquatic plant, considered holy in some cultures", "Lotus" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantDescription", "PlantName" },
                values: new object[] { 4, "Lilium is a genus of herbaceous flowering plants growing from bulbs, all with large prominent flowers. ", "Lily" });

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
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantDescription", "PlantName" },
                values: new object[] { 1, "A beautiful aquatic plant, considered holy in some cultures", "Lotus" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantDescription", "PlantName" },
                values: new object[] { 2, "Lilium is a genus of herbaceous flowering plants growing from bulbs, all with large prominent flowers. ", "Lily" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserPassword",
                value: "4tWbx5vN7mIYljZjsOsGhA==");
        }
    }
}
