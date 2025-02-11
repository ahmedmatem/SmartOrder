using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Venues_VenueId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "VenueId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Unique identifier of the site user/staff participate in.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unique identifier of the site user/staff participate in.");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7e6e3b03-8ff1-4354-bb28-ad3e19f2fc1d"), null, "Admin", "ADMIN" },
                    { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), null, "Waiter", "WAITER" },
                    { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VenueId" },
                values: new object[] { new Guid("d70e1a51-f4c5-439a-9807-fa2f1224fe95"), 0, "7929eb68-c831-40ce-96db-98c27599be1f", "admin@mail.com", false, "Great Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEOpbYTfMSQAr2M78FEIJt+9LlYDkiVJhoBSjjHmtd8W5VuKLPKSYjaSNre5aRaLMuw==", null, false, null, false, "admin@mail.com", null });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "City", "CreatedOn", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb"), "София", new DateTime(2025, 2, 11, 14, 34, 3, 123, DateTimeKind.Utc).AddTicks(6531), "Ресторант Балкан", "Ресторант" },
                    { new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5"), "Варна", new DateTime(2025, 2, 11, 14, 34, 3, 123, DateTimeKind.Utc).AddTicks(6540), "Бар Нощ", "Бар" },
                    { new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0"), "Пловдив", new DateTime(2025, 2, 11, 14, 34, 3, 123, DateTimeKind.Utc).AddTicks(6536), "Кафе Арома", "Кафене" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7e6e3b03-8ff1-4354-bb28-ad3e19f2fc1d"), new Guid("d70e1a51-f4c5-439a-9807-fa2f1224fe95") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VenueId" },
                values: new object[,]
                {
                    { new Guid("4567e5d2-0109-4cb1-876a-24e2648bddcd"), 0, "e0fd0ac0-dd32-4798-998b-a48963cadee9", "waiter2@mail.com", false, "Second Waiter", false, null, "waiter2@mail.com", "waiter2@mail.com", "AQAAAAIAAYagAAAAEC17FtqfkIruq02ao2Msw/how3rpgNSB/6I4U6BGZleQ655nPPayeCJau1gjTmYQCA==", null, false, null, false, "waiter2@mail.com", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") },
                    { new Guid("53aff14c-edd6-4ac5-9f6e-8859f1d2bf0f"), 0, "c6aa2efa-cc4c-4f66-aeaa-c44346301c27", "waiter3@mail.com", false, "Third Waiter", false, null, "waiter3@mail.com", "waiter3@mail.com", "AQAAAAIAAYagAAAAEKEGv52QXjD/F4TrTHBCCRKb+neuJEpO68Ln0qPPi3H/rctD6tHKSOonrGNyPvK64g==", null, false, null, false, "waiter3@mail.com", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("5adb002a-d3ab-4d8c-bd4a-7e9306a8679c"), 0, "e8f21cb0-cbd8-4b65-99ee-003f592d218e", "manager3@mail.com", false, "Third Manager", false, null, "manager3@mail.com", "manager3@mail.com", "AQAAAAIAAYagAAAAEGaBHH7NntsfKL4JwptA/zpRI6oeBD9E2XEB9gNbC8uabsza12Y0ANbHNWyC2yFx5Q==", null, false, null, false, "manager3@mail.com", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("a3e41b62-dc64-421f-aee2-b0df7bae800c"), 0, "7c489039-2287-4c31-bc2f-c5ea6a5d040a", "manager1@mail.com", false, "First Manager", false, null, "manager1@mail.com", "manager1@mail.com", "AQAAAAIAAYagAAAAEDMmel81Rfd3SqNS3yo/LJOpImkSywyXEDYRhzj8jLTfrniVP151NiB0fgXbsBNxzw==", null, false, null, false, "manager1@mail.com", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("af23cbb6-538b-43de-874d-f2c55a674ed6"), 0, "94ff32ab-c65f-4468-89a6-9d1f57ef386f", "waiter1@mail.com", false, "First Waiter", false, null, "waiter1@mail.com", "waiter1@mail.com", "AQAAAAIAAYagAAAAEIrwubDSrHRWj+Br3SdM8z8nDUN3IKImiJ/XW7hF3M0xG08fnB3X6OoeuMB6slRQxA==", null, false, null, false, "waiter1@mail.com", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("d9c256a4-c001-4cd3-a96c-597b0dbf1e7f"), 0, "c6b1a263-f57d-4570-9410-f0246d27e71e", "manager2@mail.com", false, "Second Manager", false, null, "manager2@mail.com", "manager2@mail.com", "AQAAAAIAAYagAAAAEKJTgN6j8K4Vi02NRwUEgaqNi+zJYIRLFqwiuZon57TwqhrJg5i+p8S4cR1bA2qjOA==", null, false, null, false, "manager2@mail.com", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") }
                });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "Description", "Title", "VenueId" },
                values: new object[,]
                {
                    { new Guid("1f099730-5cbe-4ec2-ae3f-7cda7fedc888"), "Домашно приготвени десерти", "Десерти", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") },
                    { new Guid("2748dafd-9947-49ae-8069-b62eb96b0a8a"), "Напитки без алкохол", "Безалкохолни напитки", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("3c0738de-f0a2-4cdd-99cf-4bef9d615507"), "Вкусни хапки за начало", "Предястия", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("8ce3e761-9f19-49da-8436-6672d19e1eb4"), "Сладки изкушения", "Десерти", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("9293d311-22ba-43d2-8e7e-437f60a34f13"), "Съпроводете напитките си с избор от лесни закуски", "Снаксове", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("a5ce9c7b-3a42-41e3-b077-a05fb5b59c40"), "Голямо разнообразие от алкохолни изкушения", "Алкохолни напитки", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("daf4f198-b850-45df-994e-d6d098ce3843"), "Голямо разнообразие от ястия", "Основни", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("dd954961-abc9-4d5c-9afd-1f778a1b0ce3"), "Леко и бързо хапване", "Закуски", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") },
                    { new Guid("fb63f3a2-501b-457b-891a-ceeae2a87366"), "Богато разнообразие от ароматни кафета и освежаващи напитки", "Кафе и напитки", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "TableNumber", "Token", "VenueId" },
                values: new object[,]
                {
                    { new Guid("0d81467d-d947-4a61-9d12-e2161bbfce30"), 1, "21e1009a-ca10-4791-a0b9-e9d4cf8d50b4", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") },
                    { new Guid("1b96e6c6-243f-4dad-bffb-7cdfeaeb30b6"), 2, "664aa9b1-0aeb-46e3-a65a-94e781883daf", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("36f0ed8c-51df-4a26-8782-97e9f5b277a5"), 3, "d33b9493-cee3-4d6c-864d-c072820212a0", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("43f70d70-bdb5-4eff-a9f7-f2eebe1c894f"), 1, "cce15088-ec30-40e5-8b53-60ac1a538de2", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("6c587bba-0fa1-4d33-bbee-6dcaa58c8efe"), 3, "8bae3cc9-3ec2-42cc-889b-0efc65412001", new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5") },
                    { new Guid("7175cadb-8d2e-4cb8-ad2b-fe45f8f92d6f"), 3, "4b94daac-2fef-46fa-ac3e-92f5c326dfb8", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") },
                    { new Guid("a780a125-2b46-4f06-8699-3c4d5c054896"), 2, "36b8e443-8bbb-470f-aeac-9d3d9f3489c6", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("b22c52e8-c7a6-47ff-b19b-dfac24e8b156"), 1, "229b4016-3e38-4d56-8738-689825280470", new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb") },
                    { new Guid("e69e2583-77d9-4acc-a715-e6b216cadc28"), 2, "69ffa0d0-6cef-47c5-8d95-faffb12abc23", new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("4567e5d2-0109-4cb1-876a-24e2648bddcd") },
                    { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("53aff14c-edd6-4ac5-9f6e-8859f1d2bf0f") },
                    { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("5adb002a-d3ab-4d8c-bd4a-7e9306a8679c") },
                    { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("a3e41b62-dc64-421f-aee2-b0df7bae800c") },
                    { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("af23cbb6-538b-43de-874d-f2c55a674ed6") },
                    { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("d9c256a4-c001-4cd3-a96c-597b0dbf1e7f") }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "ImageUrl", "IsAvailable", "MenuCategoryId", "Price", "Quantity", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("03fd5a12-c0a2-4906-89af-1149c4f5a62f"), "Българско червено вино, 150 мл", "", true, new Guid("a5ce9c7b-3a42-41e3-b077-a05fb5b59c40"), 5.00m, 1, "Вино, Алкохол", "Червено вино" },
                    { new Guid("0621024c-f777-454e-bede-6128bdd47016"), "Класическа българска салата с домати, краставици, лук, сирене и зехтин", "https://upload.wikimedia.org/wikipedia/commons/0/09/Chopska.jpg", true, new Guid("3c0738de-f0a2-4cdd-99cf-4bef9d615507"), 7.50m, 1, "Салата, Вегетарианско", "Шопска салата" },
                    { new Guid("09ac32ee-dbf8-4c25-a00e-e9b9e42502a7"), "Шоколадова торта с ванилов крем", "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg", true, new Guid("1f099730-5cbe-4ec2-ae3f-7cda7fedc888"), 5.50m, 1, "Торта, Шоколад", "Шоколадова торта" },
                    { new Guid("1094d9c4-2903-45b5-9f48-b6bd5266e7df"), "Сирене и месни деликатеси", "", true, new Guid("9293d311-22ba-43d2-8e7e-437f60a34f13"), 10.00m, 1, "Сирене, Месо", "Плато с месо и сирена" },
                    { new Guid("145b8fdf-98b2-4f1c-8d22-5b0130577591"), "Печени гъби с чесън, мащерка и зехтин", "https://gotvach.bg/files/1200x800/pechurki-maslo-furna.webp", true, new Guid("3c0738de-f0a2-4cdd-99cf-4bef9d615507"), 6.50m, 1, "Гъби, Вегетарианско", "Гъби на фурна" },
                    { new Guid("1b2b7192-87c8-4d3d-abb2-e0c3561ff93d"), "Пресно изстискан сок от портокал", "", true, new Guid("2748dafd-9947-49ae-8069-b62eb96b0a8a"), 3.50m, 1, "Сок, Безалкохолно", "Сок от портокал" },
                    { new Guid("230e5b91-38ad-480a-8d63-f8250c65d4e0"), "Пъстърва на скара с лимон и зехтин", "https://matekitchen.com/wp-content/uploads/2019/09/CG012b_pystyrva-na-skara-s-limon-shalot-i-bilki.jpg", true, new Guid("daf4f198-b850-45df-994e-d6d098ce3843"), 16.00m, 1, "Риба, Здравословно", "Риба на скара" },
                    { new Guid("2b535b82-cc93-40ee-bac3-39f0c8d9af72"), "Класическо еспресо с богат вкус", "https://cdn4.focus.bg/fakti/photos/big/83f/kakva-e-razlikata-mejdu-espreso-i-obiknoveno-kafe-1.jpg", true, new Guid("fb63f3a2-501b-457b-891a-ceeae2a87366"), 2.50m, 1, "Кафе, Класика", "Еспресо" },
                    { new Guid("3b0537dc-8109-4277-8a02-671f37eecdad"), "Домашна лимонада с мента и лимон", "", true, new Guid("2748dafd-9947-49ae-8069-b62eb96b0a8a"), 4.00m, 1, "Лимонада, Освежаващо", "Лимонада" },
                    { new Guid("47db107d-60a6-4814-827c-1487a8ac4c43"), "Домашен сладолед с избор от вкусове", "https://www.lunchbox.eu/wp-content/uploads/2017/06/20170616-DSC_5625.jpg", true, new Guid("1f099730-5cbe-4ec2-ae3f-7cda7fedc888"), 4.00m, 1, "Сладолед, Освежаващо", "Сладолед" },
                    { new Guid("6a2e6acd-2d53-4ea5-b091-7a34af73a8a2"), "Класически коктейл с текила и лайм", "", true, new Guid("a5ce9c7b-3a42-41e3-b077-a05fb5b59c40"), 8.00m, 1, "Коктейл, Алкохол", "Маргарита" },
                    { new Guid("6f2b76a1-6b7a-4c98-a7cd-2ffae4962476"), "Сандвич с прошуто, сирене и рукола", "https://matekitchen.com/wp-content/uploads/2021/01/sandvich-proshuto-motsarela.jpg", true, new Guid("dd954961-abc9-4d5c-9afd-1f778a1b0ce3"), 6.50m, 1, "Сандвич, Леко", "Сандвич с прошуто" },
                    { new Guid("752540f8-0c1d-463c-9033-4168b5bea312"), "Домашен кекс с шоколадови парченца", "https://gotvach.bg/files/1200x800/parcheta-keks-pudra.webp", true, new Guid("dd954961-abc9-4d5c-9afd-1f778a1b0ce3"), 3.00m, 1, "Кекс, Сладко", "Кекс" },
                    { new Guid("78ebca75-52fa-428e-9f07-8cd23d3f6295"), "Избор от зелен, черен и плодов чай", "https://natural.bg/wp-content/uploads/2022/10/%D0%B1%D0%B8%D0%BB%D0%BA%D0%BE%D0%B2-%D1%87%D0%B0%D0%B9-%D1%81%D1%80%D0%B5%D1%89%D1%83-%D1%81%D1%82%D0%B0%D1%80%D0%B0%D0%B5%D0%B5%D0%BD%D0%B5-1600x1068.jpg", true, new Guid("fb63f3a2-501b-457b-891a-ceeae2a87366"), 2.00m, 1, "Чай, Без кофеин", "Чай" },
                    { new Guid("98740609-281a-4cfc-a9dd-e12d458009c4"), "Хрупкав чипс със сол", "", true, new Guid("9293d311-22ba-43d2-8e7e-437f60a34f13"), 2.00m, 1, "Чипс, Леко", "Чипс" },
                    { new Guid("aeccb218-29f9-4a31-8e3f-2e2e51a582be"), "Класически крем карамел с карамелен сос", "https://www.kulinarno-joana.com/wp-content/uploads/2011/05/DSC1671-2.jpg", true, new Guid("8ce3e761-9f19-49da-8436-6672d19e1eb4"), 5.50m, 1, "Десерт, Крем", "Крем карамел" },
                    { new Guid("cf2f2ff9-2540-4c38-8e13-f8031c33226a"), "Капучино с кремообразна пяна", "https://instantpot.bg/wp-content/uploads/instantpot-recepta-capuccino.jpg", true, new Guid("fb63f3a2-501b-457b-891a-ceeae2a87366"), 3.50m, 1, "Кафе, Мляко", "Капучино" },
                    { new Guid("d4d7e7ac-ac3d-4344-b2ab-d6bc53cac607"), "Шоколадова торта с ванилов крем и горски плодове", "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg", true, new Guid("8ce3e761-9f19-49da-8436-6672d19e1eb4"), 6.99m, 1, "Торта, Шоколад", "Шоколадова торта" },
                    { new Guid("ee86f4d6-6e39-4185-a899-43ea971612e7"), "Палачинки с пълнозърнесто брашно, мед и счукани орехи", "https://www.bonapeti.bg/uploads/posts/post315.jpg", true, new Guid("8ce3e761-9f19-49da-8436-6672d19e1eb4"), 7.00m, 1, "Палачинки, Сладко", "Палачинки с мед и орехи" },
                    { new Guid("ef895637-9079-4c47-8caa-e5fe7cab6f28"), "Пилешко филе с ориз и зеленчуци", "https://lysp.eu/wp-content/uploads/2022/04/pile-s-oriz-big-1200x675.jpg", true, new Guid("daf4f198-b850-45df-994e-d6d098ce3843"), 12.50m, 1, "Пиле, Лесно", "Пиле с ориз" },
                    { new Guid("f5a54884-7496-4785-8a3a-13de248ad20d"), "Запечено свинско месо с картофи и подправки", "https://matekitchen.com/wp-content/uploads/2023/12/svinsko-s-kartofi.jpg", true, new Guid("daf4f198-b850-45df-994e-d6d098ce3843"), 14.99m, 1, "Месо, Традиционно", "Свинско с картофи" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Venues_VenueId",
                table: "AspNetUsers",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Venues_VenueId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("4567e5d2-0109-4cb1-876a-24e2648bddcd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("53aff14c-edd6-4ac5-9f6e-8859f1d2bf0f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("5adb002a-d3ab-4d8c-bd4a-7e9306a8679c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("a3e41b62-dc64-421f-aee2-b0df7bae800c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"), new Guid("af23cbb6-538b-43de-874d-f2c55a674ed6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7e6e3b03-8ff1-4354-bb28-ad3e19f2fc1d"), new Guid("d70e1a51-f4c5-439a-9807-fa2f1224fe95") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"), new Guid("d9c256a4-c001-4cd3-a96c-597b0dbf1e7f") });

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("03fd5a12-c0a2-4906-89af-1149c4f5a62f"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0621024c-f777-454e-bede-6128bdd47016"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("09ac32ee-dbf8-4c25-a00e-e9b9e42502a7"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1094d9c4-2903-45b5-9f48-b6bd5266e7df"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("145b8fdf-98b2-4f1c-8d22-5b0130577591"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1b2b7192-87c8-4d3d-abb2-e0c3561ff93d"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("230e5b91-38ad-480a-8d63-f8250c65d4e0"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("2b535b82-cc93-40ee-bac3-39f0c8d9af72"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("3b0537dc-8109-4277-8a02-671f37eecdad"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("47db107d-60a6-4814-827c-1487a8ac4c43"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("6a2e6acd-2d53-4ea5-b091-7a34af73a8a2"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("6f2b76a1-6b7a-4c98-a7cd-2ffae4962476"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("752540f8-0c1d-463c-9033-4168b5bea312"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("78ebca75-52fa-428e-9f07-8cd23d3f6295"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("98740609-281a-4cfc-a9dd-e12d458009c4"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("aeccb218-29f9-4a31-8e3f-2e2e51a582be"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("cf2f2ff9-2540-4c38-8e13-f8031c33226a"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d4d7e7ac-ac3d-4344-b2ab-d6bc53cac607"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("ee86f4d6-6e39-4185-a899-43ea971612e7"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("ef895637-9079-4c47-8caa-e5fe7cab6f28"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f5a54884-7496-4785-8a3a-13de248ad20d"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("0d81467d-d947-4a61-9d12-e2161bbfce30"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("1b96e6c6-243f-4dad-bffb-7cdfeaeb30b6"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("36f0ed8c-51df-4a26-8782-97e9f5b277a5"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("43f70d70-bdb5-4eff-a9f7-f2eebe1c894f"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("6c587bba-0fa1-4d33-bbee-6dcaa58c8efe"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("7175cadb-8d2e-4cb8-ad2b-fe45f8f92d6f"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("a780a125-2b46-4f06-8699-3c4d5c054896"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("b22c52e8-c7a6-47ff-b19b-dfac24e8b156"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("e69e2583-77d9-4acc-a715-e6b216cadc28"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e6e3b03-8ff1-4354-bb28-ad3e19f2fc1d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87d18b8b-5f82-4170-b5f8-c37d0b21c2b9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d23082d-d1dd-4b7c-908c-aec02891d981"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4567e5d2-0109-4cb1-876a-24e2648bddcd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("53aff14c-edd6-4ac5-9f6e-8859f1d2bf0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5adb002a-d3ab-4d8c-bd4a-7e9306a8679c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3e41b62-dc64-421f-aee2-b0df7bae800c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af23cbb6-538b-43de-874d-f2c55a674ed6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d70e1a51-f4c5-439a-9807-fa2f1224fe95"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d9c256a4-c001-4cd3-a96c-597b0dbf1e7f"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("1f099730-5cbe-4ec2-ae3f-7cda7fedc888"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("2748dafd-9947-49ae-8069-b62eb96b0a8a"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c0738de-f0a2-4cdd-99cf-4bef9d615507"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("8ce3e761-9f19-49da-8436-6672d19e1eb4"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("9293d311-22ba-43d2-8e7e-437f60a34f13"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("a5ce9c7b-3a42-41e3-b077-a05fb5b59c40"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("daf4f198-b850-45df-994e-d6d098ce3843"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("dd954961-abc9-4d5c-9afd-1f778a1b0ce3"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("fb63f3a2-501b-457b-891a-ceeae2a87366"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("5c6a03f7-073f-42d9-a7c6-2c6d5b8445eb"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("6747d4ca-fdd8-4fea-a1ce-84570e1398d5"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("dbd888de-5c71-4c3b-bb7a-0664f826e8a0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "VenueId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique identifier of the site user/staff participate in.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Unique identifier of the site user/staff participate in.");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Venues_VenueId",
                table: "AspNetUsers",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
