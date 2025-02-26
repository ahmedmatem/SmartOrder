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
            public const decimal PriceMinValue = 0.01m;
        }

        public static class MenuCategory
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 20;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 250;
        }

        public static class ApplicationUser
        {
            public const int FullNameMaxLength = 50;
            public const int EmailMaxLength = 100;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

        public static class OrderItem
        {
            public const int QuantityMinValue = 1;
            public const int QuantityMaxValue = 250;
        }

        public static class Table
        {
            public const int TableNumberMinValue = 1;
            public const int TableNumberMaxValue = 500;
            public const int TokenLength = 36;
        }

        public static class Order
        {
            public const int StatusMinLength = 3;
            public const int StatusMaxLength = 20;
        }
    }
}
