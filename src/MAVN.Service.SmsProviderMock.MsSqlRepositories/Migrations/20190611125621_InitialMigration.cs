using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.SmsProviderMock.MsSqlRepositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sms");

            migrationBuilder.CreateTable(
                name: "sms",
                schema: "sms",
                columns: table => new
                {
                    message_id = table.Column<Guid>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    phone_number = table.Column<string>(maxLength: 20, nullable: false),
                    message = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms", x => x.message_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sms_message_id",
                schema: "sms",
                table: "sms",
                column: "message_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sms_phone_number",
                schema: "sms",
                table: "sms",
                column: "phone_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sms",
                schema: "sms");
        }
    }
}
