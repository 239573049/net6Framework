using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HeadPortrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: false),
                    FreezeTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactWay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "DeleteBy", "DeletedTime", "Index", "IsDeleted", "ModifiedId", "ModifiedTime", "Name", "Remark" },
                values: new object[] { new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "admin", null, null, 0L, false, null, null, "管理员", "超级牛皮的权限管理员" });

            migrationBuilder.InsertData(
                table: "RoleFunction",
                columns: new[] { "Id", "DeleteBy", "DeletedTime", "Index", "IsDeleted", "ModifiedId", "ModifiedTime", "ParentId", "RoleId", "Route", "Title" },
                values: new object[,]
                {
                    { new Guid("2e3dae23-8e63-4f1c-9b77-b14b0c84b32b"), null, null, 2, false, null, null, new Guid("402ff1a4-7fb8-4597-8013-5b907b3981a9"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Files/DeletesFile", "文件模块" },
                    { new Guid("2e742937-20fd-468a-a68c-591daf19e607"), null, null, 0, false, null, null, null, new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Get", "获取所有接口" },
                    { new Guid("31b6c114-f57c-4e70-b598-c6ec975cf708"), null, null, 1, false, null, null, null, new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Login", "登录模块" },
                    { new Guid("3786f975-5a06-4066-b4c0-2a746ce75194"), null, null, 1, false, null, null, new Guid("950a5bb3-55ee-4770-860c-1e4b34cfcdb3"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/User/GetAllUsers", "用户模块" },
                    { new Guid("402ff1a4-7fb8-4597-8013-5b907b3981a9"), null, null, 3, false, null, null, null, new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Files", "文件模块" },
                    { new Guid("4d146c9a-7c3d-4ce9-909c-520ac1efae68"), null, null, 2, false, null, null, new Guid("31b6c114-f57c-4e70-b598-c6ec975cf708"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Login/Refresh", "登录模块" },
                    { new Guid("50cf6bf9-ef1d-4ad0-b5c0-6215c58df9ed"), null, null, 0, false, null, null, new Guid("2e742937-20fd-468a-a68c-591daf19e607"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Get/GetPathAll", "获取所有接口" },
                    { new Guid("52587097-fec2-435e-88bd-c8c090f70c41"), null, null, 0, false, null, null, new Guid("950a5bb3-55ee-4770-860c-1e4b34cfcdb3"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/User/CreateUser", "用户模块" },
                    { new Guid("6b974101-eae9-4da7-b251-e7ef65cdf4d0"), null, null, 1, false, null, null, new Guid("402ff1a4-7fb8-4597-8013-5b907b3981a9"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Files/DeleteFile", "文件模块" },
                    { new Guid("950a5bb3-55ee-4770-860c-1e4b34cfcdb3"), null, null, 2, false, null, null, null, new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/User", "用户模块" },
                    { new Guid("9e90e539-5974-4999-9cb3-e5e2603d0d89"), null, null, 0, false, null, null, new Guid("31b6c114-f57c-4e70-b598-c6ec975cf708"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Login/Login", "登录模块" },
                    { new Guid("adc3bbdc-85e8-4cff-8b09-c33e0aa57974"), null, null, 0, false, null, null, new Guid("402ff1a4-7fb8-4597-8013-5b907b3981a9"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Files/UploadFiles", "文件模块" },
                    { new Guid("b17d7991-e6a6-4717-a434-354c984efe9c"), null, null, 1, false, null, null, new Guid("31b6c114-f57c-4e70-b598-c6ec975cf708"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Login/ExitLogin", "登录模块" },
                    { new Guid("e55d3f23-b412-41b4-8d33-d480db838202"), null, null, 3, false, null, null, new Guid("402ff1a4-7fb8-4597-8013-5b907b3981a9"), new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), "/api/Files/GetFileNames", "文件模块" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccountCode", "ContactWay", "DeleteBy", "DeletedTime", "FreezeTime", "HeadPortrait", "IsDeleted", "ModifiedId", "ModifiedTime", "Name", "Password", "Power", "Signature", "Status" },
                values: new object[] { new Guid("59bfe729-4bfb-45d2-9ba5-956dd7d3b73b"), "admin", "239573049@qq.com", null, null, null, "https://ts1.cn.mm.bing.net/th?id=OIP-C.79smi7hB-2AHPbroJr8rnwAAAA&w=204&h=204&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2", false, null, null, "管理员", "9716DADA3B1D9F12524528D33419BE62", 0, null, 0 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "DeleteBy", "DeletedTime", "IsDeleted", "ModifiedId", "ModifiedTime", "RoleId", "UserId" },
                values: new object[] { new Guid("a685a746-eb3f-4286-a105-a88559de6712"), null, null, false, null, null, new Guid("29539ae5-8fc2-41c0-b6f2-7e579b958139"), new Guid("59bfe729-4bfb-45d2-9ba5-956dd7d3b73b") });

            migrationBuilder.CreateIndex(
                name: "IX_Role_Id",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_Id",
                table: "RoleFunction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_Id",
                table: "UserRole",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleFunction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
