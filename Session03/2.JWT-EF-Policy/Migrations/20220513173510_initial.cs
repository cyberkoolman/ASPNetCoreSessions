using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskTitle = table.Column<string>(type: "TEXT", nullable: true),
                    TaskDesc = table.Column<string>(type: "TEXT", nullable: true),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaskTo = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    ToPublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Rating", "TaskDesc", "TaskTitle", "TaskTo", "ToPublish" },
                values: new object[] { 1, false, "", "Complete daily homework assigned from the grad shcool", "Daily Homework", "dwilliam", false });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Rating", "TaskDesc", "TaskTitle", "TaskTo", "ToPublish" },
                values: new object[] { 2, false, "", "Daily standup to share the current workitem", "Standup Meeting", "jbrown", false });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Rating", "TaskDesc", "TaskTitle", "TaskTo", "ToPublish" },
                values: new object[] { 3, false, "", "Review current sprint and share overall progress", "Sprint Review", "pjordan", false });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Rating", "TaskDesc", "TaskTitle", "TaskTo", "ToPublish" },
                values: new object[] { 4, true, "Average", "Share the recent news to org-wide developer community", "Community Announcement", "pjordan", false });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Rating", "TaskDesc", "TaskTitle", "TaskTo", "ToPublish" },
                values: new object[] { 5, true, "Excellent", "Review daily tasks and update status", "Review Task", "ajones", true });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[] { 1, "Amy", "Jones", "ajones123", "Manager", "ajones" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[] { 2, "Pete", "Jordan", "pjordan123", "Teamlead", "pjordan" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[] { 3, "James", "Brown", "jbrown123", "Worker", "jbrown" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[] { 4, "David", "William", "dwilliam123", "Worker", "dwilliam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todos");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
