using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlertDefinitions.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_LogLevel_LoglevelExpressionLogLevelId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_ExceptionTypeRegexRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_MessageRegexRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_SourceRegexRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_UrlRegexRegexId",
                table: "AlertDefinition");

            migrationBuilder.RenameColumn(
                name: "UrlRegexRegexId",
                table: "AlertDefinition",
                newName: "UrlRegexId");

            migrationBuilder.RenameColumn(
                name: "SourceRegexRegexId",
                table: "AlertDefinition",
                newName: "SourceRegexId");

            migrationBuilder.RenameColumn(
                name: "MessageRegexRegexId",
                table: "AlertDefinition",
                newName: "MessageRegexId");

            migrationBuilder.RenameColumn(
                name: "LoglevelExpressionLogLevelId",
                table: "AlertDefinition",
                newName: "LogLevelExpressionId");

            migrationBuilder.RenameColumn(
                name: "ExceptionTypeRegexRegexId",
                table: "AlertDefinition",
                newName: "ExceptionTypeRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_UrlRegexRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_UrlRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_SourceRegexRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_SourceRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_MessageRegexRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_MessageRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_LoglevelExpressionLogLevelId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_LogLevelExpressionId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_ExceptionTypeRegexRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_ExceptionTypeRegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_LogLevelExpressions_LogLevelExpressionId",
                table: "AlertDefinition",
                column: "LogLevelExpressionId",
                principalTable: "LogLevelExpressions",
                principalColumn: "LogLevelExpressionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_ExceptionTypeRegexId",
                table: "AlertDefinition",
                column: "ExceptionTypeRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_MessageRegexId",
                table: "AlertDefinition",
                column: "MessageRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_SourceRegexId",
                table: "AlertDefinition",
                column: "SourceRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_UrlRegexId",
                table: "AlertDefinition",
                column: "UrlRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_LogLevelExpressions_LogLevelExpressionId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_ExceptionTypeRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_MessageRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_SourceRegexId",
                table: "AlertDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertDefinition_Regex_UrlRegexId",
                table: "AlertDefinition");

            migrationBuilder.RenameColumn(
                name: "UrlRegexId",
                table: "AlertDefinition",
                newName: "UrlRegexRegexId");

            migrationBuilder.RenameColumn(
                name: "SourceRegexId",
                table: "AlertDefinition",
                newName: "SourceRegexRegexId");

            migrationBuilder.RenameColumn(
                name: "MessageRegexId",
                table: "AlertDefinition",
                newName: "MessageRegexRegexId");

            migrationBuilder.RenameColumn(
                name: "LogLevelExpressionId",
                table: "AlertDefinition",
                newName: "LoglevelExpressionLogLevelId");

            migrationBuilder.RenameColumn(
                name: "ExceptionTypeRegexId",
                table: "AlertDefinition",
                newName: "ExceptionTypeRegexRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_UrlRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_UrlRegexRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_SourceRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_SourceRegexRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_MessageRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_MessageRegexRegexId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_LogLevelExpressionId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_LoglevelExpressionLogLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertDefinition_ExceptionTypeRegexId",
                table: "AlertDefinition",
                newName: "IX_AlertDefinition_ExceptionTypeRegexRegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_LogLevel_LoglevelExpressionLogLevelId",
                table: "AlertDefinition",
                column: "LoglevelExpressionLogLevelId",
                principalTable: "LogLevel",
                principalColumn: "LogLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_ExceptionTypeRegexRegexId",
                table: "AlertDefinition",
                column: "ExceptionTypeRegexRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_MessageRegexRegexId",
                table: "AlertDefinition",
                column: "MessageRegexRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_SourceRegexRegexId",
                table: "AlertDefinition",
                column: "SourceRegexRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertDefinition_Regex_UrlRegexRegexId",
                table: "AlertDefinition",
                column: "UrlRegexRegexId",
                principalTable: "Regex",
                principalColumn: "RegexId");
        }
    }
}
