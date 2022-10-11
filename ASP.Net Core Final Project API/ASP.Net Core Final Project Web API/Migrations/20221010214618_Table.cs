using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Net_Core_FinalProject_API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    wfm_manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lockstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftLock",
                columns: table => new
                {
                    lockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reqdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestmessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    managerstatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftLock", x => x.lockId);
                    table.ForeignKey(
                        name: "FK_SoftLock_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employee_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsMap",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsMap", x => new { x.employee_Id, x.skillId });
                    table.ForeignKey(
                        name: "FK_SkillsMap_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsMap_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_Id", "email", "Experience", "lockstatus", "manager", "name", "wfm_manager" },
                values: new object[] { 1, "mohan@gmail.com", 2, "not_requested", "sathees", "mohan", "Sabari" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "skillId", "name" },
                values: new object[] { 1, "javascript" });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMap_skillId",
                table: "SkillsMap",
                column: "skillId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftLock_employee_Id",
                table: "SoftLock",
                column: "employee_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsMap");

            migrationBuilder.DropTable(
                name: "SoftLock");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
