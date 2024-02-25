using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlertDefinitions.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "LogLevel",
                columns: table => new
                {
                    LogLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevel", x => x.LogLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Regex",
                columns: table => new
                {
                    RegexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regex", x => x.RegexId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Webhooks",
                columns: table => new
                {
                    WebhookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webhooks", x => x.WebhookId);
                });

            migrationBuilder.CreateTable(
                name: "UpdateLog",
                columns: table => new
                {
                    UpdateLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateLog", x => x.UpdateLogId);
                    table.ForeignKey(
                        name: "FK_UpdateLog_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogLevelExpressions",
                columns: table => new
                {
                    LogLevelExpressionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<int>(type: "int", nullable: false),
                    LogLevelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevelExpressions", x => x.LogLevelExpressionId);
                    table.ForeignKey(
                        name: "FK_LogLevelExpressions_LogLevel_LogLevelId",
                        column: x => x.LogLevelId,
                        principalTable: "LogLevel",
                        principalColumn: "LogLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    WebhookId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.RecipientId);
                    table.ForeignKey(
                        name: "FK_Recipient_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipient_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipient_Webhooks_WebhookId",
                        column: x => x.WebhookId,
                        principalTable: "Webhooks",
                        principalColumn: "WebhookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlertDefinition",
                columns: table => new
                {
                    AlertDefinitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageRegexRegexId = table.Column<int>(type: "int", nullable: true),
                    SourceRegexRegexId = table.Column<int>(type: "int", nullable: true),
                    ExceptionTypeRegexRegexId = table.Column<int>(type: "int", nullable: true),
                    UrlRegexRegexId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    LoglevelExpressionLogLevelId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertDefinition", x => x.AlertDefinitionId);
                    table.ForeignKey(
                        name: "FK_AlertDefinition_LogLevel_LoglevelExpressionLogLevelId",
                        column: x => x.LoglevelExpressionLogLevelId,
                        principalTable: "LogLevel",
                        principalColumn: "LogLevelId");
                    table.ForeignKey(
                        name: "FK_AlertDefinition_Recipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipient",
                        principalColumn: "RecipientId");
                    table.ForeignKey(
                        name: "FK_AlertDefinition_Regex_ExceptionTypeRegexRegexId",
                        column: x => x.ExceptionTypeRegexRegexId,
                        principalTable: "Regex",
                        principalColumn: "RegexId");
                    table.ForeignKey(
                        name: "FK_AlertDefinition_Regex_MessageRegexRegexId",
                        column: x => x.MessageRegexRegexId,
                        principalTable: "Regex",
                        principalColumn: "RegexId");
                    table.ForeignKey(
                        name: "FK_AlertDefinition_Regex_SourceRegexRegexId",
                        column: x => x.SourceRegexRegexId,
                        principalTable: "Regex",
                        principalColumn: "RegexId");
                    table.ForeignKey(
                        name: "FK_AlertDefinition_Regex_UrlRegexRegexId",
                        column: x => x.UrlRegexRegexId,
                        principalTable: "Regex",
                        principalColumn: "RegexId");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertDefinitionId = table.Column<int>(type: "int", nullable: false),
                    LogLevelId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_AlertDefinition_AlertDefinitionId",
                        column: x => x.AlertDefinitionId,
                        principalTable: "AlertDefinition",
                        principalColumn: "AlertDefinitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_LogLevel_LogLevelId",
                        column: x => x.LogLevelId,
                        principalTable: "LogLevel",
                        principalColumn: "LogLevelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_ExceptionTypeRegexRegexId",
                table: "AlertDefinition",
                column: "ExceptionTypeRegexRegexId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_LoglevelExpressionLogLevelId",
                table: "AlertDefinition",
                column: "LoglevelExpressionLogLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_MessageRegexRegexId",
                table: "AlertDefinition",
                column: "MessageRegexRegexId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_RecipientId",
                table: "AlertDefinition",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_SourceRegexRegexId",
                table: "AlertDefinition",
                column: "SourceRegexRegexId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertDefinition_UrlRegexRegexId",
                table: "AlertDefinition",
                column: "UrlRegexRegexId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AlertDefinitionId",
                table: "Event",
                column: "AlertDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LogLevelId",
                table: "Event",
                column: "LogLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LogLevelExpressions_LogLevelId",
                table: "LogLevelExpressions",
                column: "LogLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_EmployeeId",
                table: "Recipient",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_TeamId",
                table: "Recipient",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_WebhookId",
                table: "Recipient",
                column: "WebhookId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateLog_EmployeeId",
                table: "UpdateLog",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "LogLevelExpressions");

            migrationBuilder.DropTable(
                name: "UpdateLog");

            migrationBuilder.DropTable(
                name: "AlertDefinition");

            migrationBuilder.DropTable(
                name: "LogLevel");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Regex");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Webhooks");
        }
    }
}
