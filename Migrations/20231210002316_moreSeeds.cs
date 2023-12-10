using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbProject.Migrations
{
    public partial class moreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantDescription", "PlantName" },
                values: new object[,]
                {
                    { 5, "Azaleas bloom in the spring, their flowers often lasting several weeks.", "Azalea" },
                    { 6, "Most species originate from East Asia and the center of diversity is in China. Countless horticultural varieties and cultivars exist.", "Chrysanthemum" },
                    { 7, "Narcissus is a genus of predominantly spring flowering perennial plants of the amaryllis family, Amaryllidaceae. Various common names including daffodil, narcissus and jonquil, are used to describe all or some members of the genus.", "Daffodil" }
                });

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserPassword",
                value: "4tWbx5vN7mIYljZjsOsGhA==");
        }
    }
}
