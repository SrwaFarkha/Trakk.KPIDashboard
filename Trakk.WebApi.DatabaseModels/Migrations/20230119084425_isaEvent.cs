using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class isaEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasIsaEventProcessor",
                table: "Vehicle",
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

            migrationBuilder.AddColumn<int>(
                name: "IsaEventId",
                table: "EventPositions",
                type: "int",
                nullable: true);

            // migrationBuilder.AlterColumn<Guid>(
            //     name: "Verification",
            //     table: "ChangeEmailTicket",
            //     type: "char(38)",
            //     fixedLength: true,
            //     maxLength: 38,
            //     nullable: false,
            //     defaultValueSql: "(uuid())",
            //     collation: "ascii_general_ci",
            //     oldClrType: typeof(string),
            //     oldType: "char(38)",
            //     oldFixedLength: true,
            //     oldMaxLength: 38,
            //     oldDefaultValueSql: "uuid()")
            //     .OldAnnotation("MySql:CharSet", "utf8mb4")
            //     .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

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
                name: "IsaEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleEventId = table.Column<int>(type: "int", nullable: false),
                    SpeedLimit = table.Column<double>(type: "double", nullable: false),
                    MaxSpeed = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsaEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsaEvents_VehicleEvents_VehicleEventId",
                        column: x => x.VehicleEventId,
                        principalTable: "VehicleEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_EventPositions_IsaEventId",
                table: "EventPositions",
                column: "IsaEventId");

            migrationBuilder.CreateIndex(
                name: "IX_IsaEvents_VehicleEventId",
                table: "IsaEvents",
                column: "VehicleEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPositions_IsaEvents_IsaEventId",
                table: "EventPositions",
                column: "IsaEventId",
                principalTable: "IsaEvents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPositions_IsaEvents_IsaEventId",
                table: "EventPositions");

            migrationBuilder.DropTable(
                name: "IsaEvents");

            migrationBuilder.DropIndex(
                name: "IX_EventPositions_IsaEventId",
                table: "EventPositions");

            migrationBuilder.DropColumn(
                name: "HasIsaEventProcessor",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsaEventId",
                table: "EventPositions");

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

            // migrationBuilder.AlterColumn<string>(
            //     name: "Verification",
            //     table: "ChangeEmailTicket",
            //     type: "char(38)",
            //     fixedLength: true,
            //     maxLength: 38,
            //     nullable: false,
            //     defaultValueSql: "uuid()",
            //     collation: "utf8mb4_general_ci",
            //     oldClrType: typeof(Guid),
            //     oldType: "char(38)",
            //     oldFixedLength: true,
            //     oldMaxLength: 38,
            //     oldDefaultValueSql: "(uuid())")
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .OldAnnotation("Relational:Collation", "ascii_general_ci");

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
