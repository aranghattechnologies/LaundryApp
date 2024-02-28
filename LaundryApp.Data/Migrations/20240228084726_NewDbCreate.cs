using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LaundryApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    passwordresettoken = table.Column<string>(type: "text", nullable: true),
                    passwordtokenexpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    unit = table.Column<int>(type: "integer", nullable: false),
                    perunitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<long>(type: "bigint", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    tax = table.Column<decimal>(type: "numeric", nullable: false),
                    nettotal = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    duedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pickuprequests",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<long>(type: "bigint", nullable: false),
                    prefedtimestart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    prefedtimeend = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    assignedtoid = table.Column<long>(type: "bigint", nullable: true),
                    pickuptime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pickuprequests", x => x.id);
                    table.ForeignKey(
                        name: "fk_pickuprequests_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pickuprequests_employees_assignedtoid",
                        column: x => x.assignedtoid,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orderitem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    serviceid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    linetotal = table.Column<decimal>(type: "numeric", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderitem", x => x.id);
                    table.ForeignKey(
                        name: "fk_orderitem_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_orderitem_services_serviceid",
                        column: x => x.serviceid,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_orderid",
                table: "orderitem",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_serviceid",
                table: "orderitem",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customerid",
                table: "orders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_pickuprequests_assignedtoid",
                table: "pickuprequests",
                column: "assignedtoid");

            migrationBuilder.CreateIndex(
                name: "ix_pickuprequests_customerid",
                table: "pickuprequests",
                column: "customerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderitem");

            migrationBuilder.DropTable(
                name: "pickuprequests");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
