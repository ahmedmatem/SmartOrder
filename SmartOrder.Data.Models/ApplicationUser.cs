using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SmartOrder.Common.EntityValidationConstants.ApplicationUser;

namespace SmartOrder.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("User full name.")]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = string.Empty;

        [Comment("Unique identifier of the site user/staff participate in.")]
        public Guid VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; } = null!;
    }
}
