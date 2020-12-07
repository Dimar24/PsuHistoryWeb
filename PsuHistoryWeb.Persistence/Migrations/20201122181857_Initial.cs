using Microsoft.EntityFrameworkCore.Migrations;

namespace PsuHistoryWeb.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConscriptionPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConscriptionPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DutyStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBurials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBurials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVictims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVictims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentForms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberBurial = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPeople = table.Column<int>(type: "int", nullable: false),
                    UnknownNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeBurialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Burials_TypeBurials_TypeBurialId",
                        column: x => x.TypeBurialId,
                        principalTable: "TypeBurials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentBurials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BurialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentBurials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentBurials_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHeroSoviet = table.Column<bool>(type: "bit", nullable: false),
                    IsPartisan = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVictimId = table.Column<int>(type: "int", nullable: false),
                    DutyStationId = table.Column<int>(type: "int", nullable: false),
                    BirthPlaceId = table.Column<int>(type: "int", nullable: false),
                    ConscriptionPlaceId = table.Column<int>(type: "int", nullable: false),
                    BurialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Victims_BirthPlaces_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "BirthPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Victims_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Victims_ConscriptionPlaces_ConscriptionPlaceId",
                        column: x => x.ConscriptionPlaceId,
                        principalTable: "ConscriptionPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Victims_DutyStations_DutyStationId",
                        column: x => x.DutyStationId,
                        principalTable: "DutyStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Victims_TypeVictims_TypeVictimId",
                        column: x => x.TypeVictimId,
                        principalTable: "TypeVictims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentBurials_BurialId",
                table: "AttachmentBurials",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForms_FormId",
                table: "AttachmentForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_TypeBurialId",
                table: "Burials",
                column: "TypeBurialId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_BirthPlaceId",
                table: "Victims",
                column: "BirthPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_BurialId",
                table: "Victims",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_ConscriptionPlaceId",
                table: "Victims",
                column: "ConscriptionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_DutyStationId",
                table: "Victims",
                column: "DutyStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_TypeVictimId",
                table: "Victims",
                column: "TypeVictimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentBurials");

            migrationBuilder.DropTable(
                name: "AttachmentForms");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "BirthPlaces");

            migrationBuilder.DropTable(
                name: "Burials");

            migrationBuilder.DropTable(
                name: "ConscriptionPlaces");

            migrationBuilder.DropTable(
                name: "DutyStations");

            migrationBuilder.DropTable(
                name: "TypeVictims");

            migrationBuilder.DropTable(
                name: "TypeBurials");
        }
    }
}
