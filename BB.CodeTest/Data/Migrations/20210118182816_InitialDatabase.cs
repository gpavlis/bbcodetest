using Microsoft.EntityFrameworkCore.Migrations;

namespace BB.CodeTest.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizaitons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizaitons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Organizaitons_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizaitons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizaitons",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { 1, "Org1", 0 });

            migrationBuilder.InsertData(
                table: "Organizaitons",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { 2, "Org2", 2 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "OrganizationId", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "5517 W Kentucky Ave.", "Lakewood", "Sam", "Stevens", 1, "CO", "80226" },
                    { 2, "5515 W Kentucky Ave.", "Lakewood", "Dan", "Jones", 1, "CO", "80226" },
                    { 3, "5513 W Kentucky Ave.", "Lakewood", "Fred", "Armin", 1, "CO", "80226" },
                    { 4, "1233 W Wyoming Pl.", "Denver", "Harry", "Scott", 2, "CO", "80227" },
                    { 5, "213 W Wyoming Pl.", "Denver", "Ian", "Jefferies", 2, "CO", "80227" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrganizationId",
                table: "Customers",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Organizaitons");
        }
    }
}
