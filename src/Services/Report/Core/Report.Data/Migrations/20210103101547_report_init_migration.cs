using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Report.Data.Migrations
{
    public partial class report_init_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact.ContactInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactInformationPK = table.Column<int>(type: "integer", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    InfoType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact.ContactInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportRequestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReportStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.UUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact.ContactInformation");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
