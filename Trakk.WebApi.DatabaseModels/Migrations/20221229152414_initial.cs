using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        public static bool Apply = false;
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (Apply)
            {
                migrationBuilder.AlterDatabase()
                    .Annotation("MySql:CharSet", "utf8mb4");

                // migrationBuilder.CreateSequence<int>(
                //     name: "UnitId_Counter");

                migrationBuilder.CreateTable(
                        name: "AccountEventType",
                        columns: table => new
                        {
                            AccountEventTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.AccountEventTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountRole",
                        columns: table => new
                        {
                            AccountRoleId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.AccountRoleId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountToken",
                        columns: table => new
                        {
                            AccountTokenId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            TokenGuid = table.Column<Guid>(type: "char(38)", fixedLength: true, maxLength: 38,
                                nullable: false, collation: "ascii_general_ci"),
                            IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            Token = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.AccountTokenId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Agreement",
                        columns: table => new
                        {
                            AgreementId = table.Column<int>(type: "int", nullable: false),
                            AgreementNumber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            UnitId = table.Column<int>(type: "int", nullable: false),
                            ValidTo = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            Comment = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Reference = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Finance = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.AgreementId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CategoryType",
                        columns: table => new
                        {
                            CategoryTypeId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: true),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.CategoryTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CommunicationEventType",
                        columns: table => new
                        {
                            CommunicationEventTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.CommunicationEventTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CongestionTaxDatas",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.Id); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CustomerAdmin",
                        columns: table => new
                        {
                            CustomerAdminId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ContactName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ContactEmail = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ContactPhoneNumber = table.Column<string>(type: "varchar(250)", maxLength: 250,
                                    nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IsLocked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.CustomerAdminId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "DBSettings",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            IsIntegrationTestDB = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.Id); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "DriverEventType",
                        columns: table => new
                        {
                            DriverEventTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.DriverEventTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ErrorLog",
                        columns: table => new
                        {
                            ErrorLogId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Http = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Message = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            StackTrace = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Created = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.ErrorLogId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeocodedPosition",
                        columns: table => new
                        {
                            GeocodedPositionId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Street = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            HouseNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            City = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PostalCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Country = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Label = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            Latitude = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4,
                                nullable: false),
                            Longitude = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4,
                                nullable: false)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.GeocodedPositionId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeofenceType",
                        columns: table => new
                        {
                            GeofenceTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.GeofenceTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "HardwareStatus",
                        columns: table => new
                        {
                            HardwareStatusId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.HardwareStatusId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "HardwareType",
                        columns: table => new
                        {
                            HardwareTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Url = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            HasSimCardSlot = table.Column<bool>(type: "tinyint(1)", nullable: false,
                                defaultValueSql: "'1'"),
                            HasExternalBattery = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.HardwareTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Icon",
                        columns: table => new
                        {
                            IconId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Url = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.IconId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobIntervalType",
                        columns: table => new
                        {
                            JobIntervalTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.JobIntervalTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobType",
                        columns: table => new
                        {
                            JobTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.JobTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Language",
                        columns: table => new
                        {
                            LanguageId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.LanguageId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "RightType",
                        columns: table => new
                        {
                            RightTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.RightTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "RootAccountType",
                        columns: table => new
                        {
                            RootAccountTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.RootAccountTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Route",
                        columns: table => new
                        {
                            RouteId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            RouteHandle = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.RouteId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Schedules",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            OverrideTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            TimeZoneInfo = table.Column<string>(type: "longtext", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.Id); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Service",
                        columns: table => new
                        {
                            ServiceId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.ServiceId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "SmsOperator",
                        columns: table => new
                        {
                            SmsOperatorId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Apn = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            User = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.SmsOperatorId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "UserEvents",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            EventType = table.Column<int>(type: "int", nullable: false),
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            IpAddress = table.Column<string>(type: "longtext", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                            TargetType = table.Column<string>(type: "longtext", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            TargetId = table.Column<int>(type: "int", nullable: true),
                            Properties = table.Column<string>(type: "longtext", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PK_UserEvents", x => x.Id); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "VehicleReminderType",
                        columns: table => new
                        {
                            VehicleReminderTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.VehicleReminderTypeId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Category",
                        columns: table => new
                        {
                            CategoryId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            CategoryTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.CategoryId);
                            table.ForeignKey(
                                name: "FK_CategoryType",
                                column: x => x.CategoryTypeId,
                                principalTable: "CategoryType",
                                principalColumn: "CategoryTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Passage",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CongestionTaxDataId = table.Column<int>(type: "int", nullable: false),
                            Area = table.Column<int>(type: "int", nullable: false),
                            TaxBorder = table.Column<int>(type: "int", nullable: false),
                            PassageTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                            TariffId = table.Column<int>(type: "int", nullable: true),
                            Cost = table.Column<double>(type: "double", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Passage", x => x.Id);
                            table.ForeignKey(
                                name: "FK_Passage_CongestionTaxDatas_CongestionTaxDataId",
                                column: x => x.CongestionTaxDataId,
                                principalTable: "CongestionTaxDatas",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "SalesPerson",
                        columns: table => new
                        {
                            SalesPersonId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            CustomerAdminId = table.Column<int>(type: "int", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.SalesPersonId);
                            table.ForeignKey(
                                name: "FK_SalesPerson_CustomerAdmin_CustomerAdminId",
                                column: x => x.CustomerAdminId,
                                principalTable: "CustomerAdmin",
                                principalColumn: "CustomerAdminId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Position",
                        columns: table => new
                        {
                            PositionId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: false),
                            Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: false),
                            GeocodedPositionId = table.Column<int>(type: "int", nullable: true),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.PositionId);
                            table.ForeignKey(
                                name: "FK_GeocodedPosition",
                                column: x => x.GeocodedPositionId,
                                principalTable: "GeocodedPosition",
                                principalColumn: "GeocodedPositionId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "SmsCommand",
                        columns: table => new
                        {
                            SmsCommandId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Command = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            HardwareTypeId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.SmsCommandId);
                            table.ForeignKey(
                                name: "FK_SmsCommand_HardwareType",
                                column: x => x.HardwareTypeId,
                                principalTable: "HardwareType",
                                principalColumn: "HardwareTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "HardwareConfig",
                        columns: table => new
                        {
                            HardwareConfigId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IconId = table.Column<int>(type: "int", nullable: false),
                            VibrationSensitivity = table.Column<int>(type: "int", nullable: true),
                            SecondsStillUntilStop = table.Column<int>(type: "int", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.HardwareConfigId);
                            table.ForeignKey(
                                name: "FK_HardwareConfig_Icon",
                                column: x => x.IconId,
                                principalTable: "Icon",
                                principalColumn: "IconId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "RootAccount",
                        columns: table => new
                        {
                            RootAccountId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            RootAccountTypeId = table.Column<int>(type: "int", nullable: false),
                            UserName = table.Column<string>(type: "varchar(255)", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            CustomerAdminId = table.Column<int>(type: "int", nullable: true),
                            IsLocked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.RootAccountId);
                            table.ForeignKey(
                                name: "FK_RootAccount_CustomerAdmin",
                                column: x => x.CustomerAdminId,
                                principalTable: "CustomerAdmin",
                                principalColumn: "CustomerAdminId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_RootAccount_RootAccountType",
                                column: x => x.RootAccountTypeId,
                                principalTable: "RootAccountType",
                                principalColumn: "RootAccountTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ScheduleEntries",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                            StopTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                            ActiveDays = table.Column<string>(type: "longtext", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ScheduleId = table.Column<int>(type: "int", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.Id);
                            table.ForeignKey(
                                name: "FK_ScheduleEntries_Schedules_ScheduleId",
                                column: x => x.ScheduleId,
                                principalTable: "Schedules",
                                principalColumn: "Id");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "VehicleReminder",
                        columns: table => new
                        {
                            VehicleReminderId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            VehicleReminderTypeId = table.Column<int>(type: "int", nullable: false),
                            OdometerBreakpoint = table.Column<int>(type: "int", nullable: true),
                            ReminderDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            IsTriggered = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.VehicleReminderId);
                            table.ForeignKey(
                                name: "FK_VehicleReminder_Vehicle",
                                column: x => x.VehicleReminderTypeId,
                                principalTable: "VehicleReminderType",
                                principalColumn: "VehicleReminderTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Customer",
                        columns: table => new
                        {
                            CustomerId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Information = table.Column<string>(type: "longtext", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            UpdatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            CustomerAdminId = table.Column<int>(type: "int", nullable: true),
                            IsLocked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            Comment = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ZipCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            City = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            SalesPersonId = table.Column<int>(type: "int", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.CustomerId);
                            table.ForeignKey(
                                name: "FK_Customer_CustomerAdminId",
                                column: x => x.CustomerAdminId,
                                principalTable: "CustomerAdmin",
                                principalColumn: "CustomerAdminId");
                            table.ForeignKey(
                                name: "FK_Customer_SalesPerson_SalesPersonId",
                                column: x => x.SalesPersonId,
                                principalTable: "SalesPerson",
                                principalColumn: "SalesPersonId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "BaseStation",
                        columns: table => new
                        {
                            BaseStationId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            IdetityCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true,
                                    defaultValueSql: "'MCC + MNC + LAC + CELLID'", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PositionId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.BaseStationId);
                            table.ForeignKey(
                                name: "FK_BaseStation_Position",
                                column: x => x.PositionId,
                                principalTable: "Position",
                                principalColumn: "PositionId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ArchivedUnitsCustomer",
                        columns: table => new
                        {
                            ArchivedUnitsCustomerId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerAdminId = table.Column<int>(type: "int", nullable: true),
                            CustomerId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.ArchivedUnitsCustomerId);
                            table.ForeignKey(
                                name: "FK_ArchivedUnitsCustomer_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_ArchivedUnitsCustomer_CustomerAdmin",
                                column: x => x.CustomerAdminId,
                                principalTable: "CustomerAdmin",
                                principalColumn: "CustomerAdminId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Contact",
                        columns: table => new
                        {
                            ContactId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            AlertTypes = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.ContactId);
                            table.ForeignKey(
                                name: "FK_Contact_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CustomerFuelPrices",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            Petrol = table.Column<double>(type: "double", nullable: false),
                            Diesel = table.Column<double>(type: "double", nullable: false),
                            E85 = table.Column<double>(type: "double", nullable: false),
                            Electric = table.Column<double>(type: "double", nullable: false),
                            Gas = table.Column<double>(type: "double", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.Id);
                            table.ForeignKey(
                                name: "FK_CustomerFuelPrices_Customer_CustomerId",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CustomerServiceMap",
                        columns: table => new
                        {
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            ServiceId = table.Column<int>(type: "int", nullable: false),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            ValidUntil = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            ValueData = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.CustomerId, x.ServiceId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_CustomerServiceMap_Service",
                                column: x => x.ServiceId,
                                principalTable: "Service",
                                principalColumn: "ServiceId");
                            table.ForeignKey(
                                name: "FK_CustomerServiceMap_UserAccount",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Geofence",
                        columns: table => new
                        {
                            GeofenceId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            ScheduleId = table.Column<int>(type: "int", nullable: true),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            GeofenceTypeId = table.Column<int>(type: "int", nullable: false),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            Geography = table.Column<Geometry>(type: "geometry", nullable: false),
                            BufferRadius = table.Column<int>(type: "int", nullable: true),
                            IsTimeControlled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            TimezoneId = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    defaultValueSql: "'UTC'", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ActiveForAllUnits = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.GeofenceId);
                            table.ForeignKey(
                                name: "FK_Geofence_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_Geofence_GeofenceType",
                                column: x => x.GeofenceTypeId,
                                principalTable: "GeofenceType",
                                principalColumn: "GeofenceTypeId");
                            table.ForeignKey(
                                name: "FK_Geofence_Schedules_ScheduleId",
                                column: x => x.ScheduleId,
                                principalTable: "Schedules",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Group",
                        columns: table => new
                        {
                            GroupId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.GroupId);
                            table.ForeignKey(
                                name: "FK_Group_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Hardware",
                        columns: table => new
                        {
                            HardwareId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            GlobalDeviceId = table.Column<string>(type: "varchar(255)", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ICC = table.Column<string>(type: "varchar(255)", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            HardwareTypeId = table.Column<int>(type: "int", nullable: false),
                            HardwareStatusId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                            CustomerAdminId = table.Column<int>(type: "int", nullable: true),
                            Comment = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            // UnitId = table.Column<int>(type: "int", nullable: false,
                            //     defaultValueSql: "nextval(`trakk-alpha-api`.`UnitId_Counter`)"),
                            HardwareConfigId = table.Column<int>(type: "int", nullable: true),
                            OffGridThresholdSeconds =
                                table.Column<int>(type: "int", nullable: false, defaultValueSql: "'604800'"),
                            CustomerId = table.Column<int>(type: "int", nullable: true),
                            SentToCustomer = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            BillingType = table.Column<int>(type: "int", nullable: false),
                            FinancePartner = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.HardwareId);
                            table.ForeignKey(
                                name: "FK_Hardware_CustomerAdmin",
                                column: x => x.CustomerAdminId,
                                principalTable: "CustomerAdmin",
                                principalColumn: "CustomerAdminId");
                            table.ForeignKey(
                                name: "FK_Hardware_Customer_CustomerId",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_Hardware_HardwareConfig",
                                column: x => x.HardwareConfigId,
                                principalTable: "HardwareConfig",
                                principalColumn: "HardwareConfigId");
                            table.ForeignKey(
                                name: "FK_Hardware_HardwareStatus",
                                column: x => x.HardwareStatusId,
                                principalTable: "HardwareStatus",
                                principalColumn: "HardwareStatusId");
                            table.ForeignKey(
                                name: "FK_Hardware_HardwareType",
                                column: x => x.HardwareTypeId,
                                principalTable: "HardwareType",
                                principalColumn: "HardwareTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Mapzone",
                        columns: table => new
                        {
                            MapzoneId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: false),
                            Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: false),
                            ZoomLevel = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.MapzoneId);
                            table.ForeignKey(
                                name: "FK_Mapzone_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Account",
                        columns: table => new
                        {
                            AccountId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            GUID = table.Column<Guid>(type: "char(38)", fixedLength: true, maxLength: 38,
                                nullable: false, collation: "ascii_general_ci"),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            AccountRoleId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            UpdatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            ValidUntil = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            TimeZoneId = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    defaultValueSql: "'UTC'", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IsEmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            IsLockedOut = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            LanguageId = table.Column<int>(type: "int", nullable: false),
                            IconSizePixels = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'32'"),
                            SpeedUnit = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true,
                                    defaultValueSql: "'kmh'", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            HomeLatitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: true),
                            HomeLongitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6,
                                nullable: true),
                            ContactId = table.Column<int>(type: "int", nullable: false),
                            LoginName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PasswordEncrypted = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.AccountId);
                            table.ForeignKey(
                                name: "FK_Account_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId");
                            table.ForeignKey(
                                name: "FK_Account_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_Account_Language",
                                column: x => x.LanguageId,
                                principalTable: "Language",
                                principalColumn: "LanguageId");
                            table.ForeignKey(
                                name: "FK_Account_UserRole",
                                column: x => x.AccountRoleId,
                                principalTable: "AccountRole",
                                principalColumn: "AccountRoleId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "VehicleReminderContactMap",
                        columns: table => new
                        {
                            VehicleReminderId = table.Column<int>(type: "int", nullable: false),
                            ContactId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.VehicleReminderId, x.ContactId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_VehicleReminderContactMap_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_VehicleReminderContactMap_VehicleReminder",
                                column: x => x.VehicleReminderId,
                                principalTable: "VehicleReminder",
                                principalColumn: "VehicleReminderId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeofenceContactMap",
                        columns: table => new
                        {
                            GeofenceId = table.Column<int>(type: "int", nullable: false),
                            ContactId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.GeofenceId, x.ContactId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_GeofenceContactMap_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_GeofenceContactMap_Geofence",
                                column: x => x.GeofenceId,
                                principalTable: "Geofence",
                                principalColumn: "GeofenceId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ContactGroupMap",
                        columns: table => new
                        {
                            ContactId = table.Column<int>(type: "int", nullable: false),
                            GroupId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.ContactId, x.GroupId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_ContactGroupMap_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_ContactGroupMap_Group",
                                column: x => x.GroupId,
                                principalTable: "Group",
                                principalColumn: "GroupId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeofenceGroupMap",
                        columns: table => new
                        {
                            GeofenceId = table.Column<int>(type: "int", nullable: false),
                            GroupId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.GeofenceId, x.GroupId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_GeofenceGroupMap_Geofence",
                                column: x => x.GeofenceId,
                                principalTable: "Geofence",
                                principalColumn: "GeofenceId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_GeofenceGroupMap_Group",
                                column: x => x.GroupId,
                                principalTable: "Group",
                                principalColumn: "GroupId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountConfirmation",
                        columns: table => new
                        {
                            AccountConfirmationId = table.Column<Guid>(type: "char(38)", fixedLength: true,
                                maxLength: 38, nullable: false, collation: "ascii_general_ci"),
                            AccountId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.AccountConfirmationId, x.AccountId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_AccountConfirmation_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountEvent",
                        columns: table => new
                        {
                            AccountEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            AccountEventTypeId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            EventData = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.AccountEventId);
                            table.ForeignKey(
                                name: "FK_AccountEvent_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_AccountEvent_EventType",
                                column: x => x.AccountEventTypeId,
                                principalTable: "AccountEventType",
                                principalColumn: "AccountEventTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountGroupMap",
                        columns: table => new
                        {
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            GroupId = table.Column<int>(type: "int", nullable: false),
                            Access = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            IsFavorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            IsPersonal = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.AccountId, x.GroupId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_AccountGroupMap_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_AccountGroupMap_Group",
                                column: x => x.GroupId,
                                principalTable: "Group",
                                principalColumn: "GroupId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountRightMap",
                        columns: table => new
                        {
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            RightTypeId = table.Column<int>(type: "int", nullable: false),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            ValidUntil = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            ValueData = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.AccountId, x.RightTypeId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_AccountRightMap_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId");
                            table.ForeignKey(
                                name: "FK_AccountRightTypeMap_RightType",
                                column: x => x.RightTypeId,
                                principalTable: "RightType",
                                principalColumn: "RightTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ChangeEmailTicket",
                        columns: table => new
                        {
                            ChangeEmailTicketId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            OldEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            NewEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            ValidUntil = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            Verification = table.Column<Guid>(type: "char(38)", fixedLength: true, maxLength: 38,
                                nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.ChangeEmailTicketId);
                            table.ForeignKey(
                                name: "FK_ChangeEmailTicket_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CommunicationEvent",
                        columns: table => new
                        {
                            CommunicationEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            CommunicationEventTypeId = table.Column<int>(type: "int", nullable: false),
                            Sender = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Receiver = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Subject = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Message = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IsSent = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.CommunicationEventId);
                            table.ForeignKey(
                                name: "FK_CommunicationEvent_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId");
                            table.ForeignKey(
                                name: "FK_CommunicationEvent_CommunicationEventType",
                                column: x => x.CommunicationEventTypeId,
                                principalTable: "CommunicationEventType",
                                principalColumn: "CommunicationEventTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Driver",
                        columns: table => new
                        {
                            DriverId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            AccountId = table.Column<int>(type: "int", nullable: true),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.DriverId);
                            table.ForeignKey(
                                name: "FK_Driver_AccountId",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.SetNull);
                            table.ForeignKey(
                                name: "FK_Driver_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "DriverSettings",
                        columns: table => new
                        {
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            WorkStartMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartSaturday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndSaturday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkStartSunday = table.Column<TimeSpan>(type: "time", nullable: true),
                            WorkEndSunday = table.Column<TimeSpan>(type: "time", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.AccountId);
                            table.ForeignKey(
                                name: "FK_DriverSettings_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Job",
                        columns: table => new
                        {
                            JobId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: true),
                            AccountId = table.Column<int>(type: "int", nullable: true),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            JobTypeId = table.Column<int>(type: "int", nullable: false),
                            JobIntervalTypeId = table.Column<int>(type: "int", nullable: false),
                            Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            NextOccurrence = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            OdometerMeter = table.Column<int>(type: "int", nullable: true),
                            OperationTimeHours = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4,
                                nullable: true),
                            Arguments = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ArgumentType = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.JobId);
                            table.ForeignKey(
                                name: "FK_Job_Account_AccountId",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_Job_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_Job_JobIntervalType",
                                column: x => x.JobIntervalTypeId,
                                principalTable: "JobIntervalType",
                                principalColumn: "JobIntervalTypeId");
                            table.ForeignKey(
                                name: "FK_Job_JobType",
                                column: x => x.JobTypeId,
                                principalTable: "JobType",
                                principalColumn: "JobTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "PasswordRecovery",
                        columns: table => new
                        {
                            PasswordRecoveryId = table.Column<Guid>(type: "char(38)", fixedLength: true, maxLength: 38,
                                nullable: false, collation: "ascii_general_ci"),
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            ValidUntil = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.PasswordRecoveryId);
                            table.ForeignKey(
                                name: "FK_PasswordRecovery_AccountId",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "DriverEvent",
                        columns: table => new
                        {
                            DriverEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            DriverId = table.Column<int>(type: "int", nullable: false),
                            DriverEventTypeId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            EventData = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.DriverEventId);
                            table.ForeignKey(
                                name: "FK_DriverEvent_Driver",
                                column: x => x.DriverId,
                                principalTable: "Driver",
                                principalColumn: "DriverId");
                            table.ForeignKey(
                                name: "FK_DriverEvent_DriverEventType",
                                column: x => x.DriverEventTypeId,
                                principalTable: "DriverEventType",
                                principalColumn: "DriverEventTypeId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "EmailAddresses",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            EmailAddress = table.Column<string>(type: "longtext", nullable: false,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            JobId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                            table.ForeignKey(
                                name: "FK_EmailAddresses_Job_JobId",
                                column: x => x.JobId,
                                principalTable: "Job",
                                principalColumn: "JobId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobContactMap",
                        columns: table => new
                        {
                            JobId = table.Column<int>(type: "int", nullable: false),
                            ContactId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.JobId, x.ContactId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_JobContactMap_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_JobContactMap_Task",
                                column: x => x.JobId,
                                principalTable: "Job",
                                principalColumn: "JobId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobGroupMap",
                        columns: table => new
                        {
                            JobId = table.Column<int>(type: "int", nullable: false),
                            GroupId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.JobId, x.GroupId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_JobGroupMap_Group",
                                column: x => x.GroupId,
                                principalTable: "Group",
                                principalColumn: "GroupId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_JobGroupMap_Job",
                                column: x => x.JobId,
                                principalTable: "Job",
                                principalColumn: "JobId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AccountTrakkerMap",
                        columns: table => new
                        {
                            AccountId = table.Column<int>(type: "int", nullable: false),
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            IsFavorite = table.Column<bool>(type: "tinyint(1)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.AccountId, x.TrakkerId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_AccountTrakkerMap_Account",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "ActiveAlert",
                        columns: table => new
                        {
                            ActiveAlertId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            TrakkerEventId = table.Column<int>(type: "int", nullable: false),
                            GeofenceEventId = table.Column<int>(type: "int", nullable: true)
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.ActiveAlertId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Asset",
                        columns: table => new
                        {
                            AssetId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            SecondsStillUntilStop = table.Column<int>(type: "int", nullable: false),
                            OperationTimeCounter = table.Column<int>(type: "int", nullable: false),
                            LatestAssetEventId = table.Column<int>(type: "int", nullable: true),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)")
                        },
                        constraints: table => { table.PrimaryKey("PRIMARY", x => x.AssetId); })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "AssetEvent",
                        columns: table => new
                        {
                            AssetEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            AssetId = table.Column<int>(type: "int", nullable: false),
                            AssetEventTypeId = table.Column<int>(type: "int", nullable: false),
                            PositionId = table.Column<int>(type: "int", nullable: true),
                            PositionOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            StartDateTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            StopDateTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            GeofenceName = table.Column<string>(type: "varchar(255)", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Comment = table.Column<string>(type: "varchar(255)", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            PrivateOperationTime = table.Column<long>(type: "bigint(20)", nullable: false),
                            WorkOperationTime = table.Column<long>(type: "bigint(20)", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.AssetEventId);
                            table.ForeignKey(
                                name: "FK_AssetEvent_Asset",
                                column: x => x.AssetId,
                                principalTable: "Asset",
                                principalColumn: "AssetId");
                            table.ForeignKey(
                                name: "FK_AssetEvent_Position",
                                column: x => x.PositionId,
                                principalTable: "Position",
                                principalColumn: "PositionId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CategoryAssetMap",
                        columns: table => new
                        {
                            CategoryId = table.Column<int>(type: "int", nullable: false),
                            AssetId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.CategoryId, x.AssetId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_CategoryAssetMap_Asset",
                                column: x => x.AssetId,
                                principalTable: "Asset",
                                principalColumn: "AssetId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_CategoryAssetMap_Category",
                                column: x => x.CategoryId,
                                principalTable: "Category",
                                principalColumn: "CategoryId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobAssetMap",
                        columns: table => new
                        {
                            JobId = table.Column<int>(type: "int", nullable: false),
                            AssetId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.JobId, x.AssetId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_JobAssetMap_Asset",
                                column: x => x.AssetId,
                                principalTable: "Asset",
                                principalColumn: "AssetId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_JobAssetMap_Job",
                                column: x => x.JobId,
                                principalTable: "Job",
                                principalColumn: "JobId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CategoryTrakkerMap",
                        columns: table => new
                        {
                            CategoryId = table.Column<int>(type: "int", nullable: false),
                            TrakkerId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.CategoryId, x.TrakkerId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_CategoryTrakkerMap_Category",
                                column: x => x.CategoryId,
                                principalTable: "Category",
                                principalColumn: "CategoryId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "CategoryVehicleMap",
                        columns: table => new
                        {
                            CategoryId = table.Column<int>(type: "int", nullable: false),
                            VehicleId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.CategoryId, x.VehicleId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_CategoryVehicleMap_Category",
                                column: x => x.CategoryId,
                                principalTable: "Category",
                                principalColumn: "CategoryId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "EventPositions",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            PositionId = table.Column<int>(type: "int", nullable: false),
                            TimeStamp = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            VehicleEventId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.Id);
                            table.ForeignKey(
                                name: "FK_EventPositions_Position_PositionId",
                                column: x => x.PositionId,
                                principalTable: "Position",
                                principalColumn: "PositionId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "RouteSections",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            RouteId = table.Column<int>(type: "int", nullable: false),
                            Duration = table.Column<double>(type: "double", nullable: false),
                            Length = table.Column<double>(type: "double", nullable: false),
                            From = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            To = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            StartReferencePositionId = table.Column<int>(type: "int", nullable: true),
                            StopReferencePositionId = table.Column<int>(type: "int", nullable: true),
                            Path = table.Column<Geometry>(type: "geometry", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.Id);
                            table.ForeignKey(
                                name: "FK_RouteSections_EventPositions_StartReferencePositionId",
                                column: x => x.StartReferencePositionId,
                                principalTable: "EventPositions",
                                principalColumn: "Id");
                            table.ForeignKey(
                                name: "FK_RouteSections_EventPositions_StopReferencePositionId",
                                column: x => x.StopReferencePositionId,
                                principalTable: "EventPositions",
                                principalColumn: "Id");
                            table.ForeignKey(
                                name: "FK_RouteSections_Route_RouteId",
                                column: x => x.RouteId,
                                principalTable: "Route",
                                principalColumn: "RouteId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeofenceEvent",
                        columns: table => new
                        {
                            GeofenceEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            GeofenceId = table.Column<int>(type: "int", nullable: false),
                            GeofenceName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            EnteredOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            LeftOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.GeofenceEventId);
                            table.ForeignKey(
                                name: "FK_TriggeredGeofenceTrakkerMap_Geofence",
                                column: x => x.GeofenceId,
                                principalTable: "Geofence",
                                principalColumn: "GeofenceId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "GeofenceTrakkerMap",
                        columns: table => new
                        {
                            GeofenceId = table.Column<int>(type: "int", nullable: false),
                            TrakkerId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.GeofenceId, x.TrakkerId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_GeofenceTrakkerMap_Geofence",
                                column: x => x.GeofenceId,
                                principalTable: "Geofence",
                                principalColumn: "GeofenceId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "JobTrakkerMap",
                        columns: table => new
                        {
                            JobId = table.Column<int>(type: "int", nullable: false),
                            TrakkerId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.JobId, x.TrakkerId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_JobTrakkerMap_Task",
                                column: x => x.JobId,
                                principalTable: "Job",
                                principalColumn: "JobId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Trakker",
                        columns: table => new
                        {
                            TrakkerId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            ScheduleId = table.Column<int>(type: "int", nullable: true),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IconId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'42'"),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            HardwareId = table.Column<int>(type: "int", nullable: true),
                            LatestEventId = table.Column<int>(type: "int", nullable: true),
                            LatestPositionEventId = table.Column<int>(type: "int", nullable: true),
                            EquipmentNumber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            BatteryStatus = table.Column<byte>(type: "tinyint(3) unsigned", nullable: true),
                            LastContact = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            Comment = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.TrakkerId);
                            table.ForeignKey(
                                name: "FK_Trakker_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_Trakker_Hardware",
                                column: x => x.HardwareId,
                                principalTable: "Hardware",
                                principalColumn: "HardwareId");
                            table.ForeignKey(
                                name: "FK_Trakker_Icon",
                                column: x => x.IconId,
                                principalTable: "Icon",
                                principalColumn: "IconId");
                            table.ForeignKey(
                                name: "FK_Trakker_Schedules_ScheduleId",
                                column: x => x.ScheduleId,
                                principalTable: "Schedules",
                                principalColumn: "Id");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "TrakkerContactMap",
                        columns: table => new
                        {
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            ContactId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.TrakkerId, x.ContactId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_TrakkerContactMap_Contact",
                                column: x => x.ContactId,
                                principalTable: "Contact",
                                principalColumn: "ContactId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_TrakkerContactMap_Trakker",
                                column: x => x.TrakkerId,
                                principalTable: "Trakker",
                                principalColumn: "TrakkerId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "TrakkerEvent",
                        columns: table => new
                        {
                            TrakkerEventId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            OccuredOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            TrakkerEventTypeId = table.Column<int>(type: "int", nullable: false),
                            AlertTypeId = table.Column<int>(type: "int", nullable: true),
                            IsAGPS = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            PositionId = table.Column<int>(type: "int", nullable: true),
                            Altitude = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1,
                                nullable: true),
                            Speed = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: true),
                            Heading = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1,
                                nullable: true),
                            Accuracy = table.Column<byte>(type: "tinyint(3) unsigned", nullable: true),
                            BatteryLevel = table.Column<byte>(type: "tinyint(3) unsigned", nullable: true),
                            Temperature = table.Column<int>(type: "int", nullable: true),
                            Comment = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4")
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.TrakkerEventId);
                            table.ForeignKey(
                                name: "FK_TrakkerEvent_Position",
                                column: x => x.PositionId,
                                principalTable: "Position",
                                principalColumn: "PositionId");
                            table.ForeignKey(
                                name: "FK_TrakkerEvent_Trakker",
                                column: x => x.TrakkerId,
                                principalTable: "Trakker",
                                principalColumn: "TrakkerId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "TrakkerGroupMap",
                        columns: table => new
                        {
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            GroupId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.TrakkerId, x.GroupId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_TrakkerGroupMap_Group",
                                column: x => x.GroupId,
                                principalTable: "Group",
                                principalColumn: "GroupId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_TrakkerGroupMap_Trakker",
                                column: x => x.TrakkerId,
                                principalTable: "Trakker",
                                principalColumn: "TrakkerId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "TrakkerVehicleMap",
                        columns: table => new
                        {
                            TrakkerId = table.Column<int>(type: "int", nullable: false),
                            VehicleId = table.Column<int>(type: "int", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => new { x.TrakkerId, x.VehicleId })
                                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            table.ForeignKey(
                                name: "FK_TrakkerVehicleMap_Trakker",
                                column: x => x.TrakkerId,
                                principalTable: "Trakker",
                                principalColumn: "TrakkerId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "Vehicle",
                        columns: table => new
                        {
                            VehicleId = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            CustomerId = table.Column<int>(type: "int", nullable: false),
                            CreatedOn = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false,
                                defaultValueSql: "current_timestamp(6)"),
                            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                            IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            HasCongestionTax = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            HasExternalRouteSource = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            HasVehicleEventProcessor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            VehicleRegistrationNumber = table.Column<string>(type: "varchar(50)", maxLength: 50,
                                    nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            VIN = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Driver = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true,
                                    defaultValueSql: "''", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            AccountId = table.Column<int>(type: "int", nullable: true),
                            DriverAssignment = table.Column<int>(type: "int", nullable: false),
                            DriverAssignmentValidUntil =
                                table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                            LatestTrakkerEventId = table.Column<int>(type: "int", nullable: true),
                            OdometerMeter = table.Column<int>(type: "int", nullable: true),
                            CO2 = table.Column<int>(type: "int", nullable: true),
                            TimeZoneId = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true,
                                    defaultValueSql: "'UTC'", collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            LatestStopEventId = table.Column<int>(type: "int", nullable: true),
                            FuelType = table.Column<int>(type: "int", nullable: false),
                            FuelConsumption = table.Column<double>(type: "double", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.VehicleId);
                            table.ForeignKey(
                                name: "FK_Vehicle_Account_AccountId",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.SetNull);
                            table.ForeignKey(
                                name: "FK_Vehicle_Customer",
                                column: x => x.CustomerId,
                                principalTable: "Customer",
                                principalColumn: "CustomerId");
                            table.ForeignKey(
                                name: "FK_Vehicle_TrakkerEvent",
                                column: x => x.LatestTrakkerEventId,
                                principalTable: "TrakkerEvent",
                                principalColumn: "TrakkerEventId");
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateTable(
                        name: "VehicleEvents",
                        columns: table => new
                        {
                            Id = table.Column<int>(type: "int", nullable: false)
                                .Annotation("MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn),
                            Type = table.Column<int>(type: "int", nullable: false),
                            HardwareType = table.Column<int>(type: "int", nullable: false),
                            Valid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            Private = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            VehicleId = table.Column<int>(type: "int", nullable: false),
                            StartTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                            PositionCount = table.Column<int>(type: "int", nullable: false),
                            PreviousId = table.Column<int>(type: "int", nullable: true),
                            Comment = table.Column<string>(type: "text", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Driver = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            AccountId = table.Column<int>(type: "int", nullable: true),
                            DriverLocked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            Distance = table.Column<double>(type: "double", nullable: false, defaultValue: 0.0),
                            CongestionTaxDataId = table.Column<int>(type: "int", nullable: true),
                            UserDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                            OdometerMeter = table.Column<int>(type: "int", nullable: true),
                            RouteId = table.Column<int>(type: "int", nullable: true),
                            StopPositionId = table.Column<int>(type: "int", nullable: true),
                            FromAddress = table.Column<string>(type: "longtext", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ToAddress = table.Column<string>(type: "longtext", nullable: true,
                                    collation: "utf8mb4_general_ci")
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            ToDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PRIMARY", x => x.Id);
                            table.ForeignKey(
                                name: "FK_VehicleEvents_Account_AccountId",
                                column: x => x.AccountId,
                                principalTable: "Account",
                                principalColumn: "AccountId",
                                onDelete: ReferentialAction.SetNull);
                            table.ForeignKey(
                                name: "FK_VehicleEvents_CongestionTaxDatas_CongestionTaxDataId",
                                column: x => x.CongestionTaxDataId,
                                principalTable: "CongestionTaxDatas",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.SetNull);
                            table.ForeignKey(
                                name: "FK_VehicleEvents_Position_StopPositionId",
                                column: x => x.StopPositionId,
                                principalTable: "Position",
                                principalColumn: "PositionId",
                                onDelete: ReferentialAction.SetNull);
                            table.ForeignKey(
                                name: "FK_VehicleEvents_Route_RouteId",
                                column: x => x.RouteId,
                                principalTable: "Route",
                                principalColumn: "RouteId",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_VehicleEvents_VehicleEvents_PreviousId",
                                column: x => x.PreviousId,
                                principalTable: "VehicleEvents",
                                principalColumn: "Id");
                            table.ForeignKey(
                                name: "FK_VehicleEvents_Vehicle_VehicleId",
                                column: x => x.VehicleId,
                                principalTable: "Vehicle",
                                principalColumn: "VehicleId",
                                onDelete: ReferentialAction.Cascade);
                        })
                    .Annotation("MySql:CharSet", "utf8mb4")
                    .Annotation("Relational:Collation", "utf8mb4_general_ci");

                migrationBuilder.CreateIndex(
                    name: "FK_Account_Contact",
                    table: "Account",
                    column: "ContactId");

                migrationBuilder.CreateIndex(
                    name: "FK_Account_Customer",
                    table: "Account",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Account_Language",
                    table: "Account",
                    column: "LanguageId");

                migrationBuilder.CreateIndex(
                    name: "FK_Account_UserRole",
                    table: "Account",
                    column: "AccountRoleId");

                migrationBuilder.CreateIndex(
                        name: "IX_Account_Email_NullableUnique",
                        table: "Account",
                        column: "Email",
                        unique: true)
                    .Annotation("MySql:IndexPrefixLength", new[] { 255 });

                migrationBuilder.CreateIndex(
                        name: "UQ_Account_LoginName",
                        table: "Account",
                        column: "LoginName",
                        unique: true)
                    .Annotation("MySql:IndexPrefixLength", new[] { 255 });

                migrationBuilder.CreateIndex(
                    name: "FK_AccountConfirmation_Account",
                    table: "AccountConfirmation",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_AccountEvent_Account",
                    table: "AccountEvent",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_AccountEvent_EventType",
                    table: "AccountEvent",
                    column: "AccountEventTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_AccountGroupMap_Group",
                    table: "AccountGroupMap",
                    column: "GroupId");

                migrationBuilder.CreateIndex(
                    name: "FK_AccountRightTypeMap_RightType",
                    table: "AccountRightMap",
                    column: "RightTypeId");

                migrationBuilder.CreateIndex(
                    name: "UQ_AccountToken_TokenGuid",
                    table: "AccountToken",
                    column: "TokenGuid",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "FK_AccountTrakkerMap_Trakker",
                    table: "AccountTrakkerMap",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_ActiveAlert_GeofenceEvent",
                    table: "ActiveAlert",
                    column: "GeofenceEventId");

                migrationBuilder.CreateIndex(
                    name: "UK_ActiveAlert_TrakkerEventId",
                    table: "ActiveAlert",
                    column: "TrakkerEventId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "FK_ArchivedUnitsCustomer_Customer",
                    table: "ArchivedUnitsCustomer",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "IX_ArchivedUnitsCustomer_CustomerAdminId_NullableUnique",
                    table: "ArchivedUnitsCustomer",
                    column: "CustomerAdminId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "FK_Asset_LatestAssetEvent",
                    table: "Asset",
                    column: "LatestAssetEventId");

                migrationBuilder.CreateIndex(
                    name: "FK_Asset_Trakker",
                    table: "Asset",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_AssetEvent_Position",
                    table: "AssetEvent",
                    column: "PositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_AssetEvent_AssetId_AssetTypeId_Start_Stop",
                    table: "AssetEvent",
                    columns: new[]
                    {
                        "AssetId", "AssetEventTypeId", "StartDateTime", "StopDateTime", "AssetEventId", "PositionId",
                        "GeofenceName", "Comment"
                    });

                migrationBuilder.CreateIndex(
                    name: "FK_BaseStation_Position",
                    table: "BaseStation",
                    column: "PositionId");

                migrationBuilder.CreateIndex(
                    name: "FK_CategoryType",
                    table: "Category",
                    column: "CategoryTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_CategoryAssetMap_Asset",
                    table: "CategoryAssetMap",
                    column: "AssetId");

                migrationBuilder.CreateIndex(
                    name: "FK_CategoryTrakkerMap_Trakker",
                    table: "CategoryTrakkerMap",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_CategoryVehicleMap_Vehicle",
                    table: "CategoryVehicleMap",
                    column: "VehicleId");

                migrationBuilder.CreateIndex(
                    name: "FK_ChangeEmailTicket_Account",
                    table: "ChangeEmailTicket",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "IX_ChangeEmailTicket_Verification",
                    table: "ChangeEmailTicket",
                    column: "Verification");

                migrationBuilder.CreateIndex(
                    name: "FK_CommunicationEvent_Account",
                    table: "CommunicationEvent",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_CommunicationEvent_CommunicationEventType",
                    table: "CommunicationEvent",
                    column: "CommunicationEventTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_Contact_Customer",
                    table: "Contact",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_ContactGroupMap_Group",
                    table: "ContactGroupMap",
                    column: "GroupId");

                migrationBuilder.CreateIndex(
                    name: "FK_Customer_CustomerAdminId",
                    table: "Customer",
                    column: "CustomerAdminId");

                migrationBuilder.CreateIndex(
                    name: "IX_Customer_SalesPersonId",
                    table: "Customer",
                    column: "SalesPersonId");

                migrationBuilder.CreateIndex(
                    name: "UK_Customer_Name",
                    table: "Customer",
                    column: "Name",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_CustomerFuelPrices_CustomerId",
                    table: "CustomerFuelPrices",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "IX_CustomerServiceMap_ServiceId",
                    table: "CustomerServiceMap",
                    column: "ServiceId");

                migrationBuilder.CreateIndex(
                    name: "FK_Driver_AccountId",
                    table: "Driver",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_Driver_Customer",
                    table: "Driver",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_DriverEvent_Driver",
                    table: "DriverEvent",
                    column: "DriverId");

                migrationBuilder.CreateIndex(
                    name: "FK_DriverEvent_DriverEventType",
                    table: "DriverEvent",
                    column: "DriverEventTypeId");

                migrationBuilder.CreateIndex(
                    name: "IX_EmailAddresses_JobId",
                    table: "EmailAddresses",
                    column: "JobId");

                migrationBuilder.CreateIndex(
                    name: "IX_EventPositions_PositionId",
                    table: "EventPositions",
                    column: "PositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_EventPositions_VehicleEventId",
                    table: "EventPositions",
                    column: "VehicleEventId");

                migrationBuilder.CreateIndex(
                    name: "IX_GeocodedPosition_Latitude_Longitude",
                    table: "GeocodedPosition",
                    columns: new[] { "Latitude", "Longitude" });

                migrationBuilder.CreateIndex(
                    name: "FK_Geofence_Customer",
                    table: "Geofence",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Geofence_GeofenceType",
                    table: "Geofence",
                    column: "GeofenceTypeId");

                migrationBuilder.CreateIndex(
                    name: "IX_Geofence_ScheduleId",
                    table: "Geofence",
                    column: "ScheduleId");

                migrationBuilder.CreateIndex(
                    name: "FK_GeofenceContactMap_Contact",
                    table: "GeofenceContactMap",
                    column: "ContactId");

                migrationBuilder.CreateIndex(
                    name: "FK_TriggeredGeofenceTrakkerMap_Geofence",
                    table: "GeofenceEvent",
                    column: "GeofenceId");

                migrationBuilder.CreateIndex(
                    name: "FK_TriggeredGeofenceTrakkerMap_Trakker",
                    table: "GeofenceEvent",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_GeofenceGroupMap_Group",
                    table: "GeofenceGroupMap",
                    column: "GroupId");

                migrationBuilder.CreateIndex(
                    name: "FK_GeofenceTrakkerMap_Trakker",
                    table: "GeofenceTrakkerMap",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Group_Customer",
                    table: "Group",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Hardware_CustomerAdmin",
                    table: "Hardware",
                    column: "CustomerAdminId");

                migrationBuilder.CreateIndex(
                    name: "FK_Hardware_HardwareConfig",
                    table: "Hardware",
                    column: "HardwareConfigId");

                migrationBuilder.CreateIndex(
                    name: "FK_Hardware_HardwareStatus",
                    table: "Hardware",
                    column: "HardwareStatusId");

                migrationBuilder.CreateIndex(
                    name: "FK_Hardware_HardwareType",
                    table: "Hardware",
                    column: "HardwareTypeId");

                migrationBuilder.CreateIndex(
                    name: "IX_Hardware_CustomerId",
                    table: "Hardware",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "IX_Hardware_ICC_NullableUnique",
                    table: "Hardware",
                    column: "ICC",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "UK_Hardware_GlobalDeviceId",
                    table: "Hardware",
                    column: "GlobalDeviceId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "FK_HardwareConfig_Icon",
                    table: "HardwareConfig",
                    column: "IconId");

                migrationBuilder.CreateIndex(
                    name: "FK_Job_Customer",
                    table: "Job",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Job_JobIntervalType",
                    table: "Job",
                    column: "JobIntervalTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_Job_JobType",
                    table: "Job",
                    column: "JobTypeId");

                migrationBuilder.CreateIndex(
                    name: "IX_Job_AccountId",
                    table: "Job",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_JobAssetMap_Asset",
                    table: "JobAssetMap",
                    column: "AssetId");

                migrationBuilder.CreateIndex(
                    name: "FK_JobContactMap_Contact",
                    table: "JobContactMap",
                    column: "ContactId");

                migrationBuilder.CreateIndex(
                    name: "FK_JobGroupMap_Group",
                    table: "JobGroupMap",
                    column: "GroupId");

                migrationBuilder.CreateIndex(
                    name: "FK_JobTrakkerMap_Trakker",
                    table: "JobTrakkerMap",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Mapzone_Customer",
                    table: "Mapzone",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "IX_Passage_CongestionTaxDataId",
                    table: "Passage",
                    column: "CongestionTaxDataId");

                migrationBuilder.CreateIndex(
                    name: "FK_PasswordRecovery_AccountId",
                    table: "PasswordRecovery",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "FK_GeocodedPosition",
                    table: "Position",
                    column: "GeocodedPositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_Position_Lat_Lon",
                    table: "Position",
                    columns: new[] { "Latitude", "Longitude", "PositionId", "CreatedOn", "GeocodedPositionId" });

                migrationBuilder.CreateIndex(
                    name: "FK_RootAccount_CustomerAdmin",
                    table: "RootAccount",
                    column: "CustomerAdminId");

                migrationBuilder.CreateIndex(
                    name: "FK_RootAccount_RootAccountType",
                    table: "RootAccount",
                    column: "RootAccountTypeId");

                migrationBuilder.CreateIndex(
                    name: "UQ_RootAccount_UserName",
                    table: "RootAccount",
                    column: "UserName",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_RouteSections_RouteId",
                    table: "RouteSections",
                    column: "RouteId");

                migrationBuilder.CreateIndex(
                    name: "IX_RouteSections_StartReferencePositionId",
                    table: "RouteSections",
                    column: "StartReferencePositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_RouteSections_StopReferencePositionId",
                    table: "RouteSections",
                    column: "StopReferencePositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_SalesPerson_CustomerAdminId",
                    table: "SalesPerson",
                    column: "CustomerAdminId");

                migrationBuilder.CreateIndex(
                        name: "IX_SalesPerson_Name_CustomerAdminId",
                        table: "SalesPerson",
                        columns: new[] { "Name", "CustomerAdminId" },
                        unique: true)
                    .Annotation("MySql:IndexPrefixLength", new[] { 255, 0 });

                migrationBuilder.CreateIndex(
                    name: "IX_ScheduleEntries_ScheduleId",
                    table: "ScheduleEntries",
                    column: "ScheduleId");

                migrationBuilder.CreateIndex(
                    name: "FK_SmsCommand_HardwareType",
                    table: "SmsCommand",
                    column: "HardwareTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_Trakker_Customer",
                    table: "Trakker",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Trakker_Hardware",
                    table: "Trakker",
                    column: "HardwareId");

                migrationBuilder.CreateIndex(
                    name: "FK_Trakker_Icon",
                    table: "Trakker",
                    column: "IconId");

                migrationBuilder.CreateIndex(
                    name: "FK_Trakker_LatestEventId",
                    table: "Trakker",
                    column: "LatestEventId");

                migrationBuilder.CreateIndex(
                    name: "FK_Trakker_LatestPositionEventId",
                    table: "Trakker",
                    column: "LatestPositionEventId");

                migrationBuilder.CreateIndex(
                    name: "IX_Trakker_ScheduleId",
                    table: "Trakker",
                    column: "ScheduleId");

                migrationBuilder.CreateIndex(
                    name: "FK_TrakkerContactMap_Contact",
                    table: "TrakkerContactMap",
                    column: "ContactId");

                migrationBuilder.CreateIndex(
                    name: "FK_TrakkerEvent_Position",
                    table: "TrakkerEvent",
                    column: "PositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_TrakkerEvent_TrakkerId",
                    table: "TrakkerEvent",
                    column: "TrakkerId");

                migrationBuilder.CreateIndex(
                    name: "FK_TrakkerGroupMap_Group",
                    table: "TrakkerGroupMap",
                    column: "GroupId");

                migrationBuilder.CreateIndex(
                    name: "FK_TrakkerVehicleMap_Vehicle",
                    table: "TrakkerVehicleMap",
                    column: "VehicleId");

                migrationBuilder.CreateIndex(
                    name: "FK_Vehicle_Customer",
                    table: "Vehicle",
                    column: "CustomerId");

                migrationBuilder.CreateIndex(
                    name: "FK_Vehicle_TrakkerEvent",
                    table: "Vehicle",
                    column: "LatestTrakkerEventId");

                migrationBuilder.CreateIndex(
                    name: "IX_Vehicle_AccountId",
                    table: "Vehicle",
                    column: "AccountId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_Vehicle_LatestStopEventId",
                    table: "Vehicle",
                    column: "LatestStopEventId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_AccountId",
                    table: "VehicleEvents",
                    column: "AccountId");

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_CongestionTaxDataId",
                    table: "VehicleEvents",
                    column: "CongestionTaxDataId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_PreviousId",
                    table: "VehicleEvents",
                    column: "PreviousId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_RouteId",
                    table: "VehicleEvents",
                    column: "RouteId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_StopPositionId",
                    table: "VehicleEvents",
                    column: "StopPositionId");

                migrationBuilder.CreateIndex(
                    name: "IX_VehicleEvents_VehicleId",
                    table: "VehicleEvents",
                    column: "VehicleId");

                migrationBuilder.CreateIndex(
                    name: "FK_VehicleReminder_Vehicle",
                    table: "VehicleReminder",
                    column: "VehicleReminderTypeId");

                migrationBuilder.CreateIndex(
                    name: "FK_VehicleReminderContactMap_Contact",
                    table: "VehicleReminderContactMap",
                    column: "ContactId");

                migrationBuilder.AddForeignKey(
                    name: "FK_AccountTrakkerMap_Trakker",
                    table: "AccountTrakkerMap",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_ActiveAlert_GeofenceEvent",
                    table: "ActiveAlert",
                    column: "GeofenceEventId",
                    principalTable: "GeofenceEvent",
                    principalColumn: "GeofenceEventId");

                migrationBuilder.AddForeignKey(
                    name: "FK_ActiveAlert_TrakkerEvent",
                    table: "ActiveAlert",
                    column: "TrakkerEventId",
                    principalTable: "TrakkerEvent",
                    principalColumn: "TrakkerEventId");

                migrationBuilder.AddForeignKey(
                    name: "FK_Asset_LatestAssetEvent",
                    table: "Asset",
                    column: "LatestAssetEventId",
                    principalTable: "AssetEvent",
                    principalColumn: "AssetEventId");

                migrationBuilder.AddForeignKey(
                    name: "FK_Asset_Trakker",
                    table: "Asset",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId");

                migrationBuilder.AddForeignKey(
                    name: "FK_CategoryTrakkerMap_Trakker",
                    table: "CategoryTrakkerMap",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_CategoryVehicleMap_Vehicle",
                    table: "CategoryVehicleMap",
                    column: "VehicleId",
                    principalTable: "Vehicle",
                    principalColumn: "VehicleId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_EventPositions_VehicleEvents_VehicleEventId",
                    table: "EventPositions",
                    column: "VehicleEventId",
                    principalTable: "VehicleEvents",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_TriggeredGeofenceTrakkerMap_Trakker",
                    table: "GeofenceEvent",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId");

                migrationBuilder.AddForeignKey(
                    name: "FK_GeofenceTrakkerMap_Trakker",
                    table: "GeofenceTrakkerMap",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_JobTrakkerMap_Trakker",
                    table: "JobTrakkerMap",
                    column: "TrakkerId",
                    principalTable: "Trakker",
                    principalColumn: "TrakkerId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_Trakker_LatestEventId",
                    table: "Trakker",
                    column: "LatestEventId",
                    principalTable: "TrakkerEvent",
                    principalColumn: "TrakkerEventId");

                migrationBuilder.AddForeignKey(
                    name: "FK_Trakker_LatestPositionEventId",
                    table: "Trakker",
                    column: "LatestPositionEventId",
                    principalTable: "TrakkerEvent",
                    principalColumn: "TrakkerEventId");

                migrationBuilder.AddForeignKey(
                    name: "FK_TrakkerVehicleMap_Vehicle",
                    table: "TrakkerVehicleMap",
                    column: "VehicleId",
                    principalTable: "Vehicle",
                    principalColumn: "VehicleId",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.AddForeignKey(
                    name: "FK_Vehicle_VehicleEvents_LatestStopEventId",
                    table: "Vehicle",
                    column: "LatestStopEventId",
                    principalTable: "VehicleEvents",
                    principalColumn: "Id");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (Apply)
            {


                migrationBuilder.DropForeignKey(
                    name: "FK_Account_Contact",
                    table: "Account");

                migrationBuilder.DropForeignKey(
                    name: "FK_Account_Customer",
                    table: "Account");

                migrationBuilder.DropForeignKey(
                    name: "FK_Hardware_Customer_CustomerId",
                    table: "Hardware");

                migrationBuilder.DropForeignKey(
                    name: "FK_Trakker_Customer",
                    table: "Trakker");

                migrationBuilder.DropForeignKey(
                    name: "FK_Vehicle_Customer",
                    table: "Vehicle");

                migrationBuilder.DropForeignKey(
                    name: "FK_Account_Language",
                    table: "Account");

                migrationBuilder.DropForeignKey(
                    name: "FK_Account_UserRole",
                    table: "Account");

                migrationBuilder.DropForeignKey(
                    name: "FK_Vehicle_Account_AccountId",
                    table: "Vehicle");

                migrationBuilder.DropForeignKey(
                    name: "FK_VehicleEvents_Account_AccountId",
                    table: "VehicleEvents");

                migrationBuilder.DropForeignKey(
                    name: "FK_Asset_Trakker",
                    table: "Asset");

                migrationBuilder.DropForeignKey(
                    name: "FK_TrakkerEvent_Trakker",
                    table: "TrakkerEvent");

                migrationBuilder.DropForeignKey(
                    name: "FK_Vehicle_TrakkerEvent",
                    table: "Vehicle");

                migrationBuilder.DropForeignKey(
                    name: "FK_Asset_LatestAssetEvent",
                    table: "Asset");

                migrationBuilder.DropForeignKey(
                    name: "FK_VehicleEvents_Position_StopPositionId",
                    table: "VehicleEvents");

                migrationBuilder.DropForeignKey(
                    name: "FK_VehicleEvents_Vehicle_VehicleId",
                    table: "VehicleEvents");

                migrationBuilder.DropTable(
                    name: "AccountConfirmation");

                migrationBuilder.DropTable(
                    name: "AccountEvent");

                migrationBuilder.DropTable(
                    name: "AccountGroupMap");

                migrationBuilder.DropTable(
                    name: "AccountRightMap");

                migrationBuilder.DropTable(
                    name: "AccountToken");

                migrationBuilder.DropTable(
                    name: "AccountTrakkerMap");

                migrationBuilder.DropTable(
                    name: "ActiveAlert");

                migrationBuilder.DropTable(
                    name: "Agreement");

                migrationBuilder.DropTable(
                    name: "ArchivedUnitsCustomer");

                migrationBuilder.DropTable(
                    name: "BaseStation");

                migrationBuilder.DropTable(
                    name: "CategoryAssetMap");

                migrationBuilder.DropTable(
                    name: "CategoryTrakkerMap");

                migrationBuilder.DropTable(
                    name: "CategoryVehicleMap");

                migrationBuilder.DropTable(
                    name: "ChangeEmailTicket");

                migrationBuilder.DropTable(
                    name: "CommunicationEvent");

                migrationBuilder.DropTable(
                    name: "ContactGroupMap");

                migrationBuilder.DropTable(
                    name: "CustomerFuelPrices");

                migrationBuilder.DropTable(
                    name: "CustomerServiceMap");

                migrationBuilder.DropTable(
                    name: "DBSettings");

                migrationBuilder.DropTable(
                    name: "DriverEvent");

                migrationBuilder.DropTable(
                    name: "DriverSettings");

                migrationBuilder.DropTable(
                    name: "EmailAddresses");

                migrationBuilder.DropTable(
                    name: "ErrorLog");

                migrationBuilder.DropTable(
                    name: "GeofenceContactMap");

                migrationBuilder.DropTable(
                    name: "GeofenceGroupMap");

                migrationBuilder.DropTable(
                    name: "GeofenceTrakkerMap");

                migrationBuilder.DropTable(
                    name: "JobAssetMap");

                migrationBuilder.DropTable(
                    name: "JobContactMap");

                migrationBuilder.DropTable(
                    name: "JobGroupMap");

                migrationBuilder.DropTable(
                    name: "JobTrakkerMap");

                migrationBuilder.DropTable(
                    name: "Mapzone");

                migrationBuilder.DropTable(
                    name: "Passage");

                migrationBuilder.DropTable(
                    name: "PasswordRecovery");

                migrationBuilder.DropTable(
                    name: "RootAccount");

                migrationBuilder.DropTable(
                    name: "RouteSections");

                migrationBuilder.DropTable(
                    name: "ScheduleEntries");

                migrationBuilder.DropTable(
                    name: "SmsCommand");

                migrationBuilder.DropTable(
                    name: "SmsOperator");

                migrationBuilder.DropTable(
                    name: "TrakkerContactMap");

                migrationBuilder.DropTable(
                    name: "TrakkerGroupMap");

                migrationBuilder.DropTable(
                    name: "TrakkerVehicleMap");

                migrationBuilder.DropTable(
                    name: "UserEvents");

                migrationBuilder.DropTable(
                    name: "VehicleReminderContactMap");

                migrationBuilder.DropTable(
                    name: "AccountEventType");

                migrationBuilder.DropTable(
                    name: "RightType");

                migrationBuilder.DropTable(
                    name: "GeofenceEvent");

                migrationBuilder.DropTable(
                    name: "Category");

                migrationBuilder.DropTable(
                    name: "CommunicationEventType");

                migrationBuilder.DropTable(
                    name: "Service");

                migrationBuilder.DropTable(
                    name: "Driver");

                migrationBuilder.DropTable(
                    name: "DriverEventType");

                migrationBuilder.DropTable(
                    name: "Job");

                migrationBuilder.DropTable(
                    name: "RootAccountType");

                migrationBuilder.DropTable(
                    name: "EventPositions");

                migrationBuilder.DropTable(
                    name: "Group");

                migrationBuilder.DropTable(
                    name: "VehicleReminder");

                migrationBuilder.DropTable(
                    name: "Geofence");

                migrationBuilder.DropTable(
                    name: "CategoryType");

                migrationBuilder.DropTable(
                    name: "JobIntervalType");

                migrationBuilder.DropTable(
                    name: "JobType");

                migrationBuilder.DropTable(
                    name: "VehicleReminderType");

                migrationBuilder.DropTable(
                    name: "GeofenceType");

                migrationBuilder.DropTable(
                    name: "Contact");

                migrationBuilder.DropTable(
                    name: "Customer");

                migrationBuilder.DropTable(
                    name: "SalesPerson");

                migrationBuilder.DropTable(
                    name: "Language");

                migrationBuilder.DropTable(
                    name: "AccountRole");

                migrationBuilder.DropTable(
                    name: "Account");

                migrationBuilder.DropTable(
                    name: "Trakker");

                migrationBuilder.DropTable(
                    name: "Hardware");

                migrationBuilder.DropTable(
                    name: "Schedules");

                migrationBuilder.DropTable(
                    name: "CustomerAdmin");

                migrationBuilder.DropTable(
                    name: "HardwareConfig");

                migrationBuilder.DropTable(
                    name: "HardwareStatus");

                migrationBuilder.DropTable(
                    name: "HardwareType");

                migrationBuilder.DropTable(
                    name: "Icon");

                migrationBuilder.DropTable(
                    name: "TrakkerEvent");

                migrationBuilder.DropTable(
                    name: "AssetEvent");

                migrationBuilder.DropTable(
                    name: "Asset");

                migrationBuilder.DropTable(
                    name: "Position");

                migrationBuilder.DropTable(
                    name: "GeocodedPosition");

                migrationBuilder.DropTable(
                    name: "Vehicle");

                migrationBuilder.DropTable(
                    name: "VehicleEvents");

                migrationBuilder.DropTable(
                    name: "CongestionTaxDatas");

                migrationBuilder.DropTable(
                    name: "Route");

                // migrationBuilder.DropSequence(
                //     name: "UnitId_Counter");
            }
        }
    }
}
