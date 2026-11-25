using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LebanonPos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_entries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    entity_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    entity_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    details = table.Column<string>(type: "jsonb", nullable: true),
                    at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_entries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    vat_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    receipt_footer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    default_language = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    prices_include_vat = table.Column<bool>(type: "boolean", nullable: false),
                    lbp_cash_unit = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lbp_per_usd = table.Column<long>(type: "bigint", nullable: false),
                    effective_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    set_by_user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exchange_rates", x => x.id);
                    table.ForeignKey(
                        name: "fk_exchange_rates_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "registers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registers", x => x.id);
                    table.ForeignKey(
                        name: "fk_registers_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vat_rates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rate_bps = table.Column<int>(type: "integer", nullable: false),
                    effective_from = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vat_rates", x => x.id);
                    table.ForeignKey(
                        name: "fk_vat_rates_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    barcode = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    price_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    price_minor = table.Column<long>(type: "bigint", nullable: false),
                    tax_category = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_products_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    register_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    cashier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sold_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    received_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    lbp_per_usd = table.Column<long>(type: "bigint", nullable: false),
                    vat_rate_bps = table.Column<int>(type: "integer", nullable: false),
                    prices_include_vat = table.Column<bool>(type: "boolean", nullable: false),
                    total_usd_cents = table.Column<long>(type: "bigint", nullable: false),
                    total_lbp = table.Column<long>(type: "bigint", nullable: false),
                    vat_usd_cents = table.Column<long>(type: "bigint", nullable: false),
                    vat_lbp = table.Column<long>(type: "bigint", nullable: false),
                    change_usd_cents = table.Column<long>(type: "bigint", nullable: false),
                    change_lbp = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    voided_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    voided_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    void_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    review_note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sales", x => x.id);
                    table.ForeignKey(
                        name: "fk_sales_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sales_users_cashier_id",
                        column: x => x.cashier_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sale_lines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    quantity = table.Column<decimal>(type: "numeric(12,3)", precision: 12, scale: 3, nullable: false),
                    price_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    unit_price_minor = table.Column<long>(type: "bigint", nullable: false),
                    discount_minor = table.Column<long>(type: "bigint", nullable: false),
                    tax_category = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    line_total_minor = table.Column<long>(type: "bigint", nullable: false),
                    vat_minor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sale_lines", x => x.id);
                    table.ForeignKey(
                        name: "fk_sale_lines_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sale_payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    method = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    amount_minor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sale_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_sale_payments_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audit_entries_shop_id_at",
                table: "audit_entries",
                columns: new[] { "shop_id", "at" });

            migrationBuilder.CreateIndex(
                name: "ix_categories_shop_id",
                table: "categories",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "ix_exchange_rates_shop_id_effective_from",
                table: "exchange_rates",
                columns: new[] { "shop_id", "effective_from" });

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_shop_id_barcode",
                table: "products",
                columns: new[] { "shop_id", "barcode" },
                unique: true,
                filter: "barcode is not null");

            migrationBuilder.CreateIndex(
                name: "ix_products_shop_id_updated_at",
                table: "products",
                columns: new[] { "shop_id", "updated_at" });

            migrationBuilder.CreateIndex(
                name: "ix_registers_shop_id_code",
                table: "registers",
                columns: new[] { "shop_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sale_lines_sale_id",
                table: "sale_lines",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "ix_sale_payments_sale_id",
                table: "sale_payments",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "ix_sales_cashier_id",
                table: "sales",
                column: "cashier_id");

            migrationBuilder.CreateIndex(
                name: "ix_sales_shop_id_register_code_number",
                table: "sales",
                columns: new[] { "shop_id", "register_code", "number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sales_shop_id_sold_at",
                table: "sales",
                columns: new[] { "shop_id", "sold_at" });

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_shop_id",
                table: "users",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "ix_vat_rates_shop_id_effective_from",
                table: "vat_rates",
                columns: new[] { "shop_id", "effective_from" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_entries");

            migrationBuilder.DropTable(
                name: "exchange_rates");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "registers");

            migrationBuilder.DropTable(
                name: "sale_lines");

            migrationBuilder.DropTable(
                name: "sale_payments");

            migrationBuilder.DropTable(
                name: "vat_rates");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "shops");
        }
    }
}
