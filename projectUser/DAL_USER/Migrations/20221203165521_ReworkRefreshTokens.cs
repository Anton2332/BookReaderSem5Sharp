using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALUSER.Migrations
{
    /// <inheritdoc />
    public partial class ReworkRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21362b65-8534-46fb-bed2-ef9d66b5abd1");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "111c9cff-606e-483f-bc3e-e8bc42223c8f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4bb1f308-46d9-4504-9c8d-34246e5023a9");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "9e75a981-cd35-4963-b793-87381c3f0708");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "a9ada4f2-dcae-4adf-9c9f-a819e145489d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "e99f9a38-f79a-4589-be32-19cc2b3c7a42");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "RevokedByIp",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "RevokedOn",
                table: "RefreshToken",
                newName: "Expires");

            migrationBuilder.RenameColumn(
                name: "ExpiryOn",
                table: "RefreshToken",
                newName: "Created");

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "RefreshToken",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e8a6f09-59d7-4a04-91b1-12d439137cae", 0, "e6a18cf1-5499-4a02-8ca0-5e36034fe03c", "superadmin@gmail.com", true, "super", "admin", false, null, null, null, null, null, true, "c748a7cd-2fff-4f77-ba2d-15974181d80f", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39c1fb1b-4ed3-4bb5-b372-a31150b4463b", "df2a193a-6685-4a45-84e5-a1de335bc4b4", "Moderator", null },
                    { "698a9288-d10e-4bb0-bfa6-9ca4045a1d65", "0d3da137-3fba-4678-a652-ffbf686257c0", "Admin", null },
                    { "dd85c1b6-d161-4db1-9918-d7ff2b82a138", "86cb6e0a-7535-4a19-b3ef-49152589c520", "Redactor", null },
                    { "f1c88e46-ce60-48b0-a6f9-5d10162cdaad", "dd02ce71-47e7-4946-bb05-bbfa74152740", "Basic", null },
                    { "f9113d72-a5ba-4461-b6a2-fd5a6827e32d", "023d6eb6-c58e-42ac-b2fc-12c17d9ec997", "SuperAdmin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e8a6f09-59d7-4a04-91b1-12d439137cae");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "39c1fb1b-4ed3-4bb5-b372-a31150b4463b");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "698a9288-d10e-4bb0-bfa6-9ca4045a1d65");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "dd85c1b6-d161-4db1-9918-d7ff2b82a138");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f1c88e46-ce60-48b0-a6f9-5d10162cdaad");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f9113d72-a5ba-4461-b6a2-fd5a6827e32d");

            migrationBuilder.DropColumn(
                name: "Revoked",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "Expires",
                table: "RefreshToken",
                newName: "RevokedOn");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "RefreshToken",
                newName: "ExpiryOn");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "RefreshToken",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RefreshToken",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RevokedByIp",
                table: "RefreshToken",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RefreshToken",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21362b65-8534-46fb-bed2-ef9d66b5abd1", 0, "542685ab-62d6-4210-9df4-52d009c42f56", "superadmin@gmail.com", true, "super", "admin", false, null, null, null, null, null, true, "bd440db9-3f1e-4b51-9ae5-2fe589d1d90c", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "111c9cff-606e-483f-bc3e-e8bc42223c8f", "7467d3f3-e03e-476b-8d07-4929fabeb34c", "Moderator", null },
                    { "4bb1f308-46d9-4504-9c8d-34246e5023a9", "8bba7469-d1bf-4fec-b7f8-d988a6e41c5b", "Redactor", null },
                    { "9e75a981-cd35-4963-b793-87381c3f0708", "3f6ae17a-f267-4c08-bfba-85811c982c87", "Basic", null },
                    { "a9ada4f2-dcae-4adf-9c9f-a819e145489d", "d8d05ee0-c0bd-4956-87d7-872c80372da0", "SuperAdmin", null },
                    { "e99f9a38-f79a-4589-be32-19cc2b3c7a42", "dcb9f837-29df-4baa-a2ec-dfc227f1abb1", "Admin", null }
                });
        }
    }
}
