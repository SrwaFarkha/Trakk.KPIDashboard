using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Trakk.WebApi.DatabaseModels.Models;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class congestionTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var db = new TrakkDbContext();
            db.Database.ExecuteSqlRaw("TRUNCATE Passage;");
            db.Dispose();

            migrationBuilder.DropForeignKey(
                name: "FK_Passage_CongestionTaxDatas_CongestionTaxDataId",
                table: "Passage");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEvents_CongestionTaxDatas_CongestionTaxDataId",
                table: "VehicleEvents");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEvents_CongestionTaxDataId",
                table: "VehicleEvents");

            migrationBuilder.DropColumn(
                name: "CongestionTaxDataId",
                table: "VehicleEvents");

            migrationBuilder.RenameColumn(
                name: "TariffId",
                table: "Passage",
                newName: "BorderCrossingId");

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

            migrationBuilder.AlterColumn<int>(
                name: "CongestionTaxDataId",
                table: "Passage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VehicleEventId",
                table: "Passage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ViaEssingeleden",
                table: "Passage",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateIndex(
                name: "IX_Passage_VehicleEventId",
                table: "Passage",
                column: "VehicleEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passage_CongestionTaxDatas_CongestionTaxDataId",
                table: "Passage",
                column: "CongestionTaxDataId",
                principalTable: "CongestionTaxDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passage_VehicleEvents_VehicleEventId",
                table: "Passage",
                column: "VehicleEventId",
                principalTable: "VehicleEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passage_CongestionTaxDatas_CongestionTaxDataId",
                table: "Passage");

            migrationBuilder.DropForeignKey(
                name: "FK_Passage_VehicleEvents_VehicleEventId",
                table: "Passage");

            migrationBuilder.DropIndex(
                name: "IX_Passage_VehicleEventId",
                table: "Passage");

            migrationBuilder.DropColumn(
                name: "VehicleEventId",
                table: "Passage");

            migrationBuilder.DropColumn(
                name: "ViaEssingeleden",
                table: "Passage");

            migrationBuilder.RenameColumn(
                name: "BorderCrossingId",
                table: "Passage",
                newName: "TariffId");

            migrationBuilder.AddColumn<int>(
                name: "CongestionTaxDataId",
                table: "VehicleEvents",
                type: "int",
                nullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CongestionTaxDataId",
                table: "Passage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEvents_CongestionTaxDataId",
                table: "VehicleEvents",
                column: "CongestionTaxDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passage_CongestionTaxDatas_CongestionTaxDataId",
                table: "Passage",
                column: "CongestionTaxDataId",
                principalTable: "CongestionTaxDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEvents_CongestionTaxDatas_CongestionTaxDataId",
                table: "VehicleEvents",
                column: "CongestionTaxDataId",
                principalTable: "CongestionTaxDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
