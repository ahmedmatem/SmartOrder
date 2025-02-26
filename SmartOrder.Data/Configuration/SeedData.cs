using Microsoft.AspNetCore.Identity;
using SmartOrder.Data.Models;

namespace SmartOrder.Data.Configuration
{
    public class SeedData
    {
        public ApplicationUser FirstVenueWaiterUser { get; set; }
        public ApplicationUser SecondVenueWaiterUser { get; set; }
        public ApplicationUser ThirdVenueWaiterUser { get; set; }

        public ApplicationUser FirstVenueManagerUser { get; set; }
        public ApplicationUser SecondVenueManagerUser { get; set; }
        public ApplicationUser ThirdVenueManagerUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public Venue FirstVenue { get; set; }
        public Venue SecondVenue { get; set; }
        public Venue ThirdVenue { get; set; }

        public IdentityRole<Guid> AdminRole { get; set; }
        public IdentityRole<Guid> ManagerRole { get; set; }
        public IdentityRole<Guid> WaiterRole { get; set; }

        public List<IdentityUserRole<Guid>> UsersInRoles { get; set; } = new List<IdentityUserRole<Guid>>();

        public List<Table> FirstVenueTables { get; set; }
        public List<Table> SecondVenueTables { get; set; }
        public List<Table> ThirdVenueTables { get; set; }

        public List<MenuCategory> FirstVenueMenuCategories { get; set; }
        public List<MenuCategory> SecondVenueMenuCategories { get; set; }
        public List<MenuCategory> ThirdVenueMenuCategories { get; set; }

        public List<MenuItem> FirstVenueMenuItems { get; set; }
        public List<MenuItem> SecondVenueMenuItems { get; set; }
        public List<MenuItem> ThirdVenueMenuItems { get; set; }

        public SeedData()
        {
            
            SeedVenues();
            SeedRoles();
            SeedUsers();
            SeedUsersInRoles();
            SeedTables();
            SeedMenuCategories();
            SeedMenuItems();
        }

        public void SeedVenues()
        {
            FirstVenue = new Venue()
            {
                Id = Guid.NewGuid(),
                Name = "Ресторант Балкан",
                Type = "Ресторант",
                City = "София",
                CreatedOn = DateTime.UtcNow
            };

            SecondVenue = new Venue()
            {
                Id = Guid.NewGuid(),
                Name = "Кафе Арома",
                Type = "Кафене",
                City = "Пловдив",
                CreatedOn = DateTime.UtcNow
            };

            ThirdVenue = new Venue()
            {
                Id = Guid.NewGuid(),
                Name = "Бар Нощ",
                Type = "Бар",
                City = "Варна",
                CreatedOn = DateTime.UtcNow
            };
        }

        private void SeedRoles()
        {
            AdminRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            ManagerRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "Manager",
                NormalizedName = "MANAGER"
            };

            WaiterRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "Waiter",
                NormalizedName = "WAITER"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            FirstVenueWaiterUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "waiter1@mail.com",
                NormalizedUserName = "waiter1@mail.com",
                Email = "waiter1@mail.com",
                NormalizedEmail = "waiter1@mail.com",
                FullName = "First Waiter",
                VenueId = FirstVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            FirstVenueWaiterUser.PasswordHash =
                 hasher.HashPassword(FirstVenueWaiterUser, "waiter1");

            SecondVenueWaiterUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "waiter2@mail.com",
                NormalizedUserName = "waiter2@mail.com",
                Email = "waiter2@mail.com",
                NormalizedEmail = "waiter2@mail.com",
                FullName = "Second Waiter",
                VenueId = SecondVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            SecondVenueWaiterUser.PasswordHash =
                 hasher.HashPassword(SecondVenueWaiterUser, "waiter2");

            ThirdVenueWaiterUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "waiter3@mail.com",
                NormalizedUserName = "waiter3@mail.com",
                Email = "waiter3@mail.com",
                NormalizedEmail = "waiter3@mail.com",
                FullName = "Third Waiter",
                VenueId = ThirdVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            ThirdVenueWaiterUser.PasswordHash =
                 hasher.HashPassword(ThirdVenueWaiterUser, "waiter3");

            FirstVenueManagerUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "manager1@mail.com",
                NormalizedUserName = "manager1@mail.com",
                Email = "manager1@mail.com",
                NormalizedEmail = "manager1@mail.com",
                FullName = "First Manager",
                VenueId = FirstVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            FirstVenueManagerUser.PasswordHash =
                 hasher.HashPassword(FirstVenueManagerUser, "manager1");

            SecondVenueManagerUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "manager2@mail.com",
                NormalizedUserName = "manager2@mail.com",
                Email = "manager2@mail.com",
                NormalizedEmail = "manager2@mail.com",
                FullName = "Second Manager",
                VenueId = SecondVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            SecondVenueManagerUser.PasswordHash =
                 hasher.HashPassword(SecondVenueManagerUser, "manager2");

            ThirdVenueManagerUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "manager3@mail.com",
                NormalizedUserName = "manager3@mail.com",
                Email = "manager3@mail.com",
                NormalizedEmail = "manager3@mail.com",
                FullName = "Third Manager",
                VenueId = ThirdVenue.Id,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            ThirdVenueManagerUser.PasswordHash =
                 hasher.HashPassword(ThirdVenueManagerUser, "manager3");

            AdminUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FullName = "Great Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
        }
        private void SeedUsersInRoles()
        {
            UsersInRoles.Clear();

            UsersInRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    UserId = AdminUser.Id,
                    RoleId = AdminRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = FirstVenueWaiterUser.Id,
                    RoleId = WaiterRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = SecondVenueWaiterUser.Id,
                    RoleId = WaiterRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = ThirdVenueWaiterUser.Id,
                    RoleId = WaiterRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = FirstVenueManagerUser.Id,
                    RoleId = ManagerRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = SecondVenueManagerUser.Id,
                    RoleId = ManagerRole.Id
                },
                new IdentityUserRole<Guid>()
                {
                    UserId = ThirdVenueManagerUser.Id,
                    RoleId = ManagerRole.Id
                }
            };
        }

        private void SeedTables()
        {
            FirstVenueTables = new List<Table>()
            {
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    TableNumber = 1
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    TableNumber = 2
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    TableNumber = 3
                }
            };

            SecondVenueTables = new List<Table>()
            {
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    TableNumber = 1
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    TableNumber = 2
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    TableNumber = 3
                }
            };

            ThirdVenueTables = new List<Table>()
            {
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    TableNumber = 1
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    TableNumber = 2
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    TableNumber = 3
                }
            };
        }

        private void SeedMenuCategories()
        {
            FirstVenueMenuCategories = new List<MenuCategory>()
            {
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    Title = "Предястия",
                    Description = "Вкусни хапки за начало"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    Title = "Основни",
                    Description = "Голямо разнообразие от ястия"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = FirstVenue.Id,
                    Title = "Десерти",
                    Description = "Сладки изкушения"
                }
            };

            SecondVenueMenuCategories = new List<MenuCategory>()
            {
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    Title = "Кафе и напитки",
                    Description = "Богато разнообразие от ароматни кафета и освежаващи напитки"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    Title = "Закуски",
                    Description = "Леко и бързо хапване"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = SecondVenue.Id,
                    Title = "Десерти",
                    Description = "Домашно приготвени десерти"
                }
            };

            ThirdVenueMenuCategories = new List<MenuCategory>()
            {
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    Title = "Алкохолни напитки",
                    Description = "Голямо разнообразие от алкохолни изкушения"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    Title = "Безалкохолни напитки",
                    Description = "Напитки без алкохол"
                },
                new MenuCategory
                {
                    Id = Guid.NewGuid(),
                    VenueId = ThirdVenue.Id,
                    Title = "Снаксове",
                    Description = "Съпроводете напитките си с избор от лесни закуски"
                }
            };
        }

        private void SeedMenuItems()
        {
            FirstVenueMenuItems = new List<MenuItem>()
            {
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[0].Id,
                    Title = "Шопска салата",
                    Description = "Класическа българска салата с домати, краставици, лук, сирене и зехтин",
                    Price = 7.50m,
                    Tags = "Салата, Вегетарианско",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/09/Chopska.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[0].Id,
                    Title = "Гъби на фурна",
                    Description = "Печени гъби с чесън, мащерка и зехтин",
                    Price = 6.50m,
                    Tags = "Гъби, Вегетарианско",
                    ImageUrl = "https://gotvach.bg/files/1200x800/pechurki-maslo-furna.webp"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[1].Id,
                    Title = "Свинско с картофи",
                    Description = "Запечено свинско месо с картофи и подправки",
                    Price = 14.99m,
                    Tags = "Месо, Традиционно",
                    ImageUrl = "https://matekitchen.com/wp-content/uploads/2023/12/svinsko-s-kartofi.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[1].Id,
                    Title = "Пиле с ориз",
                    Description = "Пилешко филе с ориз и зеленчуци",
                    Price = 12.50m,
                    Tags = "Пиле, Лесно",
                    ImageUrl = "https://lysp.eu/wp-content/uploads/2022/04/pile-s-oriz-big-1200x675.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[1].Id,
                    Title = "Риба на скара",
                    Description = "Пъстърва на скара с лимон и зехтин",
                    Price = 16.00m,
                    Tags = "Риба, Здравословно",
                    ImageUrl = "https://matekitchen.com/wp-content/uploads/2019/09/CG012b_pystyrva-na-skara-s-limon-shalot-i-bilki.jpg"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[2].Id,
                    Title = "Шоколадова торта",
                    Description = "Шоколадова торта с ванилов крем и горски плодове",
                    Price = 6.99m,
                    Tags = "Торта, Шоколад",
                    ImageUrl = "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[2].Id,
                    Title = "Крем карамел",
                    Description = "Класически крем карамел с карамелен сос",
                    Price = 5.50m,
                    Tags = "Десерт, Крем",
                    ImageUrl = "https://www.kulinarno-joana.com/wp-content/uploads/2011/05/DSC1671-2.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = FirstVenueMenuCategories[2].Id,
                    Title = "Палачинки с мед и орехи",
                    Description = "Палачинки с пълнозърнесто брашно, мед и счукани орехи",
                    Price = 7.00m,
                    Tags = "Палачинки, Сладко",
                    ImageUrl = "https://www.bonapeti.bg/uploads/posts/post315.jpg"
                }
            };

            SecondVenueMenuItems = new List<MenuItem>()
            {
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[0].Id,
                    Title = "Еспресо",
                    Description = "Класическо еспресо с богат вкус",
                    Price = 2.50m,
                    Tags = "Кафе, Класика",
                    ImageUrl = "https://cdn4.focus.bg/fakti/photos/big/83f/kakva-e-razlikata-mejdu-espreso-i-obiknoveno-kafe-1.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[0].Id,
                    Title = "Капучино",
                    Description = "Капучино с кремообразна пяна",
                    Price = 3.50m,
                    Tags = "Кафе, Мляко",
                    ImageUrl = "https://instantpot.bg/wp-content/uploads/instantpot-recepta-capuccino.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[0].Id,
                    Title = "Чай",
                    Description = "Избор от зелен, черен и плодов чай",
                    Price = 2.00m,
                    Tags = "Чай, Без кофеин",
                    ImageUrl = "https://natural.bg/wp-content/uploads/2022/10/%D0%B1%D0%B8%D0%BB%D0%BA%D0%BE%D0%B2-%D1%87%D0%B0%D0%B9-%D1%81%D1%80%D0%B5%D1%89%D1%83-%D1%81%D1%82%D0%B0%D1%80%D0%B0%D0%B5%D0%B5%D0%BD%D0%B5-1600x1068.jpg"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[1].Id,
                    Title = "Сандвич с прошуто",
                    Description = "Сандвич с прошуто, сирене и рукола",
                    Price = 6.50m,
                    Tags = "Сандвич, Леко",
                    ImageUrl = "https://matekitchen.com/wp-content/uploads/2021/01/sandvich-proshuto-motsarela.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[1].Id,
                    Title = "Кекс",
                    Description = "Домашен кекс с шоколадови парченца",
                    Price = 3.00m,
                    Tags = "Кекс, Сладко",
                    ImageUrl = "https://gotvach.bg/files/1200x800/parcheta-keks-pudra.webp"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[2].Id,
                    Title = "Шоколадова торта",
                    Description = "Шоколадова торта с ванилов крем",
                    Price = 5.50m,
                    Tags = "Торта, Шоколад",
                    ImageUrl = "https://sire-media-foxbg.fichub.com/24k_bg/clip-main/643955.1200x675.jpg"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = SecondVenueMenuCategories[2].Id,
                    Title = "Сладолед",
                    Description = "Домашен сладолед с избор от вкусове",
                    Price = 4.00m,
                    Tags = "Сладолед, Освежаващо",
                    ImageUrl = "https://www.lunchbox.eu/wp-content/uploads/2017/06/20170616-DSC_5625.jpg"
                }
            };

            ThirdVenueMenuItems = new List<MenuItem>()
            {
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[0].Id,
                    Title = "Червено вино",
                    Description = "Българско червено вино, 150 мл",
                    Price = 5.00m,
                    Tags = "Вино, Алкохол"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[0].Id,
                    Title = "Маргарита",
                    Description = "Класически коктейл с текила и лайм",
                    Price = 8.00m,
                    Tags = "Коктейл, Алкохол"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[1].Id,
                    Title = "Сок от портокал",
                    Description = "Пресно изстискан сок от портокал",
                    Price = 3.50m,
                    Tags = "Сок, Безалкохолно"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[1].Id,
                    Title = "Лимонада",
                    Description = "Домашна лимонада с мента и лимон",
                    Price = 4.00m,
                    Tags = "Лимонада, Освежаващо"
                },

                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[2].Id,
                    Title = "Чипс",
                    Description = "Хрупкав чипс със сол",
                    Price = 2.00m,
                    Tags = "Чипс, Леко"
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuCategoryId = ThirdVenueMenuCategories[2].Id,
                    Title = "Плато с месо и сирена",
                    Description = "Сирене и месни деликатеси",
                    Price = 10.00m,
                    Tags = "Сирене, Месо"
                }
            };
        }
    }
}