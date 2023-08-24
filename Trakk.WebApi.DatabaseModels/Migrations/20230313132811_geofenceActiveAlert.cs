using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class geofenceActiveAlert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveAlert_GeofenceEvent",
                table: "ActiveAlert");

            migrationBuilder.AlterColumn<Guid>(
                name: "PasswordRecoveryId",
                table: "PasswordRecovery",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Verification",
                table: "ChangeEmailTicket",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                defaultValueSql: "(uuid())",
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38,
                oldDefaultValueSql: "(uuid())")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TokenGuid",
                table: "AccountToken",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountConfirmationId",
                table: "AccountConfirmation",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "GUID",
                table: "Account",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveAlert_GeofenceEvent",
                table: "ActiveAlert",
                column: "GeofenceEventId",
                principalTable: "GeofenceEvent",
                principalColumn: "GeofenceEventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveAlert_GeofenceEvent",
                table: "ActiveAlert");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordRecoveryId",
                table: "PasswordRecovery",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Verification",
                table: "ChangeEmailTicket",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                defaultValueSql: "(uuid())",
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38,
                oldDefaultValueSql: "(uuid())")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "TokenGuid",
                table: "AccountToken",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "AccountConfirmationId",
                table: "AccountConfirmation",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "GUID",
                table: "Account",
                type: "char(38)",
                fixedLength: true,
                maxLength: 38,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(38)",
                oldFixedLength: true,
                oldMaxLength: 38)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveAlert_GeofenceEvent",
                table: "ActiveAlert",
                column: "GeofenceEventId",
                principalTable: "GeofenceEvent",
                principalColumn: "GeofenceEventId");
        }
    }
}
