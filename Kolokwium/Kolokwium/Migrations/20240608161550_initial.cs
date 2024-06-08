using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RenewalPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.IdSubscription);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    IdSubscriptionNavigationIdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.IdDiscount);
                    table.ForeignKey(
                        name: "FK_Discount_Subscription_IdSubscriptionNavigationIdSubscription",
                        column: x => x.IdSubscriptionNavigationIdSubscription,
                        principalTable: "Subscription",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClinet = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payment_Client_IdClinet",
                        column: x => x.IdClinet,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_IdSubscription",
                        column: x => x.IdSubscription,
                        principalTable: "Subscription",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClinet = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sale_Client_IdClinet",
                        column: x => x.IdClinet,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Subscription_IdSubscription",
                        column: x => x.IdSubscription,
                        principalTable: "Subscription",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_IdSubscriptionNavigationIdSubscription",
                table: "Discount",
                column: "IdSubscriptionNavigationIdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdClinet",
                table: "Payment",
                column: "IdClinet");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdSubscription",
                table: "Payment",
                column: "IdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdClinet",
                table: "Sale",
                column: "IdClinet");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdSubscription",
                table: "Sale",
                column: "IdSubscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Subscription");
        }
    }
}
