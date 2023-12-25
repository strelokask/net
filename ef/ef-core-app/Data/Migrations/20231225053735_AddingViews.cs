using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vw_TeamsAndLeagues
                AS
                SELECT t.Name, l.Name as LeagueName
                FROM Teams as t
                LEFT JOIN Leagues as l on t.LeagueId = l.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW vw_TeamsAndLeagues");
        }
    }
}
