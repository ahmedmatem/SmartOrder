using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartOrder.Common.EntityValidationConstants.MenuItem;
namespace SmartOrder.Data.Models
{
    public class MenuItem
    {
        [Required]
        [Comment("Menu item Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Item Category Identifier")]
        public Guid MenuCategoryId { get; set; }

        [ForeignKey(nameof(MenuCategoryId))]
        public MenuCategory MenuCategory { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The title of the menu item.")]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Comment("The description of the menu item.")]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [Comment("The price of the item.")]
        public decimal Price { get; set; }

        [Comment("Indicator of the item availability.")]
        public bool IsAvailable { get; set; }

        [Comment("Quantity or portion size (e.g., grams, millilitres, pieces).")]
        public int Quantity { get; set; }

        [Comment("List of tags describing the item characteristics (e.g., spacy, sweet, vegan)")]
        public string Tags { get; set; } = string.Empty;

        [Comment("Optional image Url for the menu item.")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
