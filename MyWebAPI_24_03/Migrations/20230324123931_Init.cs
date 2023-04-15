using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPI_24_03.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIConnectDb",
                columns: table => new
                {
                    ConnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conn = table.Column<bool>(type: "bit", nullable: false),
                    UserClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIConnectDb", x => x.ConnId);
                });

            migrationBuilder.CreateTable(
                name: "APIDataDb",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartStop = table.Column<bool>(type: "bit", nullable: false),
                    CmdMotor = table.Column<bool>(type: "bit", nullable: false),
                    DataTemperature = table.Column<double>(type: "float", nullable: false),
                    DataLevel = table.Column<double>(type: "float", nullable: false),
                    TimeStanp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIDataDb", x => x.DataId);
                });

            migrationBuilder.CreateTable(
                name: "APINameClientDb",
                columns: table => new
                {
                    NameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePLC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APINameClientDb", x => x.NameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIConnectDb");

            migrationBuilder.DropTable(
                name: "APIDataDb");

            migrationBuilder.DropTable(
                name: "APINameClientDb");
        }
    }
}
