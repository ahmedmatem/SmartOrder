using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartOrder.Common.EntityValidationConstants.MenuCategory;

namespace SmartOrder.Data.Models
{
    public class MenuCategory
    {
        [Required]
        [Comment("Menu Category Identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Venue Identifier")]
        public Guid VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Name of the menu category.")]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the menu category.")]
        public string Description { get; set; } = string.Empty;

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}