using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ClinicSystem.Database.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_type = table.Column<string>(type: "text", nullable: false),
                    account_login = table.Column<string>(type: "text", nullable: false),
                    account_password = table.Column<string>(type: "text", nullable: false),
                    account_fullname = table.Column<string>(type: "text", nullable: true),
                    account_birthdate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_patient_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "doctor_id",
                        column: x => x.appointment_doctor_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "patient_id",
                        column: x => x.appointment_patient_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "account_id", "account_birthdate", "account_fullname", "account_login", "account_password", "account_type" },
                values: new object[] { -1, null, "ofiOZJVxHpyu76gOTfW6sez8g9Y28VtqWDrZncfZAMFV63SY9rE91O/apj4ATT6r0t2dl9sdZn+IvnbiTLsvG68T1YiwS+ZC4g8oy91/wnaN3xjjGta35ljOrGr/DtOcyL6DcMcbFyTdqqVQhLeLbKcDcNdnmBItaJYu1yE+vA6OoRmZ4pUaJHwD+RXaiTWU6taIXpP1B3YiM3+pgCD0+JJDBBZkkBcd2oyB5zRBS6fQPLXRIQQ4oV39kHqIU1ZAkYBSc6cdBYLIcHcmk49KmosiyiaC2AhzA24NsUgDnMPee1h+pTrYhY3g7dsXIuQo7Pzy+VBfvAikaxu8/olVAQ==", "admin123", "i8cZhvSH898XlrwNtWmgXBmEFWaZXn1W3bbnzSQQB4mBkvgFYldPz3VDwWJEKgNxuDtTxs/zn1Q1WFKBwuVJtA5bQs7CRkPFvvxDAwQD6c2ELRikNxCRlmVByzMYZfkc2cEbmlaf1FqoxdcSglK2dMpbgaqLMrLy/+J9ucYWbb/ab1zgjr41EKMgPChfntJwNzjFbnJQ5JNOscHalVDn+ZFkm1nogfo8Rj/CQbeSTsky/o4aOGx0uAMZ+aXIIzYFKD/PddAE/qvawwRPJ8RzDYudRTt2fjGeWbZt20EHHUoLEERXGuTDMNSEshLlUbNoK5jVhqbQ9Eo3/4cRotzM6A==", "Admin" });

            migrationBuilder.CreateIndex(
                name: "fki_doctor_id",
                table: "appointments",
                column: "appointment_doctor_id");

            migrationBuilder.CreateIndex(
                name: "fki_patient_id",
                table: "appointments",
                column: "appointment_patient_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
