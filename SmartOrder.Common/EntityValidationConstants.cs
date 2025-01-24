namespace SmartOrder.Common
{
    public static class EntityValidationConstants
    {
        public static class Venue
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
            public const int TypeNameMinLength = 3;
            public const int TypeNameMaxLength = 30;
            public const int CityNameMinLength = 2;
            public const int CityNameMaxLength = 20;
        }

        public static class MenuItem
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 30;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
        }

        public static class MenuCategory
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 20;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 250;
        }

        public static class OrderItem
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class ApplicationUser
        {
            public const int FullNameMaxLength = 50;
        }
    }
}
