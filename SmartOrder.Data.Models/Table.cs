using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartOrder.Data.Models
{
    public class Table
    {
        [Required]
        [Comment("Table Identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Venue Identifier")]
        public Guid VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; } = null!;

        [Required]
        [Comment("The number of the table")]
        public int TableNumber { get; set; }

        [Required]
        [Comment("Unique long length token for the table.")]
        public string Token { get; set; } = Guid.NewGuid().ToString();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
