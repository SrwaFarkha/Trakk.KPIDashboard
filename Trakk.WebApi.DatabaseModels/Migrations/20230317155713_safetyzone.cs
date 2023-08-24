using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class safetyzone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SafetyZone",
                table: "VehicleEvents",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateTable(
                name: "CustomerFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeatures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "CustomerFeatureMaps",
                columns: table => new
                {
                    CustomerFeaturesId = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeatureMaps", x => new { x.CustomerFeaturesId, x.CustomersCustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerFeatureMaps_CustomerFeatures_CustomerFeaturesId",
                        column: x => x.CustomerFeaturesId,
                        principalTable: "CustomerFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeatureMaps_Customer_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "CustomerFeatureRightMaps",
                columns: table => new
                {
                    AccountRightsRightTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerFeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeatureRightMaps", x => new { x.AccountRightsRightTypeId, x.CustomerFeaturesId });
                    table.ForeignKey(
                        name: "FK_CustomerFeatureRightMaps_CustomerFeatures_CustomerFeaturesId",
                        column: x => x.CustomerFeaturesId,
                        principalTable: "CustomerFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeatureRightMaps_RightType_AccountRightsRightTypeId",
                        column: x => x.AccountRightsRightTypeId,
                        principalTable: "RightType",
                        principalColumn: "RightTypeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeatureMaps_CustomersCustomerId",
                table: "CustomerFeatureMaps",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeatureRightMaps_CustomerFeaturesId",
                table: "CustomerFeatureRightMaps",
                column: "CustomerFeaturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFeatureMaps");

            migrationBuilder.DropTable(
                name: "CustomerFeatureRightMaps");

            migrationBuilder.DropTable(
                name: "CustomerFeatures");

            migrationBuilder.DropColumn(
                name: "SafetyZone",
                table: "VehicleEvents");

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
        }
    }
}
