using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Picture = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BriefIntroduction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAudit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HeadPortrait = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    FreezeTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Signature = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWay = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppealFaileds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cause = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppealStatus = table.Column<int>(type: "int", nullable: false),
                    AllegedlyDecidedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ProcessingTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppealFaileds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppealFaileds_User_AllegedlyDecidedId",
                        column: x => x.AllegedlyDecidedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FreezeDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cause = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThawingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    FormId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FrozenType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreezeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreezeDetail_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWay = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetailedAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Audit = table.Column<int>(type: "int", nullable: false),
                    NotAuditCause = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserFormStatus = table.Column<int>(type: "int", nullable: false),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuditId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FormTypeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OrderEvaluate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SponsorEvaluate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserForms_FormType_FormTypeId",
                        column: x => x.FormTypeId,
                        principalTable: "FormType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserForms_User_OrderId",
                        column: x => x.OrderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashPledge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Usable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreezeMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProperty_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccessNumberForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserFormsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessNumberForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessNumberForm_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessNumberForm_UserForms_UserFormsId",
                        column: x => x.UserFormsId,
                        principalTable: "UserForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Collects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserFormsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collects_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collects_UserForms_UserFormsId",
                        column: x => x.UserFormsId,
                        principalTable: "UserForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AccessNumberForm_Id",
                table: "AccessNumberForm",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccessNumberForm_UserFormsId",
                table: "AccessNumberForm",
                column: "UserFormsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessNumberForm_UserId",
                table: "AccessNumberForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppealFaileds_AllegedlyDecidedId",
                table: "AppealFaileds",
                column: "AllegedlyDecidedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppealFaileds_Id",
                table: "AppealFaileds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Collects_Id",
                table: "Collects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Collects_UserFormsId",
                table: "Collects",
                column: "UserFormsId");

            migrationBuilder.CreateIndex(
                name: "IX_Collects_UserId_UserFormsId",
                table: "Collects",
                columns: new[] { "UserId", "UserFormsId" });

            migrationBuilder.CreateIndex(
                name: "IX_FormType_Id",
                table: "FormType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FreezeDetail_Id",
                table: "FreezeDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FreezeDetail_UserId",
                table: "FreezeDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_FormTypeId",
                table: "UserForms",
                column: "FormTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_Id",
                table: "UserForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_OrderId",
                table: "UserForms",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProperty_Id",
                table: "UserProperty",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProperty_UserId",
                table: "UserProperty",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessNumberForm");

            migrationBuilder.DropTable(
                name: "AppealFaileds");

            migrationBuilder.DropTable(
                name: "Collects");

            migrationBuilder.DropTable(
                name: "FreezeDetail");

            migrationBuilder.DropTable(
                name: "UserProperty");

            migrationBuilder.DropTable(
                name: "UserForms");

            migrationBuilder.DropTable(
                name: "FormType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
