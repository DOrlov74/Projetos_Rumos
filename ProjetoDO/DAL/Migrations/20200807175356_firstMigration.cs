using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDados.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFamily",
                columns: table => new
                {
                    fldFamilyID = table.Column<string>(maxLength: 5, nullable: false),
                    fldFamily = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFamily", x => x.fldFamilyID);
                });

            migrationBuilder.CreateTable(
                name: "tblPaymentTypes",
                columns: table => new
                {
                    fldPaymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldPaymentType = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaymentTypes", x => x.fldPaymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tblStore",
                columns: table => new
                {
                    fldStoreID = table.Column<string>(maxLength: 5, nullable: false),
                    fldStore = table.Column<string>(maxLength: 50, nullable: false),
                    fldStoreAddress = table.Column<string>(maxLength: 50, nullable: false),
                    fldActive = table.Column<bool>(nullable: true),
                    fldModifiedDate = table.Column<DateTime>(nullable: true),
                    fldCreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStore", x => x.fldStoreID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 120, nullable: true),
                    City = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 9, nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    fldProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldBarcode = table.Column<string>(maxLength: 12, nullable: true),
                    fldProductName = table.Column<string>(maxLength: 50, nullable: false),
                    fldFamily = table.Column<string>(maxLength: 5, nullable: false),
                    fldUnitMeasure = table.Column<string>(maxLength: 50, nullable: true),
                    fldQtyPerUnit = table.Column<decimal>(nullable: false),
                    fldUnitPrice = table.Column<decimal>(nullable: false),
                    fldDiscontinued = table.Column<bool>(nullable: true),
                    fldDateCreated = table.Column<DateTime>(nullable: true),
                    fldDateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.fldProductID);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblFamily_fldFamily",
                        column: x => x.fldFamily,
                        principalTable: "tblFamily",
                        principalColumn: "fldFamilyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyPos",
                columns: table => new
                {
                    fldPosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldStoreID = table.Column<string>(maxLength: 5, nullable: false),
                    fldStoreLocation = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPos", x => x.fldPosID);
                    table.ForeignKey(
                        name: "FK_MyPos_tblStore_fldStoreID",
                        column: x => x.fldStoreID,
                        principalTable: "tblStore",
                        principalColumn: "fldStoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblStock",
                columns: table => new
                {
                    fldStockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldProductID = table.Column<int>(nullable: false),
                    fldStoreID = table.Column<string>(maxLength: 5, nullable: true),
                    fldQuantity = table.Column<int>(nullable: false),
                    fldQuantityBase = table.Column<int>(nullable: false),
                    fldSaleUnit = table.Column<string>(maxLength: 20, nullable: true),
                    fldQtySaleUnit = table.Column<int>(nullable: true),
                    fldModifiedDate = table.Column<DateTime>(nullable: true),
                    fldCreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStock", x => x.fldStockID);
                    table.ForeignKey(
                        name: "FK_tblStock_tblProduct_fldProductID",
                        column: x => x.fldProductID,
                        principalTable: "tblProduct",
                        principalColumn: "fldProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStock_tblStore_fldStoreID",
                        column: x => x.fldStoreID,
                        principalTable: "tblStore",
                        principalColumn: "fldStoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblSale",
                columns: table => new
                {
                    fldSalesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldSalesDocNum = table.Column<string>(maxLength: 20, nullable: true),
                    fldStore = table.Column<string>(maxLength: 5, nullable: true),
                    fldPOSnum = table.Column<int>(nullable: false),
                    fldPOSUser = table.Column<int>(nullable: false),
                    fldDateCreated = table.Column<DateTime>(nullable: true),
                    fldDatemodified = table.Column<DateTime>(nullable: true),
                    fldPaid = table.Column<bool>(nullable: true),
                    fldCUstomer = table.Column<int>(nullable: false),
                    tblPosfldPosID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSale", x => x.fldSalesID);
                    table.ForeignKey(
                        name: "FK_tblSale_tblUser_fldPOSUser",
                        column: x => x.fldPOSUser,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSale_MyPos_tblPosfldPosID",
                        column: x => x.tblPosfldPosID,
                        principalTable: "MyPos",
                        principalColumn: "fldPosID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPayments",
                columns: table => new
                {
                    fldPaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldSalesID = table.Column<int>(maxLength: 50, nullable: false),
                    fldPaidValue = table.Column<decimal>(nullable: false),
                    fldPaymentTypeID = table.Column<int>(nullable: false),
                    fldCreatedDate = table.Column<DateTime>(nullable: true),
                    fldStore = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayments", x => x.fldPaymentID);
                    table.ForeignKey(
                        name: "FK_tblPayments_tblPaymentTypes_fldPaymentTypeID",
                        column: x => x.fldPaymentTypeID,
                        principalTable: "tblPaymentTypes",
                        principalColumn: "fldPaymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPayments_tblSale_fldSalesID",
                        column: x => x.fldSalesID,
                        principalTable: "tblSale",
                        principalColumn: "fldSalesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSalesDetail",
                columns: table => new
                {
                    fldSalesDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldSalesID = table.Column<int>(nullable: false),
                    fldSeq = table.Column<int>(nullable: false),
                    fldProduct = table.Column<int>(nullable: false),
                    fldQuantity = table.Column<int>(nullable: false),
                    fldUnitPrice = table.Column<int>(nullable: false),
                    fldLineTotal = table.Column<decimal>(nullable: false),
                    fldDateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalesDetail", x => x.fldSalesDetailID);
                    table.ForeignKey(
                        name: "FK_tblSalesDetail_tblSale_fldSalesID",
                        column: x => x.fldSalesID,
                        principalTable: "tblSale",
                        principalColumn: "fldSalesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyPos_fldStoreID",
                table: "MyPos",
                column: "fldStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayments_fldPaymentTypeID",
                table: "tblPayments",
                column: "fldPaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayments_fldSalesID",
                table: "tblPayments",
                column: "fldSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_fldFamily",
                table: "tblProduct",
                column: "fldFamily");

            migrationBuilder.CreateIndex(
                name: "IX_tblSale_fldPOSUser",
                table: "tblSale",
                column: "fldPOSUser");

            migrationBuilder.CreateIndex(
                name: "IX_tblSale_tblPosfldPosID",
                table: "tblSale",
                column: "tblPosfldPosID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSalesDetail_fldSalesID",
                table: "tblSalesDetail",
                column: "fldSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_fldProductID",
                table: "tblStock",
                column: "fldProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_fldStoreID",
                table: "tblStock",
                column: "fldStoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPayments");

            migrationBuilder.DropTable(
                name: "tblSalesDetail");

            migrationBuilder.DropTable(
                name: "tblStock");

            migrationBuilder.DropTable(
                name: "tblPaymentTypes");

            migrationBuilder.DropTable(
                name: "tblSale");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "MyPos");

            migrationBuilder.DropTable(
                name: "tblFamily");

            migrationBuilder.DropTable(
                name: "tblStore");
        }
    }
}
