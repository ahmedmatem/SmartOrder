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
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), null, "Manager", "MANAGER" },
                    { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), null, "Waiter", "WAITER" },
                    { new Guid("862a4dbf-578f-47c3-bdc6-647fc47f554b"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VenueId" },
                values: new object[] { new Guid("3c935a53-fa3f-4027-b0b8-f6801bb139ff"), 0, "2c32c72a-a92b-40d8-8196-4b0fe4816af9", "admin@mail.com", false, "Great Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEGhZAM3j4oHc2ZldaIOW0CmfHsou8uBqOiPBACrOHahMAJ3KZ52eVRrC2JwZsAMkeg==", null, false, "efc0d52e-b56f-42e0-865f-6fd24640b14c", false, "admin@mail.com", null });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "City", "CreatedOn", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df"), "Варна", new DateTime(2025, 2, 25, 7, 46, 7, 728, DateTimeKind.Utc).AddTicks(3122), "Бар Нощ", "Бар" },
                    { new Guid("962491b7-4643-46f9-bde3-cd4773fec737"), "Пловдив", new DateTime(2025, 2, 25, 7, 46, 7, 728, DateTimeKind.Utc).AddTicks(3105), "Кафе Арома", "Кафене" },
                    { new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439"), "София", new DateTime(2025, 2, 25, 7, 46, 7, 728, DateTimeKind.Utc).AddTicks(3100), "Ресторант Балкан", "Ресторант" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("862a4dbf-578f-47c3-bdc6-647fc47f554b"), new Guid("3c935a53-fa3f-4027-b0b8-f6801bb139ff") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VenueId" },
                values: new object[,]
                {
                    { new Guid("19dd8116-4813-4cb0-b0ef-2266c7473c9a"), 0, "87c2ad98-ce77-4ae6-b25c-a3626b732808", "manager1@mail.com", false, "First Manager", false, null, "manager1@mail.com", "manager1@mail.com", "AQAAAAIAAYagAAAAEMZ5bXFrZGMW0Xiy/l8doZiz8ymJG/SwbU9CakKSvZM96/qx5KKyagEoJJ7dUoH67w==", null, false, "2572c8d3-dd0e-458c-bd93-a7ac972cba9c", false, "manager1@mail.com", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("3ba99fdf-87fb-46bf-8e9f-f11d01853cde"), 0, "18aea7e4-e83a-4a88-a9be-8fa3526665d0", "manager2@mail.com", false, "Second Manager", false, null, "manager2@mail.com", "manager2@mail.com", "AQAAAAIAAYagAAAAEAA3chLtzjqmB9SgRS2hP7PFLDUw39QjTQUWskbuS9s+1he35ruocF8wB5TQkig7Hw==", null, false, "9964cdc4-4916-485c-95a7-16785bf10432", false, "manager2@mail.com", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("5d959c9a-7e42-433c-bb04-1e49eedf6d81"), 0, "97c41630-e610-45aa-8b8f-f2ce71ff727b", "waiter3@mail.com", false, "Third Waiter", false, null, "waiter3@mail.com", "waiter3@mail.com", "AQAAAAIAAYagAAAAEAk505+mEvEQHXhyQGZEWo4o4pyn07iVl4dieWfiVjO25gK7fhBSGBUNCTG1psnanA==", null, false, "46093405-fef3-4253-a29c-25bbb7462cfa", false, "waiter3@mail.com", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("b73befbc-e44a-494b-9245-7e9750dc23a6"), 0, "f8a1b826-1dd6-4195-8e20-d32645cabfc0", "manager3@mail.com", false, "Third Manager", false, null, "manager3@mail.com", "manager3@mail.com", "AQAAAAIAAYagAAAAEG6xDO7gOuYSB/Ya3PUc5esJZEgidubtwWsk0/qF1GsAyxxw337GzjuFCrqz7//YXQ==", null, false, "ca80806e-929e-4941-9332-ba614945a9ce", false, "manager3@mail.com", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("c05ca829-7ea2-423f-b640-65c7c048ae01"), 0, "1d55ff44-0388-4fd2-a06c-14cefa85388b", "waiter1@mail.com", false, "First Waiter", false, null, "waiter1@mail.com", "waiter1@mail.com", "AQAAAAIAAYagAAAAENKt69Qg+2+K+xaAS392n8pVMZO6av9/gE1M8DE7VX+trVATdP+VSBxlq7d+bbrxRw==", null, false, "f69f971b-bbe4-475a-b9fe-afce9ec3f58b", false, "waiter1@mail.com", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("e7c59aa2-2123-4806-90b8-4375ac71bc2a"), 0, "a743ce9b-b6ba-4742-a82d-dd0af49645f2", "waiter2@mail.com", false, "Second Waiter", false, null, "waiter2@mail.com", "waiter2@mail.com", "AQAAAAIAAYagAAAAENiBMO7IDZgvsgFzj/89kj5thB/hWw/OZyV3fHbCLSP3dMzETOpuwu7wxRvv6o7b+w==", null, false, "28399002-fbf3-4518-a6a2-1d058e26dab9", false, "waiter2@mail.com", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") }
                });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "Description", "Title", "VenueId" },
                values: new object[,]
                {
                    { new Guid("00c1d4c4-d659-4d46-8a96-3b87368a8cdf"), "Голямо разнообразие от ястия", "Основни", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("2b093ff6-ad2a-4eba-863c-1b3ed8f1307d"), "Сладки изкушения", "Десерти", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("2b8f2d21-c406-496e-9527-ad81e0ccc3a4"), "Вкусни хапки за начало", "Предястия", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("32676ebc-ebbe-4466-a2e8-9e000c0487c2"), "Напитки без алкохол", "Безалкохолни напитки", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("6f50b246-508f-4393-a131-d7671424c58a"), "Леко и бързо хапване", "Закуски", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("7c9d5656-5716-4b51-9162-a686bb9c4dd8"), "Съпроводете напитките си с избор от лесни закуски", "Снаксове", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("baffdc08-a4a7-4f81-924d-12ee711bb070"), "Богато разнообразие от ароматни кафета и освежаващи напитки", "Кафе и напитки", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("e70fd979-6bd8-462c-a4ef-fcc19ecd18dc"), "Домашно приготвени десерти", "Десерти", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("fd0bd05f-9db6-403e-9650-d3cd8b1e2ff3"), "Голямо разнообразие от алкохолни изкушения", "Алкохолни напитки", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "TableNumber", "Token", "VenueId" },
                values: new object[,]
                {
                    { new Guid("01ed4cad-b290-4b76-95a6-182a0bab682e"), 2, "c2c04659-c756-4438-a4c6-ffebac448053", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("0c4b8f6d-3ff8-4bc1-ad81-af6f6bbaa0a4"), 1, "3cb9d411-e2d5-4d8f-a424-1e14c4d2c84e", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("531193df-9074-403d-9db7-172271a08574"), 1, "b1f5fede-12d7-4b66-8f8d-1289cd8afcac", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("73d095f0-f62b-46fe-863d-4bf8c0cb0423"), 3, "eaa73804-4d39-4db4-b055-a834e2e56ab7", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("7594682c-d06f-429f-9c88-8b7ac72678e0"), 3, "54ab4b84-cb97-4bd6-a84f-4f4137661b63", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("76fb1a1f-278a-497b-89e7-b30df3ca6c26"), 2, "2167de98-341f-47e0-9d9e-430d043471a9", new Guid("962491b7-4643-46f9-bde3-cd4773fec737") },
                    { new Guid("9183a517-c0ee-42be-9209-c01c20754e2f"), 1, "5ba60774-dda4-46ad-9753-0480608ca78c", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") },
                    { new Guid("b70f8c02-3d62-4fd5-9910-bf7af85cb154"), 2, "11b04407-018d-4365-9269-ad6324956b27", new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439") },
                    { new Guid("ec4fd383-6d5c-4d07-aeec-2d20f86578fa"), 3, "80fdb8cc-fec2-42f1-b747-f4ac0ca67d4f", new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("19dd8116-4813-4cb0-b0ef-2266c7473c9a") },
                    { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("3ba99fdf-87fb-46bf-8e9f-f11d01853cde") },
                    { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("5d959c9a-7e42-433c-bb04-1e49eedf6d81") },
                    { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("b73befbc-e44a-494b-9245-7e9750dc23a6") },
                    { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("c05ca829-7ea2-423f-b640-65c7c048ae01") },
                    { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("e7c59aa2-2123-4806-90b8-4375ac71bc2a") }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "ImageUrl", "MenuCategoryId", "Price", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("0ac00a8e-5ff1-4f47-b2fa-103be1f74a26"), "Класически коктейл с текила и лайм", "", new Guid("fd0bd05f-9db6-403e-9650-d3cd8b1e2ff3"), 8.00m, "Коктейл, Алкохол", "Маргарита" },
                    { new Guid("0b72bf0d-f3e3-4b2f-b2d3-46504d2ae863"), "Класическо еспресо с богат вкус", "https://cdn4.focus.bg/fakti/photos/big/83f/kakva-e-razlikata-mejdu-espreso-i-obiknoveno-kafe-1.jpg", new Guid("baffdc08-a4a7-4f81-924d-12ee711bb070"), 2.50m, "Кафе, Класика", "Еспресо" },
                    { new Guid("0d6dc994-aac0-4f83-abc8-ee3706bf758b"), "Българско червено вино, 150 мл", "", new Guid("fd0bd05f-9db6-403e-9650-d3cd8b1e2ff3"), 5.00m, "Вино, Алкохол", "Червено вино" },
                    { new Guid("150e9841-fc50-4969-97be-442225c4295f"), "Запечено свинско месо с картофи и подправки", "https://matekitchen.com/wp-content/uploads/2023/12/svinsko-s-kartofi.jpg", new Guid("00c1d4c4-d659-4d46-8a96-3b87368a8cdf"), 14.99m, "Месо, Традиционно", "Свинско с картофи" },
                    { new Guid("1534dda9-dba6-423f-bb01-07cd42c71fed"), "Хрупкав чипс със сол", "", new Guid("7c9d5656-5716-4b51-9162-a686bb9c4dd8"), 2.00m, "Чипс, Леко", "Чипс" },
                    { new Guid("1716492d-6c3e-4dd6-a6e5-e97f90330794"), "Капучино с кремообразна пяна", "https://instantpot.bg/wp-content/uploads/instantpot-recepta-capuccino.jpg", new Guid("baffdc08-a4a7-4f81-924d-12ee711bb070"), 3.50m, "Кафе, Мляко", "Капучино" },
                    { new Guid("413f3a4d-1e6c-4890-9c3b-7de120dfcf42"), "Печени гъби с чесън, мащерка и зехтин", "https://gotvach.bg/files/1200x800/pechurki-maslo-furna.webp", new Guid("2b8f2d21-c406-496e-9527-ad81e0ccc3a4"), 6.50m, "Гъби, Вегетарианско", "Гъби на фурна" },
                    { new Guid("4ed8e3fd-3d36-4856-8c2e-742e52fa47d6"), "Класическа българска салата с домати, краставици, лук, сирене и зехтин", "https://upload.wikimedia.org/wikipedia/commons/0/09/Chopska.jpg", new Guid("2b8f2d21-c406-496e-9527-ad81e0ccc3a4"), 7.50m, "Салата, Вегетарианско", "Шопска салата" },
                    { new Guid("5f2d67cb-4698-485a-a84c-7c1cf8b1aa29"), "Шоколадова торта с ванилов крем и горски плодове", "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg", new Guid("2b093ff6-ad2a-4eba-863c-1b3ed8f1307d"), 6.99m, "Торта, Шоколад", "Шоколадова торта" },
                    { new Guid("767ca197-f4aa-45b4-baa0-5348d4f3709a"), "Палачинки с пълнозърнесто брашно, мед и счукани орехи", "https://www.bonapeti.bg/uploads/posts/post315.jpg", new Guid("2b093ff6-ad2a-4eba-863c-1b3ed8f1307d"), 7.00m, "Палачинки, Сладко", "Палачинки с мед и орехи" },
                    { new Guid("88488784-518f-48c2-9929-b7136cd78044"), "Сандвич с прошуто, сирене и рукола", "https://matekitchen.com/wp-content/uploads/2021/01/sandvich-proshuto-motsarela.jpg", new Guid("6f50b246-508f-4393-a131-d7671424c58a"), 6.50m, "Сандвич, Леко", "Сандвич с прошуто" },
                    { new Guid("94ce05cb-f697-4b03-b724-d466417d70ec"), "Пресно изстискан сок от портокал", "", new Guid("32676ebc-ebbe-4466-a2e8-9e000c0487c2"), 3.50m, "Сок, Безалкохолно", "Сок от портокал" },
                    { new Guid("a9d3da0a-55d9-41d0-8716-ed92cdfe9b71"), "Класически крем карамел с карамелен сос", "https://www.kulinarno-joana.com/wp-content/uploads/2011/05/DSC1671-2.jpg", new Guid("2b093ff6-ad2a-4eba-863c-1b3ed8f1307d"), 5.50m, "Десерт, Крем", "Крем карамел" },
                    { new Guid("abe2c759-8c25-4e05-b655-641f413dea68"), "Избор от зелен, черен и плодов чай", "https://natural.bg/wp-content/uploads/2022/10/%D0%B1%D0%B8%D0%BB%D0%BA%D0%BE%D0%B2-%D1%87%D0%B0%D0%B9-%D1%81%D1%80%D0%B5%D1%89%D1%83-%D1%81%D1%82%D0%B0%D1%80%D0%B0%D0%B5%D0%B5%D0%BD%D0%B5-1600x1068.jpg", new Guid("baffdc08-a4a7-4f81-924d-12ee711bb070"), 2.00m, "Чай, Без кофеин", "Чай" },
                    { new Guid("b3ece1b8-afc1-4823-b253-b3d18b306e38"), "Пилешко филе с ориз и зеленчуци", "https://lysp.eu/wp-content/uploads/2022/04/pile-s-oriz-big-1200x675.jpg", new Guid("00c1d4c4-d659-4d46-8a96-3b87368a8cdf"), 12.50m, "Пиле, Лесно", "Пиле с ориз" },
                    { new Guid("b5880533-8623-4044-8bdd-62dae306e331"), "Домашен сладолед с избор от вкусове", "https://www.lunchbox.eu/wp-content/uploads/2017/06/20170616-DSC_5625.jpg", new Guid("e70fd979-6bd8-462c-a4ef-fcc19ecd18dc"), 4.00m, "Сладолед, Освежаващо", "Сладолед" },
                    { new Guid("b5c1a145-0a2a-4fc1-a623-6f1d57fe67f4"), "Пъстърва на скара с лимон и зехтин", "https://matekitchen.com/wp-content/uploads/2019/09/CG012b_pystyrva-na-skara-s-limon-shalot-i-bilki.jpg", new Guid("00c1d4c4-d659-4d46-8a96-3b87368a8cdf"), 16.00m, "Риба, Здравословно", "Риба на скара" },
                    { new Guid("e7c33eb1-12c8-4c53-a498-9230b61f2e06"), "Домашен кекс с шоколадови парченца", "https://gotvach.bg/files/1200x800/parcheta-keks-pudra.webp", new Guid("6f50b246-508f-4393-a131-d7671424c58a"), 3.00m, "Кекс, Сладко", "Кекс" },
                    { new Guid("ebc7fd70-fb87-4fda-8edb-67cc9117d579"), "Шоколадова торта с ванилов крем", "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg", new Guid("e70fd979-6bd8-462c-a4ef-fcc19ecd18dc"), 5.50m, "Торта, Шоколад", "Шоколадова торта" },
                    { new Guid("ef5c6936-4c78-4536-9f44-b144352c7623"), "Домашна лимонада с мента и лимон", "", new Guid("32676ebc-ebbe-4466-a2e8-9e000c0487c2"), 4.00m, "Лимонада, Освежаващо", "Лимонада" },
                    { new Guid("f29f965a-e5ca-4652-b8c9-ad7851a64367"), "Сирене и месни деликатеси", "", new Guid("7c9d5656-5716-4b51-9162-a686bb9c4dd8"), 10.00m, "Сирене, Месо", "Плато с месо и сирена" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("19dd8116-4813-4cb0-b0ef-2266c7473c9a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("3ba99fdf-87fb-46bf-8e9f-f11d01853cde") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("862a4dbf-578f-47c3-bdc6-647fc47f554b"), new Guid("3c935a53-fa3f-4027-b0b8-f6801bb139ff") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("5d959c9a-7e42-433c-bb04-1e49eedf6d81") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"), new Guid("b73befbc-e44a-494b-9245-7e9750dc23a6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("c05ca829-7ea2-423f-b640-65c7c048ae01") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"), new Guid("e7c59aa2-2123-4806-90b8-4375ac71bc2a") });

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0ac00a8e-5ff1-4f47-b2fa-103be1f74a26"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0b72bf0d-f3e3-4b2f-b2d3-46504d2ae863"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0d6dc994-aac0-4f83-abc8-ee3706bf758b"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("150e9841-fc50-4969-97be-442225c4295f"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1534dda9-dba6-423f-bb01-07cd42c71fed"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1716492d-6c3e-4dd6-a6e5-e97f90330794"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("413f3a4d-1e6c-4890-9c3b-7de120dfcf42"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4ed8e3fd-3d36-4856-8c2e-742e52fa47d6"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("5f2d67cb-4698-485a-a84c-7c1cf8b1aa29"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("767ca197-f4aa-45b4-baa0-5348d4f3709a"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("88488784-518f-48c2-9929-b7136cd78044"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("94ce05cb-f697-4b03-b724-d466417d70ec"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a9d3da0a-55d9-41d0-8716-ed92cdfe9b71"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("abe2c759-8c25-4e05-b655-641f413dea68"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b3ece1b8-afc1-4823-b253-b3d18b306e38"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b5880533-8623-4044-8bdd-62dae306e331"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b5c1a145-0a2a-4fc1-a623-6f1d57fe67f4"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("e7c33eb1-12c8-4c53-a498-9230b61f2e06"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("ebc7fd70-fb87-4fda-8edb-67cc9117d579"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("ef5c6936-4c78-4536-9f44-b144352c7623"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f29f965a-e5ca-4652-b8c9-ad7851a64367"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("01ed4cad-b290-4b76-95a6-182a0bab682e"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("0c4b8f6d-3ff8-4bc1-ad81-af6f6bbaa0a4"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("531193df-9074-403d-9db7-172271a08574"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("73d095f0-f62b-46fe-863d-4bf8c0cb0423"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("7594682c-d06f-429f-9c88-8b7ac72678e0"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("76fb1a1f-278a-497b-89e7-b30df3ca6c26"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("9183a517-c0ee-42be-9209-c01c20754e2f"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("b70f8c02-3d62-4fd5-9910-bf7af85cb154"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("ec4fd383-6d5c-4d07-aeec-2d20f86578fa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ec6ea3-9373-427d-b286-394ef4c6a9eb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f81af5c-f2f0-4a57-9f14-60c1261054fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("862a4dbf-578f-47c3-bdc6-647fc47f554b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19dd8116-4813-4cb0-b0ef-2266c7473c9a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba99fdf-87fb-46bf-8e9f-f11d01853cde"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c935a53-fa3f-4027-b0b8-f6801bb139ff"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5d959c9a-7e42-433c-bb04-1e49eedf6d81"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b73befbc-e44a-494b-9245-7e9750dc23a6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c05ca829-7ea2-423f-b640-65c7c048ae01"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7c59aa2-2123-4806-90b8-4375ac71bc2a"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("00c1d4c4-d659-4d46-8a96-3b87368a8cdf"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("2b093ff6-ad2a-4eba-863c-1b3ed8f1307d"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("2b8f2d21-c406-496e-9527-ad81e0ccc3a4"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("32676ebc-ebbe-4466-a2e8-9e000c0487c2"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f50b246-508f-4393-a131-d7671424c58a"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c9d5656-5716-4b51-9162-a686bb9c4dd8"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("baffdc08-a4a7-4f81-924d-12ee711bb070"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("e70fd979-6bd8-462c-a4ef-fcc19ecd18dc"));

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: new Guid("fd0bd05f-9db6-403e-9650-d3cd8b1e2ff3"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("02ab919c-96bc-4cce-a02b-dfc859e3a7df"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("962491b7-4643-46f9-bde3-cd4773fec737"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("e064b0a4-a62d-41c2-a432-706ae8ff7439"));
        }
    }
}
