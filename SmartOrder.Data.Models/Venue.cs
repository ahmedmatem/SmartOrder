using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SmartOrder.Common.EntityValidationConstants.Venue;
namespace SmartOrder.Data.Models
{
    public class Venue
    {
        [Required]
        [Comment("Venue Identifier")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Venue name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(TypeNameMaxLength)]
        [Comment("Type of the venue(restaurant, pub, cafe, etc.)")]
        public string Type { get; set; } = null!;

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("The city where the venue is located")]
        public string City { get; set; } = null!;

        [DataType(DataType.DateTime)]
        [Comment("Date when the venue was added.")]
        public DateTime CreatedOn { get; set; }

        public List<Table> Tables { get; set; } = new List<Table>();

        public List<ApplicationUser> Employees { get; set; } = new List<ApplicationUser>();

        public List<MenuCategory> MenuCategories { get; set; } = new List<MenuCategory>();
    }
}
