using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateReportView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW VW_PRODUCT_REPORT
                                        AS
                                        SELECT 
                                        COUNT(*) ProductCount,
                                        SUM(Price) SumOfPrice,
                                        Max(Price) MaxPrice
                                        FROM Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW VW_PRODUCT_REPORT");
        }
    }
}
